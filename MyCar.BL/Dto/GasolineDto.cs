using System;

namespace MyCar.BL.Dto
{
    public class GasolineDto
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public decimal Mileage { get; set; }

        public decimal GasolineTanked { get; set; }

        public DateTime? RefiledDate { get; set; }
    }
}