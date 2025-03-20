namespace APBD_Cw2;

public class LiquidContainer : Container
{
    private bool IsHazardous { get; set; }
    
    public LiquidContainer(int containerHeight, int containerWeight, int containerDepth, int maxLoad, bool isHazardous) : base(containerHeight, containerWeight, containerDepth, maxLoad, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void LoadIn(double loadWeight)
    {
        var limit = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;

        if (CurrentLoad + loadWeight > limit)
        {
            NotifyHazardous($"Niebezpieczna operacja w kontenerze");
            loadWeight = limit;
        }
        
        base.LoadIn(loadWeight);
    }
}