
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;
using MongoDB.MvcCore;

namespace OpenKamer.LogicControllers.Web;

public partial class WebController : ControllerBase
{
	[HttpPost]
	[Route("~/api/Personen")]
	public async Task<IActionResult> Personen()
	{
		// collection: persoonType met:
		// contact
		// nevenfuncties
		// geschenk
		// loopbaan
		// onderwijs
		// reis
		// zetelhistory

		var a = @"
[
	{
		$match: { 'functie' : 'Tweede Kamerlid', 'verwijderd': false } 
	},
	{
		$lookup:
		{
			localField: '_id',
			from: 'fractieZetelPersoonType',
			foreignField: 'persoon.ref',
			as: 'zetelhistory',
			pipeline:
			[
				{ $match: { 'verwijderd': false } },
				{
					$lookup:
					{
						localField: 'fractieZetel.ref',
						from: 'fractieZetelType',
						foreignField: '_id',
						as: 'fractiezetel',
						pipeline:
						[
							{ $match: { 'verwijderd': false } },
							{
								$lookup:
								{
									localField: 'fractie.ref',
									from: 'fractieType',
									foreignField: '_id',
									as: 'fractie'
								}
							},	
							{
								$project:
								{
									_id:1,
									fractie:1,
									gewicht: '$gewicht'
								}
							},
							{
								$unwind: '$fractie'
							}

						]
					}
					
				},
				{
					$sort:
					{
						'van' : -1
					}

				},
				{
					$unwind: '$fractiezetel'
				},
				{
					$project:
					{
						_id:0,
						functie:'$functie',
						tot: { $substr: [ '$totEnMet', 0, 10 ] },
						van: { $substr: [ '$van', 0, 10 ] }

						afko: '$fractiezetel.fractie.afkorting',
						naamNL: '$fractiezetel.fractie.naamNl',
						naamEN: '$fractiezetel.fractie.naamEn',
						zetels: '$fractiezetel.fractie.aantalZetels',
						stemmen: '$fractiezetel.fractie.aantalStemmen'
					}
				}
			]
		}
	},
	{
		$lookup:
		{
			localField: '_id',
			from: 'persoonOnderwijsType',
			foreignField: 'persoon.ref',
			as: 'onderwijs',
			pipeline:
			[
				{ $match: { 'verwijderd': false } },
				{
					$project:
					{
						_id:0,
						opleidingNL:'$opleidingNl',
						opleidingEN:'$opleidingEn',
						instelling:'$instelling',
						plaats: '$plaats',
						van: '$van'
						tot: '$totEnMet'
					}
				},
				{
					$sort: { 'gewicht' : 1 }
				}
			]
		}
	},
	{
		$lookup:
		{
			localField: '_id',
			from: 'persoonReisType',
			foreignField: 'persoon.ref',
			as: 'reis',
			pipeline:
			[
				{ $match: { 'verwijderd': false } },
				{
					$project:
					{
						_id:0,
						doel:'$doel',
						bestemming:'$bestemming',
						van: '$van'
						tot: '$totEnMet'
						pay: '$betaaldDoor'
					}
				},
				{
					$sort: { 'gewicht' : 1 }
				}
			]
		}
	},
	{
		$lookup:
		{
			localField: '_id',
			from: 'persoonLoopbaanType',
			foreignField: 'persoon.ref',
			as: 'loopbaan',
			pipeline:
			[
				{ $match: { 'verwijderd': false } },
				{
					$project:
					{
						_id:0,
						functie:'$functie',
						werkgever:'$werkgever',
						omschrijvingNL:'$omschrijvingNl',
						omschrijvingEN:'$omschrijvingEn',
						plaats: '$plaats',
						van: '$van'
						tot: '$totEnMet'
					}
				},
				{
					$sort: { 'gewicht' : 1 }
				}
			]
		}
	},
	{
		$lookup:
		{
			localField: '_id',
			from: 'persoonGeschenkType',
			foreignField: 'persoon.ref',
			as: 'geschenk',
			pipeline:
			[
				{ $match: { 'verwijderd': false } },
				{
					$project:
					{
						_id:0,
						omschrijving:'$omschrijving',
						datums: { $substr: [ '$datum', 0, 10 ] }
					}
				},
				{
					$sort: { 'gewicht' : 1 }
				}
			]
		}
	},
	{
		$lookup:
		{
			localField: '_id',
			from: 'persoonContactinformatieType',
			foreignField: 'persoon.ref',
			as: 'contact',
			pipeline:
			[
				{ $match: { 'verwijderd': false } },
				{
					$project:
					{
						_id:0,
						type:'$soort',
						val:'$waarde'
					}
				}
			]
		}
	},
	{
		$lookup:
		{
			localField: '_id',
			from: 'persoonNevenfunctieType',
			foreignField: 'persoon.ref',
			as: 'nevenfuncties',
			pipeline:
			[
				{ $match: { 'verwijderd': false } },
				{
					$lookup:
					{
						localField: '_id',
						from: 'persoonNevenfunctieInkomstenType',
						foreignField: 'persoonNevenfunctie.ref',
						as: 'inkomsten',
						pipeline:
						[
							{
								$project:
								{
									_id:0,
									jaar: '$jaar',
									bedrag: { $ifNull: ['$bedrag', ""?"" ] },
								}
							},
							{
								$sort: { jaar: 1 }
							}
						]
					}
				},
				{
					$project:
					{
						_id:0,
						omschrijving:'$omschrijving',
						soort: '$vergoeding.soort',
						inkomsten:1
					}
				},
				{
					$set:
					{
						'inkomsten':
						{
							$cond:
							[
								{ 
									$eq: [ { $size: '$inkomsten' }, 0 ]
								},
								'$$REMOVE',
								'$inkomsten'
							]
						}
					}
				}
			]
		}
	},
	{
		$project:
		{
			_id:0,
			roepnaam : '$roepnaam',
			tussenvoegsel: { $ifNull: ['$tussenvoegsel', """" ] },
			achternaam: '$achternaam',
			zetelhistory: 1,
			nevenfuncties:1,
			contact:1,
			geschenk:1,
			loopbaan:1,
			onderwijs:1,
			reis:1
		}
	},
	{
		$set:
		{
			'nevenfuncties':
			{
				$cond:
				[
					{ 
						$eq: [ { $size: '$nevenfuncties' }, 0 ]
					},
					'$$REMOVE',
					'$nevenfuncties'
				]
			}
		}
	},
	{
		$set:
		{
			'geschenk':
			{
				$cond:
				[
					{ 
						$eq: [ { $size: '$geschenk' }, 0 ]
					},
					'$$REMOVE',
					'$geschenk'
				]
			}
		}
	},
	{
		$set:
		{
			'loopbaan':
			{
				$cond:
				[
					{ 
						$eq: [ { $size: '$loopbaan' }, 0 ]
					},
					'$$REMOVE',
					'$loopbaan'
				]
			}
		}
	},
	{
		$set:
		{
			'onderwijs':
			{
				$cond:
				[
					{ 
						$eq: [ { $size: '$onderwijs' }, 0 ]
					},
					'$$REMOVE',
					'$onderwijs'
				]
			}
		}
	},
	{
		$set:
		{
			'reis':
			{
				$cond:
				[
					{ 
						$eq: [ { $size: '$reis' }, 0 ]
					},
					'$$REMOVE',
					'$reis'
				]
			}
		}
	},
	{
		$sort:
		{
			achternaam: 1
		}
	},
	{
		$skip: 0 },
	{
		$limit: 150 }
]
";
		var List = await db.GetCollection("persoonType").Aggregate(a).ToListAsync();

		return Ok(new
		{
			List
		});
	}
}
