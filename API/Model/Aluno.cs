using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Aluno
    {
        
        [Key]
        public int id { get;  private set; }

        public string nome { get;  private set; }

        public int idade { get; set; }
        public Aluno (string nome, int idade)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.idade = idade;
        }

    }

}
