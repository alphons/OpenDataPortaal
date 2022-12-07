'use strict';

const Entities = $id("Entities");
const Output = $id("Output");
const TemplateList = $id("TemplateList");
const TemplateObjectProperties = $id("TemplateObjectProperties");
const TemplateMoties = $id("TemplateMoties");

(function ()
{
	PageEvents();
	Init();
})();

function PageEvents()
{
	document.addEventListener("click", function (e)
	{
		if (typeof window[e.target.id] === "function")
			window[e.target.id].call(e, e);
	});

	Entities.on("click", function (e)
	{
		var tr = e.target.parentElement;
		if (tr.tagName !== "TR")
			return;
		ShowCollection(tr.qsall('td')[1].innerText);
	});
}

function Init()
{
	HelloWorld();
}

function HelloWorld()
{
	netproxy("./api/HelloWorld", null, function ()
	{
		Output.innerText = this.Version;
	});

}


function ShowCollection(colName)
{
	netproxy("./api/ShowCollection", { ColName: colName }, function ()
	{
		Output.Template(TemplateObjectProperties, this, false);
	});
}


function ShowCollections()
{
	netproxy("./api/ShowCollections", {}, function ()
	{
		Output.Template(TemplateList, this, false);
	});
}

function Personen()
{
	netproxy("./api/Personen", {}, function ()
	{
		Output.Template(TemplateNevenfuncties, this, false);
	});
}

function Fracties()
{
	netproxy("./api/Fracties", {}, function ()
	{
		Output.Template(TemplateObjectProperties, this, false);
	});
}

function Moties()
{
	netproxy("./api/Moties", {}, function ()
	{
		Output.Template(TemplateObjectProperties, this, false);
	});
}
