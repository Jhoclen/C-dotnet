using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCrud.DTO.Livro;
using webApiCrud.Model;
using webApiCrud.services.livro;

namespace webApiCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface ?? throw new ArgumentNullException(nameof(livroInterface));
        }

        [HttpGet]
        [Route("listarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> listarLivros()
        {
            var Livros = await _livroInterface.ListarLivros();
            return Ok(Livros);
        }

        [HttpGet]
        [Route("Buscarlivroporid/{Idlivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int Idlivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(Idlivro);
            return Ok(livro);
        }

        [HttpGet]
        [Route("BuscarLivroPorIdAutor/{IdAutor}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarLivroPorIdAutor(int IdAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(IdAutor);
            return Ok(livro);
        }

        [HttpPost]
        [Route("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto LivroCriacaoDto)
        {
            var livros = await _livroInterface.CriarLivro(LivroCriacaoDto);
            return Ok(livros);
                
        }

        [HttpPut]
        [Route("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto LivroEdicaoDto)
        {
            var livros = await _livroInterface.EditarLivro(LivroEdicaoDto);
            return Ok(livros);
        }

        [HttpDelete]
        [Route("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int IdLivro)
        {
            var livros = await _livroInterface.ExcluirLivro(IdLivro);
            return Ok(livros);
        }
    }
}
