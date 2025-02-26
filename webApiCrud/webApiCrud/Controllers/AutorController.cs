using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCrud.DTO.Autor;
using webApiCrud.Model;
using webApiCrud.services.autor;

namespace webApiCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface ?? throw new ArgumentNullException(nameof(autorInterface));
        }



        [HttpGet]
        [Route("listarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> listarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);

        }

        [HttpGet]
        [Route("BuscarAutorPorid/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorID(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);

        }
        [HttpGet]
        [Route("BuscarAutorPoridlivro/{idlivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idlivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idlivro);
            return Ok(autor);

        }

        [HttpPost]
        [Route("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto AutorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(AutorCriacaoDto);
            return Ok(autores);

        }
        [HttpPut]
        [Route("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto AutorEdicaoDto)
        {
            var autores = await _autorInterface.EditarAutor(AutorEdicaoDto);
            return Ok(autores);

        }
        [HttpDelete]
        [Route("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int IdAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(IdAutor);
            return Ok(autores);

        }
    }
}
