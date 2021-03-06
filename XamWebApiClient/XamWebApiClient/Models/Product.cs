using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XamWebApiClient.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("ProductValue")]
        public decimal ProductValue { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("Quantity")]
        public string Quantity { get; set; }
    }
}
