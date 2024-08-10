using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    public class Carta
    {
        public int nipe { get; set; }

        public int classe { get; set; }

        public bool isCoringa { get; set; }

        public Carta(int nipe,int classe)
        {
            this.nipe = nipe;
            this.classe = classe;
        }
    }
}
