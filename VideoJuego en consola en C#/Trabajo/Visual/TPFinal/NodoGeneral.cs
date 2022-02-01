using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal
{
    public class NodoGeneral<T>
    {
        private T dato;
        private List<NodoGeneral<T>> hijos;
        

        public NodoGeneral(T dato)
        {
            this.dato = dato;
            this.hijos = new List<NodoGeneral<T>>();
            
        }

        public T getDato()
        {
            return this.dato;
        }

        public List<NodoGeneral<T>> getHijos()
        {
            return this.hijos;
        }

        public int cantidadHijos()
        {
            return this.hijos.Count;
        }

        public void setDato(T dato)
        {
            this.dato = dato;
        }

        public void setHijos(List<NodoGeneral<T>> hijos)
        {
            this.hijos = hijos;
        }

    }
}
