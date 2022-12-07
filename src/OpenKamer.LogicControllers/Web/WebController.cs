
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

namespace OpenKamer.LogicControllers.Web;

public partial class WebController : ControllerBase
{
	private readonly IMongoClient mongo;

	private readonly IMongoDatabase db;
	public WebController(IMongoClient mongo, IMongoDatabase db)
	{
		this.mongo = mongo;
		this.db = db;
	}
}
