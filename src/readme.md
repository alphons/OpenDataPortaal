# OpenKamer

Dit publieke .NET Core 7 project gebruikt het datamodel zoals te vinden is onder https://opendata.tweedekamer.nl/documentatie/

De XSD beschrijving is omgezet in C# classes, deze zijn te vinden onder OpenKamer.DataModel tkData-v1-0.cs

Een FeedController zorgt voor het overhalen van de data files volgens https://gegevensmagazijn.tweedekamer.nl/SyncFeed/2.0/ om deze vervolgens lokaal op te slaan (cache) op een filesysteem.
                        
![FeedController](https://raw.githubusercontent.com/alphons/OpenDataPortaal/master/blob/OpenKamer1.png)

Een EntityController leest de datafiles en slaat de Entiteiten op in een mongodb server.

![EntityController](https://raw.githubusercontent.com/alphons/OpenDataPortaal/master/blob/OpenKamer2.png)

Na het importeren zijn dit de collecties binnen MongoDB

![MongDB Collections](https://raw.githubusercontent.com/alphons/OpenDataPortaal/master/blob/OpenKamer3.png)

Voorbeeld van een mongodb query:

```c#
[HttpPost]
[Route("~/api/Fracties")]
public async Task<IActionResult> Fracties()
{
	var query = @"
    [
        { $match: { verwijderd: false, 'aantalZetels' : { $gt : 0 } } },
        { 
            $project:
            {
		        _id: 0,
		        afko: '$afkorting',
		        naam: '$naamNl',
		        zetels: '$aantalZetels',
		        stemmen: '$aantalStemmen',
            }
        },
        {
	        $sort: { 'zetels' : -1, stemmen:-1  }
        },
        { $skip: 0 },
        { $limit: 50 }
    ]";
	var List = await db.GetCollection("fractieType").Aggregate(query).ToListAsync();

	return Ok(new
	{
		List
	});
}
```
Output (eerste 5):

```json
[
  {
    "afkorting": "VVD",
    "naam": "Volkspartij voor Vrijheid en Democratie",
    "zetels": 34,
    "stemmen": 2279130
  },
  {
    "afkorting": "D66",
    "naam": "Democraten 66",
    "zetels": 24,
    "stemmen": 1565861
  },
  {
    "afkorting": "PVV",
    "naam": "Partij voor de Vrijheid",
    "zetels": 17,
    "stemmen": 1124482
  },
  {
    "afkorting": "CDA",
    "naam": "Christen-Democratisch Appèl",
    "zetels": 14,
    "stemmen": 990601
  },
  {
    "afkorting": "SP",
    "naam": "Socialistische Partij",
    "zetels": 9,
    "stemmen": 623371
  }
]

```

Als proof-of-concept is een windows en een webinterface beschikbaar waarbij beschikbare data kan worden opgevraagd.

Voorbeeld fractieType:

![Fracties](https://raw.githubusercontent.com/alphons/OpenDataPortaal/master/blob/OpenKamer4.png)


