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

    public Container(char typeCode, double height, double depth, double maxCapacity, double ownWeight)
    {
        SerialNumb = $"KON-{typeCode}-{counter++}";
        Height = height;
        Depth = depth;
        MaxCapacity = maxCapacity;
        OwnWeight = ownWeight;
    }
    
    public abstract void Load(double itemMass);
    public abstract void Unload();
    
}