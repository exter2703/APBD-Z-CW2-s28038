namespace APBD_Z_CW2_s28038;

public abstract class Container
{
    private static int counter = 1;
    
    public string SerialNumb { get; }
    public double ItemMass { get; protected set; }
    public double Height { get; }
    public double Depth { get; }
    public double MaxCapacity { get; }
    public double OwnWeight { get; }
    public bool OnShip { get; set; }

    public Container(char typeCode, double height, double depth, double maxCapacity, double ownWeight, bool onShip)
    {
        SerialNumb = $"KON-{typeCode}-{counter++}";
        Height = height;
        Depth = depth;
        MaxCapacity = maxCapacity;
        OwnWeight = ownWeight;
        OnShip = onShip;
    }

    public abstract void Load(string productType, double itemMass);
    public abstract void Unload();

    public void GetInfo()
    {
        Console.WriteLine($"[KONTENER] {SerialNumb} \n Wysokość: {Height} \n Głębokość: {Depth} \n MaxPojemność: {MaxCapacity} " +
                          $"\n MasaWłasna: {OwnWeight} \n MasaŁadunku: {ItemMass} \n NaStatku: {OnShip}");
    }
    
}