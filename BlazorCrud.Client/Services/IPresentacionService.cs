using BlazorCrud.Shared;

namespace BlazorCrud.Client.Services
{
    public interface IPresentacionService
    {
        Task<List<PresentacionDTO>> Lista();

        Task<PresentacionDTO> Buscar(int id);

        Task<int> Guardar(PresentacionDTO presentacion);

        Task<int> Editar(PresentacionDTO presentacion);

        Task<bool> Eliminar(int id);
    }
}
