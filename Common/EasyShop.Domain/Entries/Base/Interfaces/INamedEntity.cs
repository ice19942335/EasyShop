namespace EasyShop.Domain.Entries.Base.Interfaces
{
    public interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
    }
}
