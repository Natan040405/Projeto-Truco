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


        public static Carta ValidaForcaCartas(Dictionary<Carta, int> cartasMesa)
        {
            Carta cartaForte = new Carta(int.MaxValue, int.MaxValue);

            foreach (Carta carta in cartasMesa.Keys)
            {
                if (carta.isCoringa)
                {
                    if (cartaForte.isCoringa)
                    {
                        if (carta.nipe < cartaForte.nipe)
                        {
                            cartaForte = carta;
                            continue;
                        }
                        continue;
                    }
                    else
                    {
                        cartaForte = carta;
                        continue;
                    }
                    
                }
                if (carta.classe < cartaForte.classe && (!cartaForte.isCoringa))
                {
                    cartaForte = carta;
                }
            }

            return cartaForte; 
        }

        public static bool CartaInvalida(Carta carta)
        {
            return carta.nipe == int.MinValue && carta.classe == int.MinValue;
        }
    }
}
