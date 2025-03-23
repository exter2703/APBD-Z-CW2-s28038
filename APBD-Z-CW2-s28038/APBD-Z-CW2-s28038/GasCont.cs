namespace APBD_Z_CW2_s28038;

public class GasCont : Container, IHazardNotifier
{
    public double Pressure { get; }
    public bool OnShip { get; set; }

    public GasCont(double maxCapacity, double ownWeight, double height, double depth, double pressure)
        : base('G', maxCapacity, ownWeight, height, depth, onShip:false)
    {
        Pressure = pressure;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[DANGER] {message}");
    }

    public override void Load(string productType, double itemMass)
    {
        if (itemMass > MaxCapacity)
        {
            NotifyHazard($"Przekroczono dopuszczalną ładowność w kontenerze {SerialNumb}.");
            throw new OverflowException("Przekroczono ładowność kontenera!");
        }
        ItemMass = itemMass;
    }

    public override void Unload()
    {
        ItemMass *= 0.05;
    }
}