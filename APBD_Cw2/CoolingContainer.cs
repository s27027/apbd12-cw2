namespace APBD_Cw2;

public sealed class CoolingContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }
    private readonly List<KeyValuePair<string, double>> _minimumTemperatures =
    [
        new("Bananas", 13.3),
        new("Chocolate", 18),
        new("Fish", 2),
        new("Meat", -15),
        new("Ice cream", -18),
        new("Frozen pizza", -30),
        new("Cheese", 7.2),
        new("Sausages", 5),
        new("Butter", 20.5),
        new("Eggs", 19),
    ];
    public CoolingContainer(int containerHeight, int containerWeight, int containerDepth, int maxLoad, string productType, double temperature) : base(containerHeight, containerWeight, containerDepth, maxLoad, "C")
    {
        ProductType = productType;
        Temperature = temperature;

        foreach (var product in _minimumTemperatures)
        {
            if (product.Key == ProductType && product.Value > Temperature)
            {
                Temperature = product.Value;
                NotifyHazardous($"Temperatura kontenera zwiększona do minimalnej dla tego typu produktu ({Temperature}C)");
            }
        }
    }
}