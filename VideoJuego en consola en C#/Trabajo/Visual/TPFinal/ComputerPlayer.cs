
using System;
using System.Collections.Generic;
using System.Linq;

namespace TPFinal
{
	public class ComputerPlayer: Jugador
	{
        private List<int> naipes = new List<int>();
        private List<int> naipesHumano = new List<int>();
        private int limite;
        private bool random_card = true;
        private ArbolGeneral<Carta> raiz;           //Raiz del arbol.
        private ArbolGeneral<Carta> Aux;            //Lo usaremos para movernos por el árbol.




        public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
            this.naipes = cartasPropias;
            this.naipesHumano = cartasOponente;
            this.limite = limite;
            bool turnoMaquina = true;           

            Carta car = new Carta();
            car.setCarta(0);
            car.setHeuris(0);        
            raiz = new ArbolGeneral<Carta>(car);

            ArmarArbol(raiz, naipes, naipesHumano, limite, turnoMaquina );                     
            minmax(raiz, 0);

            //raiz.porNivelesCartas();

            Aux = raiz;
            //Referencia al arbol.

        }

       
        


        public ArbolGeneral<Carta> obtenerReferencia()
        {
            return Aux;
        }

        public ArbolGeneral<Carta> obtenerReferenciaRaiz()
        {
            return raiz;
        }


        public void ArmarArbol(ArbolGeneral<Carta> raiz, List<int> cartasIa, List<int> cartasHum, int limite, bool turnoMaquina)
        {


            foreach (int carta in  cartasHum)
            {

                if (turnoMaquina == true)   //Si es el turno de la maquina, entonces...
                {
                   

                    if (limite >= 0)        //Si el limite es mayor o igual a cero, entonces se agrega un nuevo hijo.
                    {
                        Carta car = new Carta();
                        car.setCarta(carta);
                        car.setHeuris(0);
                        ArbolGeneral<Carta> hijo = new ArbolGeneral<Carta>(car);

                        raiz.agregarHijo(hijo);

                        List<int> cartasHumAux = new List<int>();   //Creamos una lista de cartas auxiliares.
                        cartasHumAux.AddRange(cartasHum);           //Hacemos una copia de las cartas del humano.
                        cartasHumAux.Remove(carta);                 //Borramos de la lista la carta que fue agregada como "hijo" en la raiz.

                        int nuevolimite = limite - carta;           //Seteamos un nuevo limite.


                        ArmarArbol(hijo, cartasHumAux, cartasIa, nuevolimite, !turnoMaquina);
                        //Hace llamada recursiva con las cartas de la IA ahora (Hay que armar las jugadas del humano).
                        //Ponemos por parametro !turnomaquina para poder entrar al else en la llamada recursiva.




                    }
                }                                                                         
                                                                                          

                else                  //Si no es el turno de la maquina, entonces...
                {
                    
                    if (limite >= 0)
                    {
                        Carta car = new Carta();
                        car.setCarta(carta);
                        car.setHeuris(0);
                        ArbolGeneral<Carta> hijo = new ArbolGeneral<Carta>(car);

                        raiz.agregarHijo(hijo);

                        List<int> cartasIaAux = new List<int>();                   
                        cartasIaAux.AddRange(cartasHum);
                        cartasIaAux.Remove(carta);

                        int nuevolimite = limite - carta;

                        ArmarArbol(hijo, cartasIaAux, cartasIa, nuevolimite, !turnoMaquina);
                                            
                        
                    }
                }

            }


        }



        public void minmax(ArbolGeneral<Carta> raiz,int nivel)
        {
            bool e = false;             //Para evitar cambiar el valor heuristico necesitamos variables booleanas.
            bool k = false;


            if(raiz.esHoja())
            {
                if (!(nivel % 2 == 0)) //Turno humano
                {
                    raiz.getDatoRaiz().setHeuris(1);
                    
                    
                }
                else
                {
                    raiz.getDatoRaiz().setHeuris(-1);
                   
                    
                }
            }


            else
            {


                int nuevoNivel = nivel+1;

                foreach (var x in raiz.getHijos())
                {
                    

                    minmax(x, nuevoNivel);      //Hacemos llamada recursiva en cada hijo de la raiz.
                    

                    if (!(nivel % 2 == 0))   //Turno humano. Estamos parados en una raiz de resto 0. Tiene q setearse con -1.
                    {
                        
                            int valorHeuPorDefecto  = -1;
                            int aux = x.getDatoRaiz().getHeuris(); //Le pedimos al hijo de la raiz su valor heuristico.
                            if (aux > valorHeuPorDefecto)          //El hijo seria la IA, y la IA siempre juega a ganar, entonces
                                                                   //vamos a buscar un valor heuristico que sea igual a "+1".
                            {
                                valorHeuPorDefecto = aux;
                                raiz.getDatoRaiz().setHeuris(valorHeuPorDefecto);
                                k = true;

                            }

                            if (k == false)
                            {
                            raiz.getDatoRaiz().setHeuris(valorHeuPorDefecto);
                            k = true;
                            }

                    }

                    else
                    {
                        
                            int valorHeuPorDefecto = 1;
                            int aux = x.getDatoRaiz().getHeuris();
                            if (aux < valorHeuPorDefecto)  
                            {
                                valorHeuPorDefecto = aux;
                                raiz.getDatoRaiz().setHeuris(valorHeuPorDefecto);
                                e = true;
                            }

                           


                            if(e==false)
                            {
                                raiz.getDatoRaiz().setHeuris(valorHeuPorDefecto);
                                e = true;
                            }

                    }

                }
                           
            }

        }






        public override int descartarUnaCarta()
		{
           

            int CartaIA= Aux.getDatoRaiz().getCarta();           //Con el metodo "cartaDelOponente" hicimos que "Aux" haga referencia a
                                                                 //una carta con la que la IA puede ganar.
            Console.WriteLine("La IA jugo la carta:" + CartaIA);


            return CartaIA;
		}
		

		public override void cartaDelOponente(int carta)
		{
            
                   
            foreach (var hijo in Aux.getHijos())        //Aux representa la ultima carta que jugo la IA. Entonces, vamos
                                                        //a buscar en los hijos de Aux si hay alguna carta que sea igual 
                                                        //a la carta que jugo el humano.

            {                                           
                if (hijo.getDatoRaiz().getCarta()==carta)   //En caso de ser verdadero, entonces haremos referencia a esa carta del humano.
                {
                    Aux = hijo;                                 

                    break;
                }
                
            }

            foreach (var hijo in Aux.getHijos())            //Hacemos un foreach de los hijos de la carta del humano.
            {
                if (hijo.getDatoRaiz().getHeuris() == 1)    //Si tiene un hijo con un valor heuristico igual a "+1", entonces  
                                                            //quiere decir que encontramos una carta con la que la IA puede ganar.
                {
                    Aux = hijo;                             //Ya tenemos la nueva referencia.
                    break;

                }

                else
                {
                    Aux = hijo;     

                }
                
            }


           

        }
		
	}
}
