namespace APBD_Z_CW2_s28038;

public class LiquidCont : Container, IHazardNotifier
{
    public bool IsDanger { get; }
    public bool OnShip { get; set; }

    public LiquidCont(double maxCapacity, double ownWeight, double height, double depth, bool isDanger, bool onShip)
        : base('L', maxCapacity, ownWeight, height, depth, onShip:false)
    {
        IsDanger = isDanger;
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
            double limit = IsDanger ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

            if (itemMass > limit)
            {
                NotifyHazard($"Próba załadunku w kontenerze {SerialNumb} ({itemMass} kg) przekracza dozwolony limit {limit} kg.");
                throw new OverfillException("Przekroczono limit załadunku!");
            } 
        }
    }
    
    public override void Unload()
    {
        if (OnShip)
        {
            Console.WriteLine($"Nie można rozładować kontenera {SerialNumb}, ponieważ jest on na statku.");
        }
        else ItemMass = 0; 
    }
    
}

