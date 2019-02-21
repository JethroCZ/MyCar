using System;

namespace MyCar.DAL.Entities
{
    public class Gasoline
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public decimal Mileage { get; set; }

        public decimal GasolineTanked { get; set; }

        public DateTime? RefiledDate { get; set; }
    }
}