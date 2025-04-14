using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public class Rotacao
    {
        public List<Pessoa> pessoas = new List<Pessoa>();

        public Pessoa pessoaAtual  { get{ return pessoas.First(p => p.isAtual); } }

        public Pessoa pessoaAnterior 
        { 
            get 
            {
                int ant = this.pessoas.IndexOf(this.pessoaAtual) - 1;
                if (ant < 0) ant = this.pessoas.Count - 1;
                Pessoa pessoaAnterior = this.pessoas[ant];
                return pessoaAnterior;
            } 
        }

        public Pessoa pessoaProxima
        {
            get
            {
                Pessoa pessoaProx = new Pessoa();
                Pessoa pessoaAtual = this.pessoas.FirstOrDefault(p => p.isAtual);
                int prox = this.pessoas.IndexOf(pessoaAtual) + 1;
                if (prox > this.pessoas.Count - 1) prox = 0;
                pessoaProx = this.pessoas[prox];
                return pessoaProx;
            }
        }

        public Rotacao(Dictionary<int, Time> times) 
        {
            Time timeNos = times[0];
            Time timeEles = times[1];

            if (timeNos.pessoas.Count > 1)
            {
                this.pessoas.Add(timeEles.pessoas[0]);
                this.pessoas.Add(timeNos.pessoas[0]);
                this.pessoas.Add(timeEles.pessoas[1]);
                this.pessoas.Add(timeNos.pessoas[1]);
            }
            else
            {
                this.pessoas.Add(timeEles.pessoas[0]);
                this.pessoas.Add(timeNos.pessoas[0]);
            }

        }

        public void AtualizaAtual(Pessoa pessoaProx)
        {
            Pessoa pessoaAtual = this.pessoaAtual;
            pessoaProx.isAtual = pessoaAtual.isAtual;
            pessoaAtual.isAtual = false;
        }
    }
}
