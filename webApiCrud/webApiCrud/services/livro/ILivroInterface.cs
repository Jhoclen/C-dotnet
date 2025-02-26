using webApiCrud.DTO.Autor;
using webApiCrud.DTO.Livro;
using webApiCrud.Model;

namespace webApiCrud.services.livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto LivroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto LivroEdicaoDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int IdLivro);

    }
}
