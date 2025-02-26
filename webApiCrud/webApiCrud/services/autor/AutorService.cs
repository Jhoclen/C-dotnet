using Microsoft.EntityFrameworkCore;
using webApiCrud.Data;
using webApiCrud.DTO.Autor;
using webApiCrud.Model;

namespace webApiCrud.services.autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "autor não encontrado";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "autor localizado";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livrobanco => livrobanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "o autor não foi localizado";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "autor localizado";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto AutorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Nome = AutorCriacaoDto.Nome,
                    Sobrenome = AutorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto AutorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(AutorBanco => AutorBanco.Id == AutorEdicaoDto.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Autor não foi localizado";
                    return resposta;
                }

                autor.Nome = AutorEdicaoDto.Nome;
                autor.Sobrenome = AutorEdicaoDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int IdAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(AutorBanco => AutorBanco.Id == IdAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Autor não foi localizado";
                    return resposta;   
                }
                 _context.Remove(autor);
                 await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor removido com sucesso";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "sucesso, os autores foram coletados";        

                return resposta;
                
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }
    }
}
