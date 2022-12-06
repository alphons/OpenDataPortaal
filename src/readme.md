# OpenKamer

Dit publieke .NET Core 7 project gebruikt het datamodel zoals te vinden is onder https://opendata.tweedekamer.nl/documentatie/

De XSD beschrijving is omgezet in C# classes, deze zijn te vinden onder OpenKamer.DataModel tkData-v1-0.cs

Een FeedController zorgt voor het overhalen van de data files volgens https://gegevensmagazijn.tweedekamer.nl/SyncFeed/2.0/ om deze vervolgens lokaal op te slaan (cache) op een filesysteem.

                        
![pretty print colored](https://raw.githubusercontent.com/alphons/OpenDataPortaal/master/blob/OpenKamer1.png)

Een EntityController leest de datafiles en slaat de Entiteiten op in een mongodb server.

![pretty print colored](https://raw.githubusercontent.com/alphons/OpenDataPortaal/master/blob/OpenKamer2.png)

Als proof-of-concept is een windows en een webinterface beschikbaar waarbij beschikbare data kan worden opgevraagd.


