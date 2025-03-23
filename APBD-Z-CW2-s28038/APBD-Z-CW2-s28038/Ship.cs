namespace APBD_Z_CW2_s28038;

public class Ship
{
    public string Name { get; }
    public int MaxContNum { get; }
    public double MaxContWeightTons { get; }
    public double MaxSpeed { get; set; }
    private List<Container>? containers = new();

    public Ship(string name, int maxContNum, double maxContWeightTons, double maxSpeed)
    {
        Name = name;
        MaxContNum = maxContNum;
        MaxContWeightTons = maxContWeightTons;
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
        else if (newTotalWeight > MaxContWeightTons * 1000)
        {
            Console.WriteLine($"[SHIP {Name}] Przekroczono limit waowy statku.");
            return false;
        }
        
        containers.Add(container);
        container.OnShip = true;
        Console.WriteLine($"[SHIP {Name}] Załadowano kontener {container.SerialNumb}.");
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
                containers[i].OnShip = false;
                containers[i] = cont2;
                containers[i].OnShip = true;
                Console.WriteLine($"[SHIP {Name}] Kontener {serialNumb} został zastąpiony kontenerem {cont2.SerialNumb}");
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
            Console.WriteLine($"[SHIP {ship1.Name}] Nie znaleziono kontenera {serialNumb}.");
            return false;
        }
        else if (ship1.RemoveCont(serialNumb))
        {
            ship2.LoadCont(container);
            Console.WriteLine($"[TRANSFER] Kontener {container.SerialNumb} został przeładowany ze statku {ship1.Name} na statek {ship2.Name}.");
            return true;
        }
        else
        {
            Console.WriteLine($"[TRANSFER] Nie udało się załadowanć kontenera {container.SerialNumb}.");
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
        return $"[SHIP {Name}] \n MaxPrędkość: {MaxSpeed} \n MaxLiczbaKontenerów: {MaxContNum} \n MaxDopuszczalnaWaga: {MaxContWeightTons}";
    }
}