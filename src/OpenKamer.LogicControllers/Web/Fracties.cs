
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;
using MongoDB.MvcCore;

namespace OpenKamer.LogicControllers.Web;

public partial class WebController : ControllerBase
{
	[HttpPost]
	[Route("~/api/Fracties")]
	public async Task<IActionResult> Fracties()
	{
		var a = @"
[
{ $match: { verwijderd: false, 'aantalZetels' : { $gt : 0 } } },
{ $project:
  {
		_id: 0,
		afko: '$afkorting',
		naam: '$naamNl',
		zetels: '$aantalZetels',
		stemmen: '$aantalStemmen',
  }
},
{ $skip: 0 },
{ $limit: 50 }
]";
		var List = await db.GetCollection("fractieType").Aggregate(a).ToListAsync();

		return Ok(new
		{
			List
		});
	}

}
