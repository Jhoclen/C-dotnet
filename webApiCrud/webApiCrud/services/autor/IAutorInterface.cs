using webApiCrud.DTO.Autor;
using webApiCrud.Model;

namespace webApiCrud.services.autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto AutorCriacaoDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto AutorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int IdAutor);

    }
}
