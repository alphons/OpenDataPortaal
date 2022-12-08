using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;
using MongoDB.MvcCore;

namespace OpenKamer.LogicControllers.Web;

public partial class WebController : ControllerBase
{
	[HttpPost]
	[Route("~/api/MotiesCached")]
	public async Task<IActionResult> MotiesCached()
	{
		var pub = mongo.GetDatabase("public");

		var a = @"[ { $skip: 0 }, { $limit: 100 } ]";

		//var count = await pub.GetCollection("moties").EstimatedDocumentCountAsync();

		//if (count == 0)
		//	await Moties(true);

		var List = await pub.GetCollection("moties").Aggregate(a).ToListAsync();

		return Ok(new
		{
			List
		});
	}


}
