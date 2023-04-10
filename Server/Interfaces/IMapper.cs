namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface IMapper<T1, T2>
{
    T2 GetMappedResult(T1 model);
}
