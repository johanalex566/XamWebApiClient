using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XamWebApiClient.Models
{
    public class Book
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
