namespace APBD_Z_CW2_s28038;

public class RefrigeratedCont : Container
{
    public string? ProductType { get; private set; }
    public double Temperature { get; }

    public RefrigeratedCont(double maxCapacity, double ownWeight, double height, double depth, double temperature, bool onShip = false)
        : base('C', height, depth, maxCapacity, ownWeight, onShip)
    {
        Temperature = temperature;
    }

    public override void Load(string productType, double itemMass)
    {
        if (OnShip)
        {
            Console.WriteLine($"Nie można załadować kontenera {SerialNumb}, ponieważ jest on na statku.");
        }
        else
        {
            if (ItemMass > MaxCapacity) throw new OverflowException($"Przekroczono pojemność kontenera {SerialNumb}");
            else
            {
                ItemMass += itemMass;
                Console.WriteLine($"Załadowano {itemMass} kg do kontenera {SerialNumb}.");
            }

            if (ProductType == null)
            {
                ProductType = productType;
            }
            else if (ProductType != productType)
            {
                throw new InvalidOperationException(
                    $"Kontener {SerialNumb} może przechowywać tylko {ProductType}, a nie {productType}");
            }
        }
    }

    public override void Unload()
    {
        if (OnShip)
        {
            Console.WriteLine($"Nie można rozładować kontenera {SerialNumb}, ponieważ jest on na statku.");
        }
        else
        {
            ItemMass = 0;
            ProductType = null;
            Console.WriteLine($"Kontener {SerialNumb} został poprawnie rozładowany.");
        }
    }
}