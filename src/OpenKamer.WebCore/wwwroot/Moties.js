'use strict';

const Output = $id("Output");
const Version = $id("Version");
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

	$id("UseCache").on("click", function (e)
	{
		if ($id("UseCache").checked)
			MotiesCached();
		else
			Moties2();
	});
}

function Init()
{
	HelloWorld();
	Moties();
}

function NewApi(url, datain, outputelement, templateelement, append)
{
	netproxy(url, datain, function ()
	{
		outputelement.Template(templateelement, this, append);
	});
}

function HelloWorld()
{
	netproxy("./api/HelloWorld", null, function ()
	{
		Version.innerText = this.Version;
	});

}

function Moties()
{
	NewApi("./api/Moties", {}, Output, TemplateMoties, false);
}

function MotiesCached()
{
	NewApi("./api/MotiesCached", {}, Output, TemplateMoties, false);
}
