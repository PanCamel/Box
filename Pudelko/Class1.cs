namespace Pudelko;

public enum UnitOfMeasure
{
    Milimeter,
    Centimeter,
    Meter
}
public class Pudelko

{
    private double[] dimensions = new double[3] { 0.1, 0.1, 0.1 };


    private double A => dimensions[0];
    private double B => dimensions[1];
    private double C => dimensions[2];
    
    public double Volume => Math.Round(A * B * C, 9);
    public double Area => Math.Round(2 * (A * B + B * C + A * C), 6);
    
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
}