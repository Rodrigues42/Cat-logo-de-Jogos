using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Excepition
{
    public class JogoJaCadastradoExcepition : Exception
    {
        public JogoJaCadastradoExcepition()
            : base("Este jogo já está cadastrado")
        { }
    }
}
