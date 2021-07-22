using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.ViewModel
{
    public class JogoViewModel
    {
        private Guid guid;
        private object p1;
        private object p2;
        private object p3;

        public JogoViewModel(Guid guid, object p1, object p2, object p3)
        {
            this.guid = guid;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public Guid id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
    }
}
