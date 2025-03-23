namespace APBD_Z_CW2_s28038;

public class LiquidCont : Container, IHazardNotifier
{
    public bool IsDanger { get; }

    public LiquidCont(double maxCapacity, double ownWeight, double height, double depth, bool isDanger, bool onShip = false)
        : base('L', height, depth, maxCapacity, ownWeight, onShip)
    {
        IsDanger = isDanger;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[DANGER] {message}");
    }

    public override void Load(string productType, double itemMass)
    {
        double limit = IsDanger ? MaxCapacity * 0.5 : MaxCapacity * 0.9;
        if (OnShip)
        {
            Console.WriteLine($"Nie można załadować kontenera {SerialNumb}, ponieważ jest on na statku.");
        }
        else
        {
            double newTotal = ItemMass + itemMass;

            if (newTotal > limit)
            {
                NotifyHazard($"Próba załadunku w kontenerze {SerialNumb} ({newTotal} kg) przekracza dozwolony limit {limit} kg.");
                throw new OverfillException("Przekroczono limit załadunku!");
            }
            else if (newTotal == limit)
            {
                ItemMass = newTotal;
                Console.WriteLine($"Załadowano {itemMass} kg do kontenera {SerialNumb}.");
                NotifyHazard($"Kontener {SerialNumb} jest maksymalnie załadowany ({limit} kg).");
            }
            else
            {
                ItemMass = newTotal;
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
            ItemMass = 0;
            Console.WriteLine($"Kontener {SerialNumb} został poprawnie rozładowany.");
        }
    }
    
}

