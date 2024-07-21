namespace JSON_TO_XML.Services.Interface
{
    public interface IJsonToXmlConverterService
    {
        Task<string> ConvertJsonToXmlAsync(string url);
    }
}
