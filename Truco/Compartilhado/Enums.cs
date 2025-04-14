using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Compartilhado
{
    internal class Enums
    {

        //Nipes e Classes estão por ordem de força do menor para o maior
        public enum Nipes
        {
            Paus = 1,
            Copas = 2,
            Espadas = 3,
            Ouros = 4,
        }
        public enum Classes
        {
            Tres = 1,
            Dois = 2,
            As = 3,
            Rei = 4,
            Dama = 5,
            Valete = 6,
            Dez = 7,
            Sete = 8,
            Seis = 9,
            Cinco = 10,
            Quatro = 11,
        }
        public enum Pontos
        {
            Simples = 1,
            Truco = 3,
            Seis = 6,
            Nove = 9,
            Doze = 12,
            maximo = 12,
            maximoRodada = 2,
        }
        public enum Times
        {
            nos = 1,
            eles = 0,
        }
        public enum NumeroMax
        {
            CartasMao = 3,
            CartasBaralho = 44,
            Embaralhar = 3,

        }
    }
}
