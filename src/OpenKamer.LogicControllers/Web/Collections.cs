
using Microsoft.AspNetCore.Mvc;

using nl.tweedekamer.opendata.DataModel;

using MongoDB.Driver;
using MongoDB.MvcCore;


namespace OpenKamer.LogicControllers.Web;

public partial class WebController : ControllerBase
{
	[HttpPost]
	[Route("~/api/ShowCollections")]
	public async Task<IActionResult> ShowCollections()
	{
		var List = await db.ListCollectionNames().ToListAsync();

		return Ok(new
		{
			List
		});
	}

	[HttpPost]
	[Route("~/api/ShowCollection")]
	public async Task<IActionResult> ShowCollection(string ColName)
	{
		object? List = null;
		switch (ColName)
		{
			default:
				List = await db.GetCollection(ColName).Find("{}").ToListAsync();
				break;
			case "commissieType":
				var commissies = await db.GetCollection<commissieType>(ColName).Find("{}").ToListAsync();
				List = commissies.Select(x => new
				{
					naam = x.naamNl,
					x.nummer,
					x.afkorting,
					x.soort
				}).ToList();
				break;
			case "zaalType":
				var list = await db.GetCollection<zaalType>(ColName).Find("{}").ToListAsync();
				List = list.Select(x => new { x.id, x.naam,  x.sysCode, x.bijgewerkt, x.verwijderd }).ToList();
				break;
			case "persoonType":
				var personen = await db.GetCollection<persoonType>(ColName).Find("{ functie: 'Tweede Kamerlid' }").ToListAsync();
				List = personen.Select(x => new
				{
					//x.id,
					x.titels,
					x.initialen,
					fullnaam = $"{x.roepnaam} {x.tussenvoegsel} {x.achternaam}",
					x.voornamen,
					geboortedatum = x.geboortedatum != null ? x.geboortedatum.Value.ToString("yyyy-MM-dd") : string.Empty,
					x.geboorteplaats,
					x.geboorteland,
					//x.overlijdensdatum,
					//x.overlijdensplaats,
					//x.functie,
					x.nummer,
					//x.geslacht,
					x.bijgewerkt,
					x.achternaam,
					//x.verwijderd 
				}).OrderBy(x => x.achternaam).ToList();
				break;
			case "fractieType":
				var fracties = await db.GetCollection<fractieType>(ColName).Find("{ 'aantalZetels' : { $gt : 0 } }").ToListAsync();
				List = fracties.Select(x => new
				{
					x.nummer,
					x.aantalZetels,
					x.afkorting,
					x.naamNl
				}).OrderByDescending(x => x.aantalZetels).ToList();
				break;
		}

		return Ok(new
		{
			List
		});
	}

}
