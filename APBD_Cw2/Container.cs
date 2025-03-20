namespace APBD_Cw2;

public abstract class Container : IHazardNotifier
{
    public double CurrentLoad { get; protected set; }
    public int ContainerHeight { get; }
    public int ContainerWeight { get; }
    public int ContainerDepth { get; }
    public string SerialNumber { get; }
    protected double MaxLoad { get; }
    private static int _containerCount;

    protected Container(int containerHeight, int containerWeight, int containerDepth, int maxLoad, string containerType)
    {
        CurrentLoad = 0;
        ContainerHeight = containerHeight;
        ContainerWeight = containerWeight;
        ContainerDepth = containerDepth;
        SerialNumber = $"KON-{containerType}-{++_containerCount}";
        MaxLoad = maxLoad;
    }

    public virtual void LoadOut()
    {
        CurrentLoad = 0;
    }

    public virtual void LoadIn(double loadWeight)
    {
        if (CurrentLoad + loadWeight > MaxLoad)
        {
            throw new OverfillException($"Ładowność kontenera {SerialNumber} została przekroczona!");
        }
        CurrentLoad += loadWeight;
    }

    public virtual void NotifyHazardous(string message)
    {
        Console.WriteLine($"{SerialNumber} - Alert!: {message}");
    }
}