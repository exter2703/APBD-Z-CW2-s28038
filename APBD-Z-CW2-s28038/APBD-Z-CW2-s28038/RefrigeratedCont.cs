namespace APBD_Z_CW2_s28038;

public class RefrigeratedCont : Container
{
    public string ProductType { get; }
    public double Temperature { get; }

    public RefrigeratedCont(double maxCapacity, double ownWeight, double height, double depth, string productType, double temperature)
        : base('C', maxCapacity, ownWeight, height, depth)
    {
        ProductType = productType;
        Temperature = temperature;
    }

    public override void Load(double itemMass)
    {
        if (itemMass > MaxCapacity) throw new OverflowException($"Przekroczono pojemność kontenera {SerialNumb}");
    }

    public override void Unload()
    {
        ItemMass = 0;
    }
}