using CatalogoJogos.Entity;
using CatalogoJogos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Repositorio
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, jogos>()
        {
            {Guid.Parse("abcd1234"), new Jogo{id = Guid.Parse("abcd1234"), Nome = "Fifa 21", Produtora = "EA", Preco = 200} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(Jogos.Values.skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!Jogos.ContainKey(id))
            {
                return Task.FromResult(jogos[id]);
            }
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(JogoRepository => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Atualizar(Jogo jogo)
        {

        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.id, jogo);
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com BD
        }
    }
}
