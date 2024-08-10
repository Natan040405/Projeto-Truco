using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public class Jogo
    {
        public void IniciarJogo()
        {
            Partida partida = new Partida();

            partida.CriarTimes();
            Rotacao rotacao = new Rotacao(partida.times);
            Baralho baralho = new Baralho();

            baralho.Embaralhar();

            baralho.Cortar();

            Pessoa pessoaAtual = rotacao.pessoas.FirstOrDefault(p => p.isAtual);

            pessoaAtual.DarCartas(rotacao, baralho);

            foreach (Pessoa pessoa in rotacao.pessoas)
            {
                if (!pessoa.isJogador) continue;
                pessoa.MostrarCartas();
            }
        }
    }
}