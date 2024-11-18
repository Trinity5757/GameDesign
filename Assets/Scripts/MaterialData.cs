[System.Serializable]
public class MaterialData
{
    public int plastic;
    public int metal;
    public int glass;
    public int organic;

    public MaterialData(int plastic = 0, int metal = 0, int glass = 0, int organic = 0)
    {
        this.plastic = plastic;
        this.metal = metal;
        this.glass = glass;
        this.organic = organic;
    }
    
    public void AddPlastic(int amount)
    {
        plastic += amount;
    }
    public void AddMetal(int amount)
    {
        metal += amount;
    }
    public void AddGlass(int amount)
    {
        glass += amount;
    }
    public void AddOrganic(int amount)
    {
        organic += amount;
    }
    
}