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
	Moties2();
}

function HelloWorld()
{
	netproxy("./api/HelloWorld", null, function ()
	{
		Version.innerText = this.Version;
	});

}

function Moties2()
{
	netproxy("./api/Moties2", {}, function ()
	{
		Output.Template(TemplateMoties, this, false);
	});
}

function MotiesCached()
{
	netproxy("./api/MotiesCached", {}, function ()
	{
		Output.Template(TemplateMoties, this, false);
	});
}
