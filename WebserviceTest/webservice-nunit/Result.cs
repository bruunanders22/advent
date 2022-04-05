using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public class Result
    {
        [JsonPropertyName("Sum")]
        public float sum { get; set; }
    }
}
