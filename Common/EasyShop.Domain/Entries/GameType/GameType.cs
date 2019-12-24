using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Base;

namespace EasyShop.Domain.Entries.GameType
{
    [Table("GameTypes")]
    public class GameType : BaseEntity
    {
        [Required]
        public string Type { get; set; }
    }
}