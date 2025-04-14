using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Truco.Utilitarios;

namespace Truco.Compartilhado
{
    public class Partida
    {
        public Time vencedor { get; set; }

        public Dictionary<int, Time> times { get; set; }

        public void CriarTimes()
        {
            string isIndividual = "";
            while ((isIndividual != "s") && (isIndividual != "n")) 
            {
                Console.Write("Jogo é individual?(S/N): ");
                isIndividual = (Console.ReadLine() + "").ToLower();
            }
            int qtde = isIndividual == "s" ? 1 : 2;

            Time timeNos = new Time(true, qtde);
            Time timeEles = new Time(false, qtde);

            this.times = new Dictionary<int, Time> 
            { 
                { (int)Enums.Times.nos, timeNos }, 
                { (int)Enums.Times.eles, timeEles } 
            };
        }  

        public void DefineCoringa(Carta DefCoringa, Baralho baralho)
        {
            foreach (Carta carta in baralho)
            {
                if (carta.classe - 1 == DefCoringa.classe) carta.isCoringa = true;
            }
        }

        public List<Carta> rodada(Rotacao rotacao)
        {
            Dictionary<Carta, int> cartasMesa = new Dictionary<Carta, int> { };
            Dictionary<Carta, int> cartasMesaRodada = new Dictionary<Carta, int> { };
            List<(Carta, int)> cartasFortesRodada = new List<(Carta, int)> { };
            Dictionary<int, int> pontosRodada = new Dictionary<int, int> {{(int) Enums.Times.nos, 0}, {(int)Enums.Times.eles, 0}};
            Pessoa pessoaInicioRotacao = rotacao.pessoaAtual;

            while (rotacao.pessoaAtual.mao.Count > 0)
            {
                Carta cartaJogada = rotacao.pessoaAtual.JogarCarta();

                if (Carta.CartaInvalida(cartaJogada))
                {
                    AtualizaPontuacao(rotacao.pessoaAtual.nos ? (int) Enums.Times.eles : (int) Enums.Times.nos, pontosRodada, true);
                    return cartasMesa.Keys.ToList();
                }

                cartasMesa.Add(cartaJogada, Helper.mCint(rotacao.pessoaAtual.nos));
                rotacao.pessoaAtual.mao.Remove(cartaJogada);
                rotacao.AtualizaAtual(rotacao.pessoaProxima);

                if (pessoaInicioRotacao == rotacao.pessoaAtual)
                {
                    Carta cartaForte = Carta.ValidaForcaCartas(cartasMesa);

                    int TimeCartaForte = cartasMesa[cartaForte];

                    cartasMesaRodada = cartasMesaRodada.Concat(cartasMesa).ToDictionary(x => x.Key, x => x.Value);

                     cartasMesa.Clear();

                    AtualizaPontuacao(TimeCartaForte, pontosRodada);
                    if (ChecaPontuacaoMaximaRodada(pontosRodada, TimeCartaForte))
                    {
                        return cartasMesaRodada.Keys.ToList();
                    }
                }
            }
            return cartasMesaRodada.Keys.ToList();
        }
        void AtualizaPontuacao(int time, Dictionary<int, int> pontosRodada, bool AtualizaPontuacaoTime = false)
        {

            pontosRodada[time] += (int)Enums.Pontos.Simples;

            if (AtualizaPontuacaoTime || ChecaPontuacaoMaximaRodada(pontosRodada, time))
            {
                times[time].pontuacao += (int)Enums.Pontos.Simples;
                return;
            }


        }

        bool ChecaPontuacaoMaximaRodada(Dictionary<int, int> pontosRodada, int time)
        {
            return pontosRodada[time] >= (int) Enums.Pontos.maximoRodada;
        }
    }
}
