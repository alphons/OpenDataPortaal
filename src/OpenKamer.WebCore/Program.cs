//
// (c) 2022,2023 Alphons van der Heijden
//
// https://opendata.tweedekamer.nl/documentatie/
//

using MongoDB.Driver;
using MongoDB.MvcCore;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
	// the 'real' root of the application
	ContentRootPath = AppDomain.CurrentDomain.BaseDirectory
});

builder.Services
	.AddMvcCore()
	.WithMultiParameterModelBinding()
	.AddBsonJsonConverters(); // Serialization in API controller;

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

var mongoSection = builder.Configuration.GetSection("Mongo");

var mongoclient = new MongoClient(mongoSection["ConnectionString"]);

builder.Services.AddSingleton<IMongoClient>(mongoclient);

var db = mongoclient.GetDatabase(mongoSection["DbName"]);

builder.Services.AddSingleton<IMongoDatabase>(db);




var app = builder.Build();

app.UseRouting();

app.UseSession();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapControllers();

app.Run();
