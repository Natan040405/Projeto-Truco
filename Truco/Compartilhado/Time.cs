using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{

    public class Time
    {
        public int qtde { get; set; }

        public bool nos { get; set; }

        public List<Pessoa> pessoas = new List<Pessoa>();

        public int pontuacao { get; set; }

        public Time(bool nos, int qtde, int pontuacao = 0)
        {
            this.nos = nos;
            this.qtde = qtde;
            this.pontuacao = pontuacao;
            for (int X = 0; X < this.qtde; X++)
            {
                bool isjogador = false;
                bool isAtual =false;
                if (this.nos && this.pessoas.Count == 0)
                {
                    isjogador = true;
                    isAtual= true;
                }
                Pessoa pessoa = new Pessoa();
                pessoa = pessoa.criaPessoa(isjogador, nos, isAtual);
                this.pessoas.Add(pessoa);
            }
        }
    }
}