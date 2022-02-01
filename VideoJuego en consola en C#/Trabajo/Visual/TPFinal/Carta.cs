using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal
{
    public class Carta
    {
      private   int carta = 0;
      private  int heuristico = 0;


        public void setCarta(int cartaa)
        {
            carta = cartaa;
        }

        public void setHeuris(int heu)
        {
            heuristico = heu;
        }

        public int getCarta()
        {
            return carta;
        }

        public int getHeuris()
        {
            return heuristico;
        }
    }

    
}
