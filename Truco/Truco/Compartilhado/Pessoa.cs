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

        public string nome { get; set; }

        public bool nos { get; set; }

        public bool isAtual { get; set; }

        public Pessoa() 
        {
            this.mao= new Mao();
            this.isJogador= false;
            this.nome = "";
        }

        private Pessoa( bool isjogador, string nome, bool nos, bool isAtual) 
        {
            this.mao = new Mao();
            this.isJogador = isjogador;
            this.nome = nome;
            this.nos = nos;
            this.isAtual = isAtual;
        }

        public Pessoa criaPessoa(bool isjogador, bool nos, bool isAtual)
        {
            string nome = "";

            while (nome == "")
            {
                if (isjogador) Console.Write("Digite o seu nome: ");
                else Console.Write("Digite o nome do jogador: ");
                nome = Console.ReadLine();
            }

            Pessoa pessoa = new(isjogador, nome, nos, isAtual);

            return pessoa;
        }

        public void MostrarCartas()
        {
            Console.WriteLine($"\n\nCartas de {this.nome}:");
            foreach (Carta carta in this.mao.cartas)
            {
                Console.WriteLine("(" + Enum.GetName(typeof(Enums.Classes), carta.classe) + " - " + Enum.GetName(typeof(Enums.Nipes), carta.nipe) + ")");
            }
        }

        public void DarCartas(Rotacao rotacao, Baralho baralho)
        {
            Partida partida = new Partida();
            Carta DefCoringa = baralho.cartas[baralho.cartas.Count - 13]; //Define a carta definitiva de coringa para um jogo de 4 pessoas. TEMPORARIO
            partida.DefineCoringa(DefCoringa, baralho);

            while (this.mao.cartas.Count < 3)
            {
                Pessoa pessoaProx = rotacao.proximo();
                pessoaProx.mao.cartas.Add(baralho.cartas.Pop());
                rotacao.pessoaAtual.AtualizaAtual(pessoaProx);
            } 
        }

        public void AtualizaAtual(Pessoa pessoaProx)
        {
            Pessoa pessoaAtual = this;
            pessoaProx.isAtual = pessoaAtual.isAtual;
            pessoaAtual.isAtual = false;
        }
    }
}