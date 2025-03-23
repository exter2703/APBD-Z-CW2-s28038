namespace APBD_Z_CW2_s28038;

public class LiquidCont : Container, IHazardNotifier
{
    public bool IsDanger { get; }

    public LiquidCont(double maxCapacity, double ownWeight, double height, double depth, bool isDanger)
        : base('L', maxCapacity, ownWeight, height, depth)
    {
        IsDanger = isDanger;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[DANGER] {message}");
    }

    public override void Load(double itemMass)
    {
        double limit = IsDanger ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

        if (itemMass > limit)
        {
            NotifyHazard($"Próba załadunku w kontenerze {SerialNumb} ({itemMass} kg) przekracza dozwolony limit {limit} kg.");
            throw new OverfillException("Przekroczono limit załadunku!");
        }
    }

    public override void Unload()
    {
        ItemMass = 0;
    }
}
