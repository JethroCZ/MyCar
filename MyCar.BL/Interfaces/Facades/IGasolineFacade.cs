using MyCar.BL.Dto;

namespace MyCar.BL.Interfaces.Facades
{
    public interface IGasolineFacade
    {
        void Add(GasolineDto gasoline);

        GasolineDto[] GetGasoline();
    }
}