namespace APBD_Z_CW2_s28038;

public class Ship
{
    public string Name { get; }
    public int MaxContNum { get; }
    public double MaxContWeight { get; }
    public double MaxSpeed { get; set; }
    private List<Container>? containers = new();

    public Ship(string name, int maxContNum, double maxContWeight, double maxSpeed)
    {
        Name = name;
        MaxContNum = maxContNum;
        MaxContWeight = maxContWeight;
        MaxSpeed = maxSpeed;
    }

    public bool LoadCont(Container container)
    {
        double totalWeight = containers.Sum(c => container.ItemMass + container.OwnWeight);
        double newTotalWeight = totalWeight + container.ItemMass + container.OwnWeight;
        if (containers.Count >= MaxContNum)
        {
            Console.WriteLine($"[SHIP {Name}] Przekroczono limit kontenerów na pokładzie.");
            return false;
        }
        else if (newTotalWeight > MaxContWeight * 1000)
        {
            Console.WriteLine($"[SHIP {Name}] Przekroczono limit waowy statku.");
            return false;
        }
        
        containers.Add(container);
        container.OnShip = true;
        Console.WriteLine($"[SHIP {Name}] Załadowano kontener {container.SerialNumb}");
        return true;
    }

    public bool RemoveCont(string serialNumb)
    {
        var container = containers?.FirstOrDefault(c => c.SerialNumb == serialNumb);
        if (container == null)
        {
            Console.WriteLine($"[SHIP {Name}] Na statku nie ma już żadnych kontenerów.");
            return false;
        }
        
        containers?.Remove(container);
        container.OnShip = false;
        Console.WriteLine($"[SHIP {Name}] Kontener {serialNumb} został rozładowany ze statku.");
        return true;
    }

    public bool ReplaceCont(string serialNumb, Container cont2)
    {
        for (int i = 0; i < containers?.Count; i++)
        {
            if (containers[i].SerialNumb == serialNumb)
            {
                containers[i] = cont2;
                Console.WriteLine($"[SHIP {Name}] Kontener {containers[i]} został zastąpiony kontenerem {cont2}");
                return true;
            }
        }
        return false;
    }

    public bool TransferCont(string serialNumb, Ship ship1, Ship ship2)
    {
        var container = containers?.FirstOrDefault(c => c.SerialNumb == serialNumb);
        if (container == null)
        {
            Console.WriteLine($"[SHIP {ship1}] Nie znaleziono kontenera {serialNumb}.");
            return false;
        }
        else if (ship2.LoadCont(container))
        {
            ship1.RemoveCont(serialNumb);
            Console.WriteLine($"[TRANSFER] Kontener {serialNumb} został przeładowany ze statku {ship1} na statek {ship2}.");
            return true;
        }
        else
        {
            Console.WriteLine($"[TRANSFER] Nie udało się załadowanć kontenera {serialNumb}.");
            return false;
        }
    }
    
    public void LoadInfo()
    {
        Console.WriteLine($"-Ładunek statku {Name}-");
        foreach (var c in containers)
        {
            Console.WriteLine($"• {c.SerialNumb}, masa załadunku: {c.ItemMass} kg");
        }
        Console.WriteLine($"Razem kontenerów: {containers.Count}");
    }

    public List<Container>? GetContainers()
    {
        return containers;
    }

    public override string ToString()
    {
        return $"[SHIP {Name}] \n MaxPrędkość: {MaxSpeed} \n MaxLiczbaKontenerów: {MaxContNum} \n MaxDopuszczalnaWaga: {MaxContWeight}";
    }
}