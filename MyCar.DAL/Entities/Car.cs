using System.ComponentModel.DataAnnotations.Schema;
using Riganti.Utils.Infrastructure.Core;

namespace MyCar.DAL.Entities
{
    [Table("Cars")]
    public class Car : IEntity<int>
    {
        public int Id { get; set; }

        public int UserId { get; set; }
    }
}