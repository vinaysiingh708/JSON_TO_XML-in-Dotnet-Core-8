// Services/JsonToXmlConverterService.cs
using System.Xml;
using System.Xml.Serialization;
using JSON_TO_XML.Services.Interface;
using System.Net.Http.Json;

public class JsonToXmlConverterService : IJsonToXmlConverterService
{
    private readonly HttpClient _httpClient;

    public JsonToXmlConverterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //  
    public async Task<string> ConvertJsonToXmlAsync(string url)
    {
      var  BaseUrl = "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
        // Fetch JSON data from third-party API                
        var jsonData = "https://hacker-news.firebaseio.com/v0/item/41002195.json?print=pretty";

        // Deserialize JSON to.NET object
        var deserializeObject = await  _httpClient.GetFromJsonAsync<NewsStory>(jsonData);        

        // Serialize .NET object to XML
        var xmlSerializer = new XmlSerializer(typeof(NewsStory));
        using var stringWriter = new StringWriter();
        using var writer = XmlWriter.Create(stringWriter);
        xmlSerializer.Serialize(writer, deserializeObject);

        return stringWriter.ToString();
    }
}
