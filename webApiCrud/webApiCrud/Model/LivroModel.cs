using System.ComponentModel.DataAnnotations;

namespace webApiCrud.Model
{
    public class LivroModel
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public AutorModel Autor { get; set; }
    }
}
