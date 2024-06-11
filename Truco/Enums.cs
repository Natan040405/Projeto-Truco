using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    internal class Enums
    {
        public enum nipes
        {
            Copas = 1,
            Ouro = 2,
            Espadas = 3,
            Paus = 4,
        }

        public enum classes
        {
            As = 1,
            Dois = 2,
            Tres = 3,
            Quatro = 4,
            Cinco = 5,
            Seis = 6,
            Sete = 7,
            Dez = 8,
            Valete = 9,
            Dama = 10,
            Rei = 11,
            Coringa = 12,
        }

        public enum pontos
        {
            simples = 1,
            Truco = 3,
            Seis = 6,
            Nove = 9,
            Doze = 12,
        }
    }
}
