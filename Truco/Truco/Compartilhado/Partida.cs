using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public class Partida
    {
        public Time vencedor { get; set; }

        public List<Time> times { get; set; }

        public void CriarTimes()
        {
            string isIndividual = "";
            while ((isIndividual != "s") && (isIndividual != "n")) 
            {
                Console.Write("Jogo é individual?(S/N): ");
                isIndividual = Console.ReadLine().ToLower();
            }
            int qtde = isIndividual == "s" ? 1 : 2;

            Time timeNos = new Time(true, qtde);
            Time timeEles = new Time(false, qtde);

            this.times = new List<Time> { timeNos, timeEles };
        }  

        public void DefineCoringa(Carta DefCoringa, Baralho baralho)
        {
            foreach (Carta carta in baralho.cartas)
            {
                if (carta.classe - 1 == DefCoringa.classe) carta.isCoringa = true;
            }
        }

    }
}
