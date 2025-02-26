
using Microsoft.EntityFrameworkCore;
using webApiCrud.Data;
using webApiCrud.DTO.Livro;
using webApiCrud.Model;

namespace webApiCrud.services.livro
{
    
    public class LivroService : ILivroInterface
    {

        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livrobanco => livrobanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "livros não localizado";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();
                

                if (livros == null || !livros.Any())
                {
                    resposta.Mensagem = "os livros não foram localizados";
                    return resposta;
                }

                resposta.Dados = livros;
                resposta.Mensagem = "livros localizado";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto LivroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {

                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorbanco => autorbanco.Id == LivroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "nenhum registro do autor foi localizado";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = LivroCriacaoDto.Titulo,
                    Autor = autor
                };
                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "livro cadastrado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
                
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto LivroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livrobanco => livrobanco.Id == LivroEdicaoDto.Id);

                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorbanco => autorbanco.Id == LivroEdicaoDto.Autor.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "livro não localizado";
                    return resposta;
                }
                if (autor == null)
                {
                    resposta.Mensagem = "autor não localizado";
                    return resposta;
                }

                livro.Titulo = LivroEdicaoDto.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "livro editado com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int IdLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.Include(a => a.Autor)
                    .FirstOrDefaultAsync(livrobanco => livrobanco.Id == IdLivro);

                if (livro == null)
                {
                    resposta.Mensagem = " nenhum livro foi localizado";
                    return resposta;
                }
                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "livro removido com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "livros listados com sucesso";

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
