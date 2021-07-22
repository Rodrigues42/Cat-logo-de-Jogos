using CatalogoJogos.Excepition;
using CatalogoJogos.InputModel;
using CatalogoJogos.Repositorio;
using CatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Services
{
    public class JogoService : IJogoServices
    {   

        private readonly IJogoServices _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = (IJogoServices)jogoRepository;
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {
                id = jogo.id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();
        }

        public async Task<List<JogoViewModel>> Obter(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null)
                return null;

            return new JogoViewModel
            (
                id = jogo.id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            );
        }

        public async Task<JogoViewModel> Inserir(JogoViewModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
                throw new JogoJaCadastradoExcepition();

            var jogoInsert = new JogoViewModel
                (
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
                );

            await _jogoRepository.Inserir(jogoInsert);

            return new JogoViewModel
                (
                Id = jogoInsert.id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
                );
        }

        public async Task Atualizar(Guid id, JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null)
            {
                throw new JogoNaoCadastradoException();
            }
        
            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _jogoRepository.Atualizar(entidadeJogo);        
        }
        
        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _jogoRepository.Obter();

            if (entidadeJogo == null)
            {
                throw new JogoNaoCadastradoException();
            }

            entidadeJogo.Preco = preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Remover(Guid id)
        {
            var jogo = _jogoRepository.Obter(id);

            if(jogo == null)
            {
                throw new JogoNaoCadastradoException();
            }
            
            await _jogoRepository.Remover(id);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
