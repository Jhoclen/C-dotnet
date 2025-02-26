
using webApiCrud.DTO.Vinculo;
using webApiCrud.Model;

namespace webApiCrud.DTO.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
