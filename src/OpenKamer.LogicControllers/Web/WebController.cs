
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

namespace OpenKamer.LogicControllers.Web;

public partial class WebController : ControllerBase
{
	private readonly IMongoDatabase db;
	public WebController(IMongoDatabase db)
	{
		this.db = db;
	}
}
