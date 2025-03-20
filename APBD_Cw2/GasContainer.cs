namespace APBD_Cw2;

public class GasContainer : Container
{
    public double Pressure { get; }

    public GasContainer(int containerHeight, int containerWeight, int containerDepth, int maxLoad, double pressure) : base(containerHeight, containerWeight, containerDepth, maxLoad, "G")
    {
        Pressure = pressure;
    }

    public override void LoadOut()
    {
        CurrentLoad *= 0.05;
    }
}