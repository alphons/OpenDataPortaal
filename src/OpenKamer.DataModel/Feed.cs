//
// (c) 2022, Alphons van der Heijden
// alphons@heijden.com
//
// https://opendata.tweedekamer.nl/documentatie/
//

#nullable disable

namespace nl.tweedekamer.opendata.DataModel;

using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;

/// <remarks/>
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
[XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom", IsNullable = false)]
public partial class Feed
{
	[XmlElement("id")]
	public string Id { get; set; }

	[XmlElement("title")]
	public string Title { get; set; }

	[XmlElement("author")]
	public FeedAuthor Author { get; set; }

	[XmlElement("updated")]
	public DateTime Updated { get; set; }

	[XmlElement("link")]
	public FeedLink[] Links { get; set; }

	[XmlElement("rights")]
	public string Rights { get; set; }

	[XmlElement("entry")]
	public FeedEntry[] Entries { get; set; }
}

/// <remarks/>
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class FeedLink
{
	[XmlAttribute("rel")]
	public string Rel { get; set; }

	[XmlAttribute("href")]
	public string Href { get; set; }
}

/// <remarks/>
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class FeedAuthor
{
	[XmlElement("name")]
	public string Name { get; set; }

	[XmlElement("uri")]
	public string Uri { get; set; }

	[XmlElement("email")]
	public string Email { get; set; }
}

/// <remarks/>
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class FeedEntry
{
	[XmlElement("id")]
	public string Id { get; set; }

	[XmlElement("title")]
	public string Title { get; set; }

	[XmlElement("author")]
	public FeedEntryAuthor Author { get; set; }

	[XmlElement("updated")]
	public DateTime Updated { get; set; }

	[XmlElement("link")]
	public FeedLink Link { get; set; }

	[XmlElement("category")]
	public FeedEntryCategory Category { get; set; }

	[XmlAnyElement("content")]
	public XmlElement Content { get; set; }
}

/// <remarks/>
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class FeedEntryAuthor
{
	[XmlElement("name")]
	public string Name { get; set; }
}

/// <remarks/>
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class FeedEntryCategory
{
	[XmlAttribute(AttributeName ="term")]
	public string Term { get; set; }
}


