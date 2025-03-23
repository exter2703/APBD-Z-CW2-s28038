namespace APBD_Z_CW2_s28038;

public class GasCont : Container, IHazardNotifier
{
    public double Pressure { get; }
    
    public GasCont(double maxCapacity, double ownWeight, double height, double depth, double pressure, bool onShip = false)
        : base('G', height, depth, maxCapacity, ownWeight, onShip)
    {
        Pressure = pressure;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[DANGER] {message}");
    }

    public override void Load(string productType, double itemMass)
    {
        if (OnShip)
        {
            Console.WriteLine($"Nie można załadować kontenera {SerialNumb}, ponieważ jest on na statku.");
        }
        else
        {
            if (itemMass > MaxCapacity)
            {
                NotifyHazard($"Przekroczono dopuszczalną ładowność w kontenerze {SerialNumb}.");
                throw new OverflowException("Przekroczono ładowność kontenera!");
            }
            else
            {
                ItemMass += itemMass;
                Console.WriteLine($"Załadowano {itemMass} kg do kontenera {SerialNumb}.");
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
            ItemMass *= 0.05;
            Console.WriteLine($"Kontener {SerialNumb} został poprawnie rozładowany.");
        }
    }
}