using API.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.insfra
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoContext _context;

        public AlunoRepository(AlunoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            _context.SaveChanges();

        }

        public List<Aluno> Get()
        {
            return _context.Aluno.ToList();
        }
    }
}
