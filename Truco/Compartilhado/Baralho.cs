using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public class Baralho : List<Carta>
    {

        public Baralho() : base() { }

        public Baralho(bool BaralhoPrimordial)
        {
            foreach (int nipe in Enum.GetValues(typeof(Enums.Nipes)))
            {
                foreach (int classe in Enum.GetValues(typeof(Enums.Classes)))
                {
                    Carta carta = new Carta(nipe, classe);
                    this.Add(carta);
                }
            }
        }

        public void Embaralhar()
        {
            for (int x = (int)Enums.NumeroMax.Embaralhar; x > 0; x--)
            {
                Random rnd = new Random();
                for (int i = this.Count - 1; i > 0; i--)
                {
                    int j = rnd.Next(i + 1);
                    Carta temp = this[i];
                    this[i] = this[j];
                    this[j] = temp;
                }
            }
        }

        public void Cortar() 
        {
            Random rnd = new Random();
            Baralho baralhoAux = new Baralho();

            int carta = rnd.Next(this.Count - ((this.Count / 2) + (this.Count / 4)), this.Count + (this.Count / 4) - this.Count / 2);

            baralhoAux.AddRange(this.GetRange(0, carta - 1));

            this.RemoveRange(0, carta-1);

            this.AddRange(baralhoAux);
        }
    }
}
