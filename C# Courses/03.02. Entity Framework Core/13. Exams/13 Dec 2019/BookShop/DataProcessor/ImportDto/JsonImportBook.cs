namespace BookShop.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    public class JsonImportBook
    {
        [JsonProperty("Id")]
        public int? BookId { get; set; }
    }
}
