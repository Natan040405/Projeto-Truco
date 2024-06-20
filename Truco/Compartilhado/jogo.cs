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

            partida.DarCartas();
        }
    }
}