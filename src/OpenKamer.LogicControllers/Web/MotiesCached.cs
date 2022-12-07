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
		// documentType
		var pub = mongo.GetDatabase("public");

		var a = @"[ { $skip: 0 }, { $limit: 100 } ]";

		var List = await pub.GetCollection("list").Aggregate(a).ToListAsync();

		return Ok(new
		{
			List
		});
	}


}
