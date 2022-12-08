'use strict';

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

	Output.on("click", function (e)
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

function NewApi(url, datain, outputelement, templateelement, append)
{
	netproxy(url, datain, function ()
	{
		outputelement.Template(templateelement, this, append);
	});
}

function ShowCollection(colName)
{
	NewApi("./api/ShowCollection", { ColName: colName }, Output, TemplateObjectProperties, false);
}


function ShowCollections()
{
	NewApi("./api/ShowCollections", {}, Output, TemplateList, false);
}

function Personen()
{
	NewApi("./api/Personen", {}, Output, TemplateNevenfuncties, false);
}

function Fracties()
{
	NewApi("./api/Fracties", {}, Output, TemplateObjectProperties, false);
}

function Documenten()
{
	NewApi("./api/Documenten", { search: "Wilders" }, Output, TemplateObjectProperties, false);
}
