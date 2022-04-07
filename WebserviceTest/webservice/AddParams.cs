

public class BinaryParams
{
    public double X { get; set; }

    public double Y { get; set; }

    Operation op;

    BinaryParams(Operation _op)
    {
        op = _op;
    }

    public string ToJson()
    {
        // Result result = new Result(X + Y);
        Op result = op.Eval(X,Y);
        // return result.ToJson();
        return System.Text.Json.JsonSerializer.Serialize<Op>(result);
    }

    public static bool TryParse(string? value, IFormatProvider? provider, out BinaryParams binaryParams)
    {
        // Format is "(12.3,10.1)"
        var trimmedValue = value?.TrimStart('(').TrimEnd(')');
        var segments = trimmedValue?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (segments?.Length == 2
         && double.TryParse(segments[0], out var x)
         && double.TryParse(segments[1], out var y))
        {
            binaryParams = new BinaryParams { X = x, Y = y };
            return true;
        }

        binaryParams = new BinaryParams();
        return false;
    }
}
