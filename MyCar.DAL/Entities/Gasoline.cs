using System;
using Riganti.Utils.Infrastructure.Core;

namespace MyCar.DAL.Entities
{
    public class Gasoline : IEntity<int>
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public decimal Mileage { get; set; }

        public decimal GasolineTanked { get; set; }

        public DateTime? RefiledDate { get; set; }
    }
}