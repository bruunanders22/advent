
public class AddOp
{
    public eval(double x, double y)
    {
        return x+y;
    }
}

public class AddParams
{
    public double X { get; set; }

    public double Y { get; set; }

    public string ToJson()
    {
        Result result = new Result(X + Y);
        string json  = System.Text.Json.JsonSerializer.Serialize<Result>(result);
        return json;
    }

    public static bool TryParse(string? value, IFormatProvider? provider, out AddParams addParam)
    {
        // Format is "(12.3,10.1)"
        var trimmedValue = value?.TrimStart('(').TrimEnd(')');
        var segments = trimmedValue?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (segments?.Length == 2
         && double.TryParse(segments[0], out var x)
         && double.TryParse(segments[1], out var y))
        {
            addParam = new AddParams { X = x, Y = y };
            return true;
        }

        addParam = new AddParams();
        return false;
    }
}
