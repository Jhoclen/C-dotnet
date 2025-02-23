using API.Model;
using API.viewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _AlunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _AlunoRepository = alunoRepository ?? throw new ArgumentNullException(nameof(alunoRepository));
        }

        [HttpPost]
        public IActionResult Add(AlunoViewModel alunoview)
        {
            var aluno = new Aluno(alunoview.nome, alunoview.idade);
            _AlunoRepository.Add(aluno);
            return Created();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var aluno = _AlunoRepository.Get();
            return Ok(aluno);
        }
    }
}
