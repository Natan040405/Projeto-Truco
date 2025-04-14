using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Utilitarios;

namespace Truco.Compartilhado
{
    public class Jogo
    {
        public void IniciarJogo()
        {
            Partida partida = new Partida();
            bool baralhoPrimordial = true;
            partida.CriarTimes();
            Rotacao rotacao = new Rotacao(partida.times);
            Baralho baralho = new Baralho(baralhoPrimordial);

            while (!verificaPontuacaoMaxima(partida))
            {
                baralho.Embaralhar();

                baralho.Cortar();

                rotacao.pessoaAtual.DarCartas(rotacao, baralho);

                List<Carta> CartasPartida = partida.rodada(rotacao);

                baralho.AddRange(CartasPartida);

                foreach (Time time in partida.times.Values)
                {
                    Console.WriteLine((time.nos ? "nos" : "eles") + ", Pontuação: " + Helper.mCint(time.pontuacao));
                }

                rotacao.AtualizaAtual(rotacao.pessoaProxima);
            }
        }
        bool verificaPontuacaoMaxima(Partida partida)
        {
            return partida.times[(int)Enums.Times.eles].pontuacao >= (int)Enums.Pontos.maximo || partida.times[(int)Enums.Times.nos].pontuacao >= (int)Enums.Pontos.maximo;
        }
    }
}