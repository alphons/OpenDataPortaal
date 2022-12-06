using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;
using MongoDB.MvcCore;

namespace OpenKamer.LogicControllers.Web;

public partial class WebController : ControllerBase
{
	[HttpPost]
	[Route("~/api/Moties")]
	public async Task<IActionResult> Moties()
	{
		var a = @"
[
	{
		$match: 
		{ 
			'organisatie' : 'Tweede Kamer', 
			'soort' : 'Motie', 
			'vergaderjaar' : '2021-2022'
		} 
	},
	{
		$project:
		{
			_id : 0,
			titel: '$titel',
			onderwerp: '$onderwerp',
			datum: '$datum',
			jaar: '$vergaderjaar'

		}	
	},

{ $skip: 0 },
{ $limit: 100 }
]
";


		var List = await db.GetCollection("documentType").Aggregate(a).ToListAsync();

		return Ok(new
		{
			List
		});
	}
}
