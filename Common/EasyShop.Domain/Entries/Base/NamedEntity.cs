using EasyShop.Domain.Entries.Base.Interfaces;

namespace EasyShop.Domain.Entries.Base
{
    public class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }
}
