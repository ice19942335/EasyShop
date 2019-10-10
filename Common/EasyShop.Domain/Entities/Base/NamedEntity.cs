using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entities.Base.Interfaces;

namespace EasyShop.Domain.Entities.Base
{
    public class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }
}
