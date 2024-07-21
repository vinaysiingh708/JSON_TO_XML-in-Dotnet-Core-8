// Controllers/XmlController.cs
using Microsoft.AspNetCore.Mvc;
using JSON_TO_XML.Services.Interface;

[ApiController]
[Route("api/[controller]")]
public class XmlController : ControllerBase
{
    private readonly IJsonToXmlConverterService _jsonToXmlConverterService;

    public XmlController(IJsonToXmlConverterService jsonToXmlConverterService)
    {
        _jsonToXmlConverterService = jsonToXmlConverterService;
    }

    [HttpGet("convert")]
    public async Task<IActionResult> ConvertJsonToXml([FromQuery] string url)
    {
        var xml = await _jsonToXmlConverterService.ConvertJsonToXmlAsync(url);

        return Content(xml, "application/xml");
    }
}
