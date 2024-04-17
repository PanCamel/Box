using System.Globalization;

namespace Pudelko;

public enum UnitOfMeasure
{
    Milimeter,
    Centimeter,
    Meter
}

public class Pudelko: IFormattable
{
    private double[] dimensions = new double[3] { 0.1, 0.1, 0.1 };


    private double A => dimensions[0];
    private double B => dimensions[1];
    private double C => dimensions[2];
    
    public double Objetosc => Math.Round(A * B * C, 9);
    public double Pole => Math.Round(2 * (A * B + B * C + A * C), 6);
    
    public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.Meter)
    {
        ValidateDimensions(a, b, c);
        ConvertToMeters(a, b, c, unit);
    }
       
    private void ValidateDimensions(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            throw new ArgumentOutOfRangeException("Wymiary muszą być większe od 0");
        }
    }

    private void ConvertToMeters(double a, double b, double c, UnitOfMeasure unit)
    {
        if (unit == UnitOfMeasure.Centimeter)
        {
            a /= 100;
            b /= 100;
            c /= 100;
        }
        else if (unit == UnitOfMeasure.Milimeter)
        {
            a /= 1000;
            b /= 1000;
            c /= 1000;
        }
        dimensions = new double[] { a, b, c };
    }
    public override string ToString()
    {
        return ToString("m", CultureInfo.InvariantCulture);
    }

    

    public string ToString(string format, IFormatProvider formatProvider)
    {
        switch (format)
        {
            case "m":
                return
                    $"{A.ToString("0.000", formatProvider)} m × {B.ToString("0.000", formatProvider)} m × {C.ToString("0.000", formatProvider)} m";
            case "cm":
                return
                    $"{(A * 100).ToString("0.0", formatProvider)} cm × {(B * 100).ToString("0.0", formatProvider)} cm × {(C * 100).ToString("0.0", formatProvider)} cm";
            case "mm":
                return
                    $"{(A * 1000).ToString("0", formatProvider)} mm × {(B * 1000).ToString("0", formatProvider)} mm × {(C * 1000).ToString("0", formatProvider)} mm";
            default:
                throw new FormatException("Invalid format.");
        }
    }
}