using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Entity
{
    public class Jogo
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
    }
}
