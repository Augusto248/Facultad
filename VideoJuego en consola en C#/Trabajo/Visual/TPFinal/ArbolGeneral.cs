using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal
{
    public class ArbolGeneral<T>
    {
        private NodoGeneral<T> raiz;


        public ArbolGeneral(T dato)
        {
            this.raiz = new NodoGeneral<T>(dato);
        }

        private ArbolGeneral(NodoGeneral<T> nodo)
        {
            this.raiz = nodo;
        }

        private NodoGeneral<T> getRaiz()
        {
            return raiz;
        }

        public T getDatoRaiz()
        {
            return this.getRaiz().getDato();
        }

        public List<ArbolGeneral<T>> getHijos()
        {
            List<ArbolGeneral<T>> temp = new List<ArbolGeneral<T>>();
            foreach (NodoGeneral<T> element in this.raiz.getHijos())
            {
                temp.Add(new ArbolGeneral<T>(element));
            }
            return temp;
        }

        public void agregarHijo(ArbolGeneral<T> hijo)
        {
            this.raiz.getHijos().Add(hijo.getRaiz());
        }

        public void eliminarHijo(ArbolGeneral<T> hijo)
        {
            this.raiz.getHijos().Remove(hijo.getRaiz());
        }

        public bool esVacio()
        {
            return this.raiz == null;
        }

        public bool esHoja()
        {
            return this.raiz != null && this.getHijos().Count == 0;
        }




        public int altura()
        {
            if (this.esHoja())
            {

                return 0;

            }

            else
            {
                int alturaAux = 0;
                int alturaMax = 0;
                List<ArbolGeneral<T>> temp = getHijos();

                foreach (ArbolGeneral<T> n in temp)
                {
                    alturaAux = n.altura();
                    alturaAux++;

                    if (alturaMax < alturaAux)
                    {
                        alturaMax = alturaAux;

                    }
                }

                return alturaMax;

            }
        }

        //El ancho del arbol es la cantidad de nodos que tengo en un nivel donde haya
        //mas nodos.
        public int ancho()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;
            int contArboles = 0, anchoMax = 0;

            c.encolar(this);
            c.encolar(null);
            anchoMax = 1;

            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                if (arbolAux == null)
                {
                    if (!c.esVacia())
                        c.encolar(null);

                    if (contArboles > anchoMax)
                        anchoMax = contArboles;

                    contArboles = 0;
                }
                else
                {
                    // Incrementamos el contador de arboles por nivel
                    contArboles++;

                    // Encolamos hijos
                    if (!this.esHoja())
                        foreach (var hijo in arbolAux.getHijos())
                            c.encolar(hijo);
                }
            }

            return anchoMax;
        }



        public int Elnivel(T dato)
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> Aux;


            c.encolar(this);
            c.encolar(null);


            int nivel = 0;
            int nivelDato = 0;
            bool a = false;


            while (!c.esVacia())
            {

                Aux = c.desencolar();


                if (Aux == null)
                {
                    nivel++;
                    if (!c.esVacia())
                    {
                        c.encolar(null);
                    }


                }

                else
                {

                    if (Aux.getDatoRaiz().Equals(dato))
                    {
                        nivelDato = nivel;
                        a = true;
                    }

                    foreach (var hijo in Aux.getHijos())
                    {
                        c.encolar(hijo);

                    }
                }

            }

            if (a == true)
            {
                return nivelDato;

            }

            else
            {
                return nivelDato = -1;
            }

        }



        public void caudal(T litros)
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> aux;

            raiz.setDato(litros);
            c.encolar(this);



            while (!c.esVacia())
            {
                aux = c.desencolar();


                Console.WriteLine("La casa tiene " + aux.getDatoRaiz() + " litros");

                if (!aux.esHoja())
                {

                    foreach (ArbolGeneral<T> hijo in aux.getHijos())
                    {
                        int dato = (int)(object)aux.getDatoRaiz() / aux.getHijos().Count;

                        hijo.raiz.setDato((T)(object)dato);
                        c.encolar(hijo);

                    }

                }
            }

        }

        public void quadtree(int pixels)
        {

            int nivel = 0;
            int pxNegros = 0;

            ArbolGeneral<T> aux;
            ArbolGeneral<T> nodoNull = new ArbolGeneral<T>((T)(object)-1);
            ArbolGeneral<T> anterior = nodoNull;
            Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();

            cola.encolar(this);

            while (!cola.esVacia())
            {

                aux = cola.desencolar();

                if (aux.getDatoRaiz().ToString() == nodoNull.getDatoRaiz().ToString())
                {

                    nivel++;

                }

                else
                {

                    if (anterior.getDatoRaiz().ToString() == nodoNull.getDatoRaiz().ToString())
                    {

                        cola.encolar(nodoNull);
                    }

                    if (!aux.esHoja())
                    {

                        foreach (var element in aux.getHijos())
                        {

                            cola.encolar(element);

                        }
                    }

                    if (aux.esHoja())

                        if (aux.getDatoRaiz().ToString() == 1.ToString())

                            pxNegros = (int)(pxNegros + (1024 / Math.Pow(4, nivel)));

                }

                anterior = aux;

            }

            Console.Write(pxNegros);

        }







        public void preOrden()
        {
            // Procesamos raiz
            Console.Write(this.getDatoRaiz() + " ");

            // Hago recursion en todos los hijos
            if (!this.esHoja())
            {
                List<ArbolGeneral<T>> listaHijos = this.getHijos();

                foreach (var hijo in listaHijos)
                {
                    hijo.preOrden();
                }
            }
        }




        public void postOrden()
        {
            // Hago recursion en todos los hijos
            if (!this.esHoja())
            {
                List<ArbolGeneral<T>> listaHijos = this.getHijos();
                foreach (var hijo in listaHijos)
                    hijo.postOrden();
            }
            // Procesamos raiz
            Console.Write(this.getDatoRaiz() + " ");
        }






        public void InOrden()
        {



            List<ArbolGeneral<T>> listaHijos = this.getHijos();

            for (int i = 0; i <= listaHijos.Count - 1; i++)
            {
                //En la segunda iteracion que imprima la Raiz.
                if (i == 1)
                {
                    Console.Write(this.getDatoRaiz() + " ");
                }

                listaHijos[i].InOrden();
            }


            //Imprimo hojas
            if (esHoja())
            {
                Console.Write(this.getDatoRaiz() + " ");


            }

        }


        public void porNiveles()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

            c.encolar(this);
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                Console.Write(arbolAux.getDatoRaiz() + " ");

                if (!this.esHoja())
                {
                    foreach (var hijo in arbolAux.getHijos())
                        c.encolar(hijo);
                }
            }
        }

        public void porNivelesCarta()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

            c.encolar(this);
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                Carta e = (Carta)(object)arbolAux.getDatoRaiz();
                Console.WriteLine("el valor de la carta es "+e.getCarta()+" y su valor heuri es "+e.getHeuris());

                if (!this.esHoja())
                {
                    foreach (var hijo in arbolAux.getHijos())
                        c.encolar(hijo);
                }
            }
        }


         public void porNivelesCartas()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

            c.encolar(this);
            c.encolar(null);
            int nivel = 0;
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                if(arbolAux==null)
                {
                    if(!c.esVacia())
                    {
                        c.encolar(null);
                        nivel++;
                    }
                }
                else
                {
                    Carta e = (Carta)(object)arbolAux.getDatoRaiz();
                    if (nivel == 0)
                    {
                        Console.Write("nivel de la carta "+nivel+". ");
                        Console.WriteLine("el valor de la carta es " + e.getCarta() + " y su valor heuri es " + e.getHeuris());

                    }
                    if (nivel == 1)
                    {
                        Console.Write("nivel de la carta " + nivel + ". ");
                        Console.WriteLine("el valor de la carta es " + e.getCarta() + " y su valor heuri es " + e.getHeuris());

                    }
                    if (nivel == 2)
                    {
                        Console.Write("nivel de la carta " + nivel + ". ");
                        Console.WriteLine("el valor de la carta es " + e.getCarta() + " y su valor heuri es " + e.getHeuris());

                    }
                    if (nivel == 3)
                    {
                        Console.Write("nivel de la carta " + nivel + ". ");
                        Console.WriteLine("el valor de la carta es " + e.getCarta() + " y su valor heuri es " + e.getHeuris());

                    }
                    if (nivel == 4)
                    {
                        Console.Write("nivel de la carta " + nivel + ". ");
                        Console.WriteLine("el valor de la carta es " + e.getCarta() + " y su valor heuri es " + e.getHeuris());

                    }
                    if (!this.esHoja())
                    {
                        foreach (var hijo in arbolAux.getHijos())
                            c.encolar(hijo);
                    }


                }

               
            }
        }


        public void ElegirNivel()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;
            int nivel = 0;
            Console.WriteLine("Ingrese un nivel para ver las posibles jugadas:");
            int lvl = int.Parse(Console.ReadLine());

            c.encolar(this);
            c.encolar(null);
            while (!c.esVacia())
            {

                arbolAux = c.desencolar();

                if (arbolAux == null)
                {
                    if (!c.esVacia())
                    {
                        c.encolar(null);
                        nivel++;
                    }
                }

                else
                {
                    
                    if (!this.esHoja())
                    {
                        if (nivel == lvl)
                        {
                            Carta e = (Carta)(object)arbolAux.getDatoRaiz();
                            Console.WriteLine("el valor de la carta es " + e.getCarta() + " y su valor heuri es " + e.getHeuris());
                        }

                        foreach (var hijo in arbolAux.getHijos())
                            c.encolar(hijo);
                    }

                    else
                    {
                        if (nivel == lvl)
                        {
                            
                            Carta e = (Carta)(object)arbolAux.getDatoRaiz();

                            if (e.getHeuris() == 1)
                            {
                                Console.WriteLine("el valor de la carta es " + e.getCarta() + " y el humano pierde ");
                            }
                            if (e.getHeuris() == -1)
                            {
                                Console.WriteLine("el valor de la carta es " + e.getCarta() + " y la IA pierde");
                            }
                        }
                    }

                }
            }
        }













    }
}
