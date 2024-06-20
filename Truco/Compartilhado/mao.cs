using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public class Mao
    {
        public List<Carta> cartas { get; set; }

        public Mao() 
        {
            cartas = new List<Carta>();
        }
    }
}
