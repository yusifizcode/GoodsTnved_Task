namespace GoodsApp.Core.Entities;

public class GoodsTree
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Defis { get; set; }
    public string Name { get; set; }
    public int ParentId { get; set; }
    public IEnumerable<GoodsTree> Children { get; set; }

    public override bool Equals(object obj)
    {
        return obj is GoodsTree other && Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
