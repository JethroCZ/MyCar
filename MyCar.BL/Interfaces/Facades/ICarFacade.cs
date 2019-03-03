using MyCar.BL.Dto;

namespace MyCar.BL.Interfaces.Facades
{
    public interface ICarFacade
    {
        void Add(CarDto car);

        CarDto[] GetCars();
    }
}