//
// (c) 2022, Alphons van der Heijden
// alphons@heijden.com
//
// https://opendata.tweedekamer.nl/documentatie/
//


// Produced by: xsd tkData-v1-0.xsd and edited (a lot)
//
// id and ref are Guid
//
// tokenType => string
// stringType => string
//
// datumType => string
//
// dateType => DateTime
// dateTimeType => DateTime
//
// geslachtField => string
// geslacht => string
// activiteitTypeVrsNummer => string
//
// vergaderjaarType => string
//
// base64BinaryType => byte[]
//
// booleanType => bool
//
// usignedIntType => uint
// intType => int
//
//
// [XmlElement("annotatie")]
// [JsonIgnore]
//
// [XmlAttribute("id")]
// [JsonPropertyName("_id")]   // shortcut for mongodb
//
// [XmlElement(IsNullable = true)] => Nullable<T>
//


namespace nl.tweedekamer.opendata.DataModel;

#nullable disable

#pragma warning disable IDE1006

using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("persoon", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class persoonType : downloadEntiteitType
{
	public string nummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string titels { get; set; }

	[XmlElement(IsNullable = true)]
	public string initialen { get; set; }

	[XmlElement(IsNullable = true)]
	public string tussenvoegsel { get; set; }

	[XmlElement(IsNullable = true)]
	public string achternaam { get; set; }

	[XmlElement(IsNullable = true)]
	public string voornamen { get; set; }

	[XmlElement(IsNullable = true)]
	public string roepnaam { get; set; }

	[XmlElement(IsNullable = true)]
	public string geslacht { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> geboortedatum { get; set; }

	[XmlElement(IsNullable = true)]
	public string geboorteplaats { get; set; }

	[XmlElement(IsNullable = true)]
	public string geboorteland { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> overlijdensdatum { get; set; }

	[XmlElement(IsNullable = true)]
	public string overlijdensplaats { get; set; }

	[XmlElement(IsNullable = true)]
	public string woonplaats { get; set; }

	[XmlElement(IsNullable = true)]
	public string land { get; set; }

	[XmlElement(IsNullable = true)]
	public string fractielabel { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
public partial class relatieType
{
	[XmlAttribute("id")]
	[JsonPropertyName("_id")] // shortcut for mongo
	public string id { get; set; }

	[XmlAttribute("ref")]
	[JsonPropertyName("ref")]
	public string @ref { get; set; }
}

[XmlInclude(typeof(referentieType))]

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
public partial class referentieLiteral
{
	[XmlElement("annotatie")]
	[JsonIgnore]
	public object[] annotatie { get; set; }

	[XmlAttribute("ref")]
	public Guid @ref { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
public partial class referentieType : referentieLiteral
{
}

[XmlInclude(typeof(resourceType))]
[XmlInclude(typeof(entiteitType))]
[XmlInclude(typeof(zaakActorType))]
[XmlInclude(typeof(zaakType))]
[XmlInclude(typeof(vergaderingType))]
[XmlInclude(typeof(reserveringType))]
[XmlInclude(typeof(zaalType))]
[XmlInclude(typeof(kamerstukdossierType))]
[XmlInclude(typeof(documentVersieType))]
[XmlInclude(typeof(documentActorType))]
[XmlInclude(typeof(stemmingType))]
[XmlInclude(typeof(besluitType))]
[XmlInclude(typeof(agendapuntType))]
[XmlInclude(typeof(activiteitActorType))]
[XmlInclude(typeof(activiteitType))]
[XmlInclude(typeof(fractieZetelVacatureType))]
[XmlInclude(typeof(fractieZetelPersoonType))]
[XmlInclude(typeof(fractieZetelType))]
[XmlInclude(typeof(fractieAanvullendGegevenType))]
[XmlInclude(typeof(commissieZetelVervangerVacatureType))]
[XmlInclude(typeof(commissieZetelVervangerPersoonType))]
[XmlInclude(typeof(commissieZetelVastVacatureType))]
[XmlInclude(typeof(commissieZetelVastPersoonType))]
[XmlInclude(typeof(commissieZetelType))]
[XmlInclude(typeof(commissieContactinformatieType))]
[XmlInclude(typeof(commissieType))]
[XmlInclude(typeof(persoonReisType))]
[XmlInclude(typeof(persoonOnderwijsType))]
[XmlInclude(typeof(persoonNevenfunctieInkomstenType))]
[XmlInclude(typeof(persoonNevenfunctieType))]
[XmlInclude(typeof(persoonLoopbaanType))]
[XmlInclude(typeof(persoonGeschenkType))]
[XmlInclude(typeof(persoonContactinformatieType))]
[XmlInclude(typeof(downloadEntiteitType))]
[XmlInclude(typeof(verslagType))]
[XmlInclude(typeof(documentType))]
[XmlInclude(typeof(fractieType))]
[XmlInclude(typeof(persoonType))]

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
public partial class identificatieType
{

	[XmlElement("annotatie")]
	[JsonIgnore]
	public object[] annotatie { get; set; }

	[XmlAttribute("id")]
	[JsonPropertyName("_id")]   // shortcut for mongo

	public Guid id { get; set; }
}

[XmlInclude(typeof(zaakActorType))]
[XmlInclude(typeof(zaakType))]
[XmlInclude(typeof(vergaderingType))]
[XmlInclude(typeof(reserveringType))]
[XmlInclude(typeof(zaalType))]
[XmlInclude(typeof(kamerstukdossierType))]
[XmlInclude(typeof(documentVersieType))]
[XmlInclude(typeof(documentActorType))]
[XmlInclude(typeof(stemmingType))]
[XmlInclude(typeof(besluitType))]
[XmlInclude(typeof(agendapuntType))]
[XmlInclude(typeof(activiteitActorType))]
[XmlInclude(typeof(activiteitType))]
[XmlInclude(typeof(fractieZetelVacatureType))]
[XmlInclude(typeof(fractieZetelPersoonType))]
[XmlInclude(typeof(fractieZetelType))]
[XmlInclude(typeof(fractieAanvullendGegevenType))]
[XmlInclude(typeof(commissieZetelVervangerVacatureType))]
[XmlInclude(typeof(commissieZetelVervangerPersoonType))]
[XmlInclude(typeof(commissieZetelVastVacatureType))]
[XmlInclude(typeof(commissieZetelVastPersoonType))]
[XmlInclude(typeof(commissieZetelType))]
[XmlInclude(typeof(commissieContactinformatieType))]
[XmlInclude(typeof(commissieType))]
[XmlInclude(typeof(persoonReisType))]
[XmlInclude(typeof(persoonOnderwijsType))]
[XmlInclude(typeof(persoonNevenfunctieInkomstenType))]
[XmlInclude(typeof(persoonNevenfunctieType))]
[XmlInclude(typeof(persoonLoopbaanType))]
[XmlInclude(typeof(persoonGeschenkType))]
[XmlInclude(typeof(persoonContactinformatieType))]
[XmlInclude(typeof(downloadEntiteitType))]
[XmlInclude(typeof(verslagType))]
[XmlInclude(typeof(documentType))]
[XmlInclude(typeof(fractieType))]
[XmlInclude(typeof(persoonType))]

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
public abstract partial class entiteitType : identificatieType
{
	[XmlAttribute(Form = XmlSchemaForm.Qualified)]
	public bool verwijderd { get; set; }

	[XmlAttribute(Form = XmlSchemaForm.Qualified)]
	public DateTime bijgewerkt { get; set; }

}

[XmlInclude(typeof(verslagType))]
[XmlInclude(typeof(documentType))]
[XmlInclude(typeof(fractieType))]
[XmlInclude(typeof(persoonType))]

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
public abstract partial class downloadEntiteitType : entiteitType
{
	[XmlAttribute(Form = XmlSchemaForm.Qualified)]
	public string contentType { get; set; }

	[XmlAttribute(Form = XmlSchemaForm.Qualified)]
	public int contentLength { get; set; }

	[XmlIgnore()]
	public bool contentLengthSpecified { get; set; }

}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("persoonContactinformatie", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class persoonContactinformatieType : entiteitType
{
	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public string waarde { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("persoonGeschenk", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class persoonGeschenkType : entiteitType
{
	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string omschrijving { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datum { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }

}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("persoonLoopbaan", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class persoonLoopbaanType : entiteitType
{
	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public string werkgever { get; set; }

	[XmlElement(IsNullable = true)]
	public string omschrijvingNl { get; set; }

	[XmlElement(IsNullable = true)]
	public string omschrijvingEn { get; set; }

	[XmlElement(IsNullable = true)]
	public string plaats { get; set; }

	[XmlElement(IsNullable = true)]
	public string van { get; set; }

	[XmlElement(IsNullable = true)]
	public string totEnMet { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("persoonNevenfunctie", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class persoonNevenfunctieType : entiteitType
{

	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string omschrijving { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<bool> isActief { get; set; }

	[XmlElement(IsNullable = true)]
	public persoonNevenfunctieTypePeriode periode { get; set; }

	[XmlElement(IsNullable = true)]
	public persoonNevenfunctieTypeVergoeding vergoeding { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }

}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
public partial class persoonNevenfunctieTypePeriode
{
	[XmlElement(IsNullable = true)]
	public string van { get; set; }

	[XmlElement(IsNullable = true)]
	public string totEnMet { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
public partial class persoonNevenfunctieTypeVergoeding
{
	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public string toelichting { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("persoonNevenfunctieInkomsten", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class persoonNevenfunctieInkomstenType : entiteitType
{
	public referentieLiteral persoonNevenfunctie { get; set; }

	[XmlElement(IsNullable = true)]
	public string jaar { get; set; }

	[XmlElement(IsNullable = true)]
	public string bedragSoort { get; set; }

	[XmlElement(IsNullable = true)]
	public string bedragVoorvoegsel { get; set; }

	[XmlElement(IsNullable = true)]
	public string bedragValuta { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<decimal> bedrag { get; set; }

	[XmlIgnore()]
	public bool bedragSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public string bedragAchtervoegsel { get; set; }

	[XmlElement(IsNullable = true)]
	public string frequentie { get; set; }

	[XmlElement(IsNullable = true)]
	public string frequentieBeschrijving { get; set; }

	[XmlElement(IsNullable = true)]
	public string opmerking { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("persoonOnderwijs", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class persoonOnderwijsType : entiteitType
{
	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string opleidingNl { get; set; }

	[XmlElement(IsNullable = true)]
	public string opleidingEn { get; set; }

	[XmlElement(IsNullable = true)]
	public string instelling { get; set; }

	[XmlElement(IsNullable = true)]
	public string plaats { get; set; }

	[XmlElement(IsNullable = true)]
	public string van { get; set; }

	[XmlElement(IsNullable = true)]
	public string totEnMet { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("persoonReis", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class persoonReisType : entiteitType
{

	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string doel { get; set; }

	[XmlElement(IsNullable = true)]
	public string bestemming { get; set; }

	[XmlElement(IsNullable = true)]
	public string van { get; set; }

	[XmlElement(IsNullable = true)]
	public string totEnMet { get; set; }

	[XmlElement(IsNullable = true)]
	public string betaaldDoor { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("commissie", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class commissieType : entiteitType
{

	public string nummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public string afkorting { get; set; }

	[XmlElement(IsNullable = true)]
	public string naamNl { get; set; }

	[XmlElement(IsNullable = true)]
	public string naamEn { get; set; }

	[XmlElement(IsNullable = true)]
	public string naamWebNl { get; set; }

	[XmlElement(IsNullable = true)]
	public string naamWebEn { get; set; }

	[XmlElement(IsNullable = true)]
	public string inhoudsopgave { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumActief { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumInactief { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("commissieContactinformatie", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class commissieContactinformatieType : entiteitType
{

	public referentieLiteral commissie { get; set; }

	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public string waarde { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("commissieZetel", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class commissieZetelType : entiteitType
{

	public referentieLiteral commissie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("commissieZetelVastPersoon", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class commissieZetelVastPersoonType : entiteitType
{

	public referentieLiteral commissieZetel { get; set; }

	[XmlElement(IsNullable = true)]
	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> van { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> totEnMet { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("commissieZetelVastVacature", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class commissieZetelVastVacatureType : entiteitType
{

	public referentieLiteral commissieZetel { get; set; }

	[XmlElement(IsNullable = true)]
	public referentieLiteral fractie { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> van { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> totEnMet { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("commissieZetelVervangerPersoon", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class commissieZetelVervangerPersoonType : entiteitType
{

	public referentieLiteral commissieZetel { get; set; }

	[XmlElement(IsNullable = true)]
	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> van { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> totEnMet { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("commissieZetelVervangerVacature", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class commissieZetelVervangerVacatureType : entiteitType
{

	public referentieLiteral commissieZetel { get; set; }

	[XmlElement(IsNullable = true)]
	public referentieLiteral fractie { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> van { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> totEnMet { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("fractie", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class fractieType : downloadEntiteitType
{

	public string nummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string afkorting { get; set; }

	[XmlElement(IsNullable = true)]
	public string naamNl { get; set; }

	[XmlElement(IsNullable = true)]
	public string naamEn { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<uint> aantalZetels { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<uint> aantalStemmen { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumActief { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumInactief { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("fractieAanvullendGegeven", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class fractieAanvullendGegevenType : entiteitType
{

	public referentieLiteral fractie { get; set; }

	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public string waarde { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("fractieZetel", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class fractieZetelType : entiteitType
{

	public referentieLiteral fractie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> gewicht { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("fractieZetelPersoon", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class fractieZetelPersoonType : entiteitType
{

	public referentieLiteral fractieZetel { get; set; }

	public referentieLiteral persoon { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> van { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> totEnMet { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("fractieZetelVacature", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class fractieZetelVacatureType : entiteitType
{

	public referentieLiteral fractieZetel { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> van { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> totEnMet { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("activiteit", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class activiteitType : entiteitType
{

	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public string nummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string onderwerp { get; set; }

	[XmlElement(IsNullable = true)]
	public string datumSoort { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datum { get; set; }

	[XmlIgnore()]
	public bool datumSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> aanvangstijd { get; set; }

	[XmlIgnore()]
	public bool aanvangstijdSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> eindtijd { get; set; }

	[XmlIgnore()]
	public bool eindtijdSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public string locatie { get; set; }

	public bool besloten { get; set; }

	public string status { get; set; }

	[XmlElement(IsNullable = true)]
	public string vergaderjaar { get; set; }

	public string kamer { get; set; }

	[XmlElement(IsNullable = true)]
	public string noot { get; set; }

	[XmlElement(IsNullable = true)]
	public string vrsNummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string sidVoortouw { get; set; }

	[XmlElement(IsNullable = true)]
	public string voortouwnaam { get; set; }

	[XmlElement(IsNullable = true)]
	public string voortouwafkorting { get; set; }

	[XmlElement(IsNullable = true)]
	public string voortouwkortenaam { get; set; }

	public referentieLiteral voortouwcommissie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> aanvraagdatum { get; set; }

	[XmlIgnore()]
	public bool aanvraagdatumSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumVerzoekEersteVerlenging { get; set; }

	[XmlIgnore()]
	public bool datumVerzoekEersteVerlengingSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumMededelingEersteVerlenging { get; set; }

	[XmlIgnore()]
	public bool datumMededelingEersteVerlengingSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumVerzoekTweedeVerlenging { get; set; }

	[XmlIgnore()]
	public bool datumVerzoekTweedeVerlengingSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumMededelingTweedeVerlenging { get; set; }

	[XmlIgnore()]
	public bool datumMededelingTweedeVerlengingSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> vervaldatum { get; set; }

	[XmlIgnore()]
	public bool vervaldatumSpecified { get; set; }

	public referentieLiteral voortgezetVanuit { get; set; }

	public referentieLiteral vervangenVanuit { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("activiteitActor", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class activiteitActorType : entiteitType
{
	public referentieLiteral activiteit { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorNaam { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorFractie { get; set; }

	[XmlElement(IsNullable = true)]
	public string relatie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<uint> volgorde { get; set; }

	[XmlIgnore()]
	public bool volgordeSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public string spreektijd { get; set; }

	[XmlElement(IsNullable = true)]
	public string sidActor { get; set; }

	public referentieLiteral persoon { get; set; }

	public referentieLiteral fractie { get; set; }

	public referentieLiteral commissie { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("agendapunt", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class agendapuntType : entiteitType
{
	public referentieLiteral activiteit { get; set; }

	[XmlElement(IsNullable = true)]
	public string nummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string onderwerp { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> aanvangstijd { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> eindtijd { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<uint> volgorde { get; set; }

	[XmlElement(IsNullable = true)]
	public string rubriek { get; set; }

	[XmlElement(IsNullable = true)]
	public string noot { get; set; }

	[XmlElement(IsNullable = true)]
	public string status { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("besluit", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class besluitType : entiteitType
{

	public referentieLiteral agendapunt { get; set; }

	[XmlElement(IsNullable = true)]
	public string stemmingsSoort { get; set; }

	[XmlElement(IsNullable = true)]
	public string besluitSoort { get; set; }

	[XmlElement(IsNullable = true)]
	public string besluitTekst { get; set; }

	[XmlElement(IsNullable = true)]
	public string opmerking { get; set; }

	[XmlElement(IsNullable = true)]
	public string status { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> agendapuntZaakBesluitVolgorde { get; set; }

	[XmlElement("zaak")]
	public referentieLiteral[] zaak { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("stemming", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class stemmingType : entiteitType
{

	public referentieLiteral besluit { get; set; }

	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<uint> fractieGrootte { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorNaam { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorFractie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<bool> vergissing { get; set; }

	[XmlElement(IsNullable = true)]
	public string sidActorLid { get; set; }

	[XmlElement(IsNullable = true)]
	public string sidActorFractie { get; set; }

	public referentieType persoon { get; set; }

	public referentieType fractie { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("document", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class documentType : downloadEntiteitType
{


	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	public string documentNummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string titel { get; set; }

	public string onderwerp { get; set; }

	public DateTime datum { get; set; }

	[XmlIgnore()] // Is this correct????
	public bool datumSpecified { get; set; }

	public int volgnummer { get; set; }

	public string vergaderjaar { get; set; }

	public int kamer { get; set; }

	[XmlElement(IsNullable = true)]
	public string citeertitel { get; set; }

	[XmlElement(IsNullable = true)]
	public string alias { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumRegistratie { get; set; }

	[XmlIgnore()] // Is this correct?
	public bool datumRegistratieSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datumOntvangst { get; set; }

	[XmlIgnore()]
	public bool datumOntvangstSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public string aanhangselnummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string kenmerkAfzender { get; set; }

	[XmlElement(IsNullable = true)]
	public referentieLiteral huidigeDocumentVersie { get; set; }

	[XmlElement("bronDocument")]
	public referentieLiteral[] bronDocument { get; set; }

	[XmlElement("activiteit")]
	public referentieLiteral[] activiteit { get; set; }

	[XmlElement("agendapunt")]
	public referentieLiteral[] agendapunt { get; set; }

	[XmlElement("zaak")]
	public referentieLiteral[] zaak { get; set; }

	public referentieLiteral kamerstukdossier { get; set; }

	public string organisatie { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("documentActor", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class documentActorType : entiteitType
{

	public referentieLiteral document { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorNaam { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorFractie { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public string relatie { get; set; }

	[XmlElement(IsNullable = true)]
	public string sidActor { get; set; }

	public referentieLiteral persoon { get; set; }

	public referentieLiteral fractie { get; set; }

	public referentieLiteral commissie { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("documentVersie", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class documentVersieType : entiteitType
{

	public referentieLiteral document { get; set; }

	[XmlElement(IsNullable = true)]
	public string status { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<uint> versienummer { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<uint> bestandsgrootte { get; set; }

	[XmlElement(IsNullable = true)]
	public string extensie { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datum { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("kamerstukdossier", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class kamerstukdossierType : entiteitType
{

	[XmlElement(IsNullable = true)]
	public string titel { get; set; }

	[XmlElement(IsNullable = true)]
	public string citeertitel { get; set; }

	[XmlElement(IsNullable = true)]
	public string alias { get; set; }

	public uint nummer { get; set; }

	[XmlIgnore()]
	public bool nummerSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public string toevoeging { get; set; }

	public int hoogsteVolgnummer { get; set; }

	[XmlIgnore()]
	public bool hoogsteVolgnummerSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<bool> afgesloten { get; set; }

	[XmlElement(IsNullable = true)]
	public string kamer { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("zaal", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class zaalType : entiteitType
{

	public string naam { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> sysCode { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("reservering", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class reserveringType : entiteitType
{

	[XmlElement(IsNullable = true)]
	public string nummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string statusCode { get; set; }

	[XmlElement(IsNullable = true)]
	public string statusNaam { get; set; }

	[XmlElement(IsNullable = true)]
	public string activiteitNummer { get; set; }

	public referentieLiteral zaal { get; set; }

	[XmlElement("activiteit")]
	public referentieLiteral[] activiteit { get; set; }
}


[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("vergadering", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class vergaderingType : entiteitType
{
	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public string titel { get; set; }

	[XmlElement(IsNullable = true)]
	public string zaal { get; set; }

	[XmlElement(IsNullable = true)]
	public string vergaderjaar { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<uint> vergaderingNummer { get; set; }

	[XmlIgnore()]
	public bool vergaderingNummerSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> datum { get; set; }

	[XmlIgnore()]
	public bool datumSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> aanvangstijd { get; set; }

	[XmlIgnore()]
	public bool aanvangstijdSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> sluiting { get; set; }

	[XmlIgnore()]
	public bool sluitingSpecified { get; set; }

	[XmlElement(IsNullable = true)]
	public string kamer { get; set; }

}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("verslag", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class verslagType : downloadEntiteitType
{
	public referentieLiteral vergadering { get; set; }

	[XmlElement(IsNullable = true)]
	public string soort { get; set; }

	[XmlElement(IsNullable = true)]
	public string status { get; set; }

}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("zaak", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class zaakType : entiteitType
{
	public string nummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string soort { get; set; }
	public string onderwerp { get; set; }
	public DateTime gestartOp { get; set; }

	[XmlElement(IsNullable = true)]
	public string organisatie { get; set; }

	[XmlElement(IsNullable = true)]
	public string titel { get; set; }

	[XmlElement(IsNullable = true)]
	public string citeertitel { get; set; }

	[XmlElement(IsNullable = true)]
	public string alias { get; set; }

	[XmlElement(IsNullable = true)]
	public string grondslagvoorhang { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<DateTime> termijn { get; set; }
	public string vergaderjaar { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<int> volgnummer { get; set; }

	[XmlElement(IsNullable = true)]
	public string status { get; set; }

	[XmlElement(IsNullable = true)]
	public string huidigeBehandelstatus { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<bool> afgedaan { get; set; }

	[XmlElement(IsNullable = true)]
	public Nullable<bool> grootProject { get; set; }

	[XmlElement(IsNullable = true)]
	public string kabinetsappreciatie { get; set; }
	public referentieLiteral kamerstukdossier { get; set; }

	[XmlElement("activiteit")]
	public referentieLiteral[] activiteit { get; set; }

	[XmlElement("agendapunt")]
	public referentieLiteral[] agendapunt { get; set; }

	[XmlElement("gerelateerdVanuit")]
	public referentieLiteral[] gerelateerdVanuit { get; set; }

	[XmlElement("vervangenVanuit")]
	public referentieLiteral[] vervangenVanuit { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("zaakActor", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class zaakActorType : entiteitType
{
	public referentieLiteral zaak { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorNaam { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorFractie { get; set; }

	[XmlElement(IsNullable = true)]
	public string actorAfkorting { get; set; }

	[XmlElement(IsNullable = true)]
	public string functie { get; set; }

	[XmlElement(IsNullable = true)]
	public string relatie { get; set; }

	[XmlElement(IsNullable = true)]
	public string sidActor { get; set; }
	public referentieLiteral persoon { get; set; }
	public referentieLiteral fractie { get; set; }
	public referentieLiteral commissie { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("resource", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class resourceType : identificatieType
{
	[XmlElement(IsNullable = true)]
	public byte[] bytes { get; set; }
}

[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0")]
[XmlRoot("identiteit", Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IsNullable = false)]
public partial class identiteitType
{
	[XmlElement("bron", typeof(string), DataType = "token")]
	[XmlElement("sleutel", typeof(string), DataType = "token")]
	[XmlChoiceIdentifier("ItemsElementName")]
	public string[] Items { get; set; }

	[XmlElement("ItemsElementName")]
	[XmlIgnore()]
	public ItemsChoiceType[] ItemsElementName { get; set; }

	[XmlAttribute()]
	public string aanduiding { get; set; }
}

[Serializable()]
[XmlType(Namespace = "http://www.tweedekamer.nl/xsd/tkData/v1-0", IncludeInSchema = false)]
public enum ItemsChoiceType
{
	bron,
	sleutel,
}

#pragma warning restore IDE1006

