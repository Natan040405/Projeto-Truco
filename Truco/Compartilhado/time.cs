using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{

    public class Time
    {
        public int qtde { get; set; }

        public bool nos { get; set; }

        public List<Pessoa> pessoas { get; set; }

        public int pontuacao { get; set; }

        public Time(bool nos, int qtde, int pontuacao = 0)
        {
            this.nos = nos;
            this.qtde = qtde;
            this.pontuacao = pontuacao;
        }
    }
}