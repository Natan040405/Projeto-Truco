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
            Console.Write("Jogo é individual?(S/N): ");
            string isIndividual = Console.ReadLine().ToLower();
            int qtde = isIndividual == "s" ? 1 : 2;

            Time timeNos = new Time(true, qtde);
            Time timeEles = new Time(false, qtde);

            this.times = new List<Time> { timeNos, timeEles };
        }

        public List<Mao> DarCartas()
        {
            Baralho baralho = new Baralho();
            baralho.Embaralhar();

            List<Mao> maos = new List<Mao>(); 

            return maos;
        }    
    }
}
