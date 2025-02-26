using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webApiCrud.Model
{
    public class AutorModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } 

        public string Sobrenome { get; set; }
        [JsonIgnore]
        public ICollection<LivroModel> Livro { get; set; }
    }
}
