using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public class Pessoa
    {
        public Mao mao = new Mao();

        public bool isJogador { get; set; }

        public Pessoa() 
        {
            this.mao = new Mao();
            this.isJogador = false;
        }

    }
}