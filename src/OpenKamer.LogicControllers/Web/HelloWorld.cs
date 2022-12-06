using Microsoft.AspNetCore.Mvc;
using MongoDB.MvcCore;

namespace OpenKamer.LogicControllers.Web;

public partial class WebController : ControllerBase
{
	[HttpGet]
	[Route("~/api/HelloWorld")]
	public async Task<IActionResult> HelloWorld()
	{
		// Forces a session cooky
		HttpContext.Session.SetString("Hello", "World");
		await HttpContext.Session.CommitAsync();


		var Version = $"MongoDB.MvcCore.BsonJsonSerializer: {typeof(BsonJsonSerializer).Assembly.GetName().Version})";

		return Ok(new
		{
			Version
		});
	}
}
