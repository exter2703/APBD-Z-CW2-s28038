namespace APBD_Z_CW2_s28038;

public class RefrigeratedCont : Container
{
    public string? ProductType { get; private set; }
    public double Temperature { get; }
    public bool OnShip { get; set; }

    public RefrigeratedCont(double maxCapacity, double ownWeight, double height, double depth, double temperature)
        : base('C', maxCapacity, ownWeight, height, depth, onShip:false)
    {
        Temperature = temperature;
    }

    public override void Load(string productType, double itemMass)
    {
        if (itemMass > MaxCapacity) throw new OverflowException($"Przekroczono pojemność kontenera {SerialNumb}");
        
        if (ProductType == null)
        {
            ProductType = productType;
        }
        else if (ProductType != productType)
        {
            throw new InvalidOperationException($"Kontener {SerialNumb} może przechowywać tylko {ProductType}, a nie {productType}");
        }
        ItemMass = itemMass;
    }

    public override void Unload()
    {
        ItemMass = 0;
        ProductType = null;
    }
}