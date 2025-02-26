using webApiCrud.DTO.Vinculo;
using webApiCrud.Model;

namespace webApiCrud.DTO.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; } 
    }
}

