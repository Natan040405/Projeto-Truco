using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Utilitarios;

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
            this.mao = new Mao();
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
                nome = Console.ReadLine() + "";
            }

            Pessoa pessoa = new(isjogador, nome, nos, isAtual);

            return pessoa;
        }

        public void MostrarCartas()
        {
            Console.WriteLine($"\n\nCartas de {this.nome}:");
            int cont = 0;
            foreach (Carta carta in this.mao)
            {
                string texto = $"[{cont + 1}](" + Enum.GetName(typeof(Enums.Classes), carta.classe) + " - " + Enum.GetName(typeof(Enums.Nipes), carta.nipe) + ")";
                if (carta.isCoringa) texto += " ***";
                Console.WriteLine(texto);
                cont++;
            }
        }

        public void DarCartas(Rotacao rotacao, Baralho baralho)
        {
            Partida partida = new Partida();
            Carta DefCoringa = baralho[baralho.Count - ((int)Enums.NumeroMax.CartasMao * rotacao.pessoas.Count + 1)];
            partida.DefineCoringa(DefCoringa, baralho);

            while (this.mao.Count < (int)Enums.NumeroMax.CartasMao)
            {
                Pessoa pessoaProx = rotacao.pessoaProxima;
                pessoaProx.mao.Add(baralho.Pop());
                rotacao.AtualizaAtual(pessoaProx);
            } 
        }

        public Carta JogarCarta()
        {
            Carta carta = new Carta(int.MinValue, int.MinValue);
            int index = -1;
            while (index == -1)
            {
                this.MostrarCartas();
                Console.Write("[4](Correr)  [5](Truco)");
                Console.Write("\n\n");
                Console.Write("escolha a opção: ");
                index = Helper.mCint(Console.ReadLine() + "") - 1;
                
                if (index>-1 && index <= (this.mao.Count - 1))
                {
                    carta = this.mao[index];
                    break;
                }
                if (index == 3)
                {
                    return carta;
                }
                index = -1;
                Console.Write("opção inválida, digite uma opção válida!");
            }
            return carta;
        }
    }
}