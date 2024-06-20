using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public class Baralho
    {
        public List<Carta> cartas = new List<Carta>();


        public Baralho()
        {
            foreach (int nipe in Enum.GetValues(typeof(Enums.Nipes)))
            {
                foreach (int classe in Enum.GetValues(typeof(Enums.Classes)))
                {
                    Carta carta = new Carta(nipe, classe);
                    this.cartas.Add(carta);
                }
            }
        }

        public void Embaralhar()
        {
            for (int x = 3; x > 0; x--)
            {
                Random rnd = new Random();
                for (int i = this.cartas.Count - 1; i > 0; i--)
                {
                    int j = rnd.Next(i + 1);
                    Carta temp = this.cartas[i];
                    this.cartas[i] = this.cartas[j];
                    this.cartas[j] = temp;
                }
            }
        }
    }
}
