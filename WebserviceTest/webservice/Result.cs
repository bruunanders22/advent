using System;
using System.Globalization;
using System.Text.Json.Serialization;


interface Operation
{
    double eval(double x, double y);
}

public class AddOp : Operation
{
    public double eval(double x, double y)
    {
        return x+y;
    }
}

public class Result
{
    [JsonPropertyName("Sum")]
    public double sum { get; set; }

    public Result(double _sum)
    {
        sum = _sum;
    }

}
