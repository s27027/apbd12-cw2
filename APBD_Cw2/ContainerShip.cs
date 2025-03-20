namespace APBD_Cw2;

public class ContainerShip
{
    public List<Container> Containers { get; } = [];
    public int ShipMaxSpeed  { get; }
    public int MaxContainerCapacity { get; }
    public int MaxContainerWeight { get; }

    public ContainerShip(int shipMaxSpeed, int maxContainerCapacity, int maxContainerWeight)
    {
        ShipMaxSpeed = shipMaxSpeed;
        MaxContainerCapacity = maxContainerCapacity;
        MaxContainerWeight = maxContainerWeight;
    }

    public void AddContainer(Container container)
    {
        if (Containers.Contains(container))
        {
            Console.WriteLine($"Kontener {container.SerialNumber} już znajduje się na tym statku");
            return;
        }
        if (Containers.Count >= MaxContainerCapacity)
        {
            throw new Exception("Przekroczono maksymalną ilość kontenerów");
        }
            
        if (GetTotalWeight()+container.CurrentLoad > MaxContainerWeight*1000)
        {
            throw new Exception("Przekroczono maksymalną wagę ładunku");
        }
        Containers.Add(container);

    }
    public void AddContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }
    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }
    public void LoadOutShip()
    {
        Containers.Clear();
    }
    public double GetTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in Containers)
        {
            totalWeight += container.CurrentLoad;
        }
        return totalWeight;
    }
    public void SwapContainers(string prevContainerSerialNumber, Container newContainer)
    {
        foreach (var container in Containers.ToList())
        {
            if (container.SerialNumber != prevContainerSerialNumber) continue;
            RemoveContainer(container);
            AddContainer(newContainer);
        }
    }
    public void ContainerTransfer(ContainerShip containersContainerShip, Container transferredContainer)
    {
        var shipContainsContainer = containersContainerShip.Containers.Contains(transferredContainer);
        
        if (shipContainsContainer)
        {
            AddContainer(transferredContainer);
            containersContainerShip.RemoveContainer(transferredContainer);
        }
        else
        {
            Console.WriteLine($"Kontener {transferredContainer.SerialNumber} nie znajduje się w wskazanym statku");
        }
    }
    public void GetShipInfo()
    {
        Console.WriteLine($"Maks. prędkość statku: {ShipMaxSpeed} Mm/h\nMaks. pojemność kontenerów: {MaxContainerCapacity}\nMaks. obciążenie: {(double)MaxContainerWeight/1000} T\nKontenery na statku:");
        foreach (var container in Containers)
        {
            Console.WriteLine(container.SerialNumber);
        }
    }
}