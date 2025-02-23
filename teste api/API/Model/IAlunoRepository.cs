namespace API.Model
{
    public interface IAlunoRepository
    {
        void Add(Aluno aluno);

        List<Aluno> Get();
    }
}
