﻿using Microsoft.AspNetCore.Mvc;


using MongoDB.Driver;
using MongoDB.MvcCore;

namespace OpenKamer.LogicControllers.Web;

/*

cd besluitType
> createIndex( { 'zaak.ref': 1 } )

cd stemmingType
> createIndex( { 'besluit.ref': 1 } )

 */
public partial class WebController : ControllerBase
{
	[HttpPost]
	[Route("~/api/Documenten")]
	public async Task<IActionResult> Documenten(string search)
	{
		// documentType
		var a = @"
[
{
	$match: 
	{
		verwijderd: false,
		onderwerp: { $regex: '.*"+ search + @".*', $options: 'i' },
		datum: { $gte:ISODate(""2022-11-01"") , $lt:ISODate(""2022-12-01"") }
	}
},

{
	$lookup:
	{
		localField: 'kamerstukdossier.ref',
		from: 'kamerstukdossierType',
		foreignField: '_id',
		as: 'kamerstukdossier',
		pipeline:
		[
			{ $match: { verwijderd: false } },
			{
				$project:
				{
					verwijderd:0,
					_id:0,
				}
			}
		]
	}
},
{ $unwind: '$kamerstukdossier' },

{
	$lookup:
	{
		localField: 'huidigeDocumentVersie.ref',
		from: 'documentVersieType',
		foreignField: '_id',
		as: 'huidigeDocumentVersie',
		pipeline:
		[
			{ $match: { verwijderd: false } },
			{
				$project:
				{
					verwijderd:0,
					_id:0,
					document:0
				}
			}
		]
	}
},
{ $unwind: '$huidigeDocumentVersie' },

{
	$lookup:
	{
		localField: 'zaak.ref',
		from: 'zaakType',
		foreignField: '_id',
		as: 'zaak',
		pipeline:
		[
			{
				$lookup:
				{
					localField: '_id',
					from: 'besluitType',
					foreignField: 'zaak.ref',
					as: 'besluiten',
					pipeline:
					[
						{ $match: { verwijderd: false, besluitSoort: {$nin: [ null, 'Ingediend' ]} } },
						{
							$project:
							{
								agendapunt:0,
								verwijderd:0,
								zaak:0,
								status:0,
								agendapuntZaakBesluitVolgorde:0,
								bijgewerkt:0
							}
						},
						{
							$lookup:
							{
								localField: '_id',
								from: 'stemmingType',
								foreignField: 'besluit.ref',
								as: 'stemmingen',
								pipeline:
								[
									{ $match: { verwijderd: false } },
									{
										$project:
										{
											_id: 0,
											verwijderd:0,
											sidActorLid:0,
											sidActorFractie: 0,
											fractie:0,
											bijgewerkt:0,
											besluit:0,
											vergissing:0,
											persoon:0
										}
									},
									{
										$sort: { soort: -1 , actorNaam : 1}
									}
								]
							}
						},
						{
							$sort: { 'stemmingen.soort':1, actorNaam:1 }
						}
					]
				}
			},
			{
				$project:
				{
					_id:0,
					kamerstukdossier:0,
					agendapunt:0
				}
			},
			{ $unwind: '$besluiten' }
		]
	}
},
{ $unwind: '$zaak' },


{
	$project:
	{
		verwijderd:0
	}
},
{
	$sort: { datum:-1, _id:1 }
}
{ $skip: 0 },
{ $limit: 10 }
]
";

		var List = await db.GetCollection("documentType").Aggregate(a).ToListAsync();

		return Ok(new
		{
			List
		});
	}




}
