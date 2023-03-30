namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers
{
    public interface IMapper<T1,T2>
    {
        T1 MapToModel(T2 viewModel);
        T2 MapToViewModel(T1 model);
    }
}
