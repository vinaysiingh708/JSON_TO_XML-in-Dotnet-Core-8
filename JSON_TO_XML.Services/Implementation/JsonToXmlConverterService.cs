// Services/JsonToXmlConverterService.cs
using System.Xml;
using System.Xml.Serialization;
using JSON_TO_XML.Services.Interface;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using System.Text;

public class JsonToXmlConverterService : IJsonToXmlConverterService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public JsonToXmlConverterService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    //  
    public async Task<string> ConvertJsonToXmlAsync(string url)
    {
        var BaseUrl = _configuration["BaseUrl"];
               
        // Deserialize JSON to.NET object
        //GetFromJsonAsync is a method used in C# with the HttpClient class in .NET, specifically within the System.Net.Http.Json
        //namespace. It simplifies the process of sending an HTTP GET request and deserializing the JSON response into a .NET object.
        var deserializeObject = await  _httpClient.GetFromJsonAsync<NewsStory>(BaseUrl);        

        // Serialize .NET object to XML
        var xmlSerializer = new XmlSerializer(typeof(NewsStory));
        using var stringWriter = new StringWriter();
        using var writer = XmlWriter.Create(stringWriter);
        xmlSerializer.Serialize(writer, deserializeObject);

        return stringWriter.ToString();
    }
}
