     __                 
    /  \        _____________________ 
    |  |       /                     \
    @  @       | Welcome, Stranger!  |
    || ||      | I'm here to make    |
    || ||   <--| your life of coding |
    |\_/|      | a little easier.    |
    \___/      \_____________________/

Clippy is a collection of extension methods for Microsoft .NET.
================================================================
Clippy contains a (hopefully increasing) number of simple extensions and short hand methods
that is supposed to shorten the amount of code you need to write while coding in
.NET.

This readme contains a catalogue of the extensions, but more example and usage can be found in
the tests.

Clippy
------
Contains extension methods for Core .NET types like `String`, `IEnumerable` etc.

### Caching

    // Short hand for clearing an entire MemoryCache object.
    MemoryCache.Default.Clear();

### Core 
#### String

    "&gt;div&lt;".HtmlDecode(); // => "<div>"
	
	"<h1>Hello</h1>".StripHtml(); // => "Hello"
	
	"/quagmire"
		.AddQueryStringParameter("foo", "no")
		.AddQueryStringParameter("bar", "yes"); // => "/quagmire?foo=no&bar=yes"
	
	"brian".ToFirstUpper(); // => "Brian"
	
	"  ".IsNullOrWhiteSpace(); // => true
	
	"hello".Reverse(); // => "olleh"

	"http://www.github.com".IsValidUrl(); // => true

	"Not Suîtable For Å slug".ToSlug(); // => "not-suitable-for-a-slug"

	"Most certainly a way to long string".Truncate(20); // => "Most certainly a wa..."
	"Most certainly a way to long string".Truncate(20, cutInWhitespace: true); // => "Most certainly a..."
    

Clippy Mvc
----------
Contains extensions or helpers for ASP.NET MVC. 

### ActionResults
Contains extra ActionResults.

#### JsonOrJsonpResult
A simple ActionResult to use instead of the regular JsonResult that have a couple of advantages. 

1. Renders JSONP if the request contains a "callback" parameter else regular JSON.
2. Uses Newtonsoft.Json and let's you tap into the serialization process and add custom JsonConverters, etc.

ex. 

    return new JsonOrJsonpResult 
	{
		Data = new { message = "this could be anything", something = somepossiblenullobject },
		SerializationSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include
	} 

### Helpers
Contains extensions for HtmlHelper.

### GravatarHelper
TODO: Write this

Collaboration
-------------
We want pull requests! :)