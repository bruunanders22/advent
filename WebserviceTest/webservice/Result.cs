using System;
using System.Globalization;
using System.Text.Json.Serialization;

public class Result
{
    [JsonPropertyName("Sum")]
    public double sum { get; set; }

    public Result(double _sum)
    {
        sum = _sum;
    }

}
