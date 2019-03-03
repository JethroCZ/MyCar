using System.ComponentModel.DataAnnotations.Schema;
using Riganti.Utils.Infrastructure.Core;

namespace MyCar.DAL.Entities
{
    [Table("Users")]
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public string Jmeno { get; set; }

        public string Prijmeni { get; set; }
    }
}