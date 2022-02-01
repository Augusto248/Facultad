
using System;
using System.Collections.Generic;
using System.Linq;

namespace TPFinal
{

	public class Game
	{
		public static int WIDTH = 12;       //anchura(cantidad de cartas).
		public static int UPPER = 35;       //superior  
		public static int LOWER = 25;       //inferior
		

		private Jugador player1 = new ComputerPlayer();
		private Jugador player2 = new HumanPlayer();
        List<int> naipesComputer = new List<int>() ;
        List<int> naipesHuman = new List<int>();
		private int limite;
		private bool juegaHumano = false;
        int nivel = 1;      //Esto es para la consulta "c".

        int limiteConsultas = 2;        //Limite de consultas.
        int limiteConsultasAux = 0;
        



        public Game()
		{
			var rnd = new Random();                 //Guardamos instancia de clase Random en una variable.
            limite = rnd.Next(LOWER, UPPER);        //Fijamos un limite de valor "random" que este entre 25 y 35.
			
			naipesHuman = Enumerable.Range(1, WIDTH).OrderBy(x => rnd.Next()).Take(WIDTH / 2).ToList();
			
			for (int i = 1; i <= WIDTH; i++) {
				if (!naipesHuman.Contains(i)) {
					naipesComputer.Add(i);
				}
			}


			player1.incializar(naipesComputer, naipesHuman, limite);
			player2.incializar(naipesHuman, naipesComputer, limite);
			
		}


        private void printScreen()
        {
            {
                    Console.WriteLine();
                    Console.WriteLine("Limite:" + limite.ToString());

                    if (juegaHumano == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("1) ¿Quiere hacer una consulta?");
                        Console.WriteLine("2) Jugar una carta");
                        String opcion = Console.ReadLine();
                        while (opcion == "1")
                        {
                            if (opcion == "1")
                            {
                                if (limiteConsultasAux < limiteConsultas)
                                {

                                    Console.Clear();
                                    Console.WriteLine("Consultas disponibles: " + (limiteConsultas - limiteConsultasAux));
                                    limiteConsultasAux = limiteConsultasAux + 1;


                                    Console.WriteLine("1) Imprimir todos los posibles resultados desde el punto en que " +
                                        "se encuentre el juego.");

                                    Console.WriteLine("2) Dado un conjunto de jugadas imprimir todos los posibles resultados.");
                                    Console.WriteLine("3) Dada una profundidad imprimir las jugadas a dicha profundidad.");



                                    string var = "";
                                    var = Console.ReadLine();
                                    switch (var)
                                    {

                                        case "1":


                                        Console.Clear();

                                        ComputerPlayer player1Aux = (ComputerPlayer)player1;

                                        ArbolGeneral<Carta> refe = player1Aux.obtenerReferencia();

                                        imprimirHojas(refe);

                                        Console.ReadKey(true);



                                        break;


                                        case "2":

                                        Console.Clear();

                                        ComputerPlayer player1Auxx = (ComputerPlayer)player1;

                                        ArbolGeneral<Carta> refex = player1Auxx.obtenerReferencia();

                                        Console.WriteLine("Ingrese un conjunto de jugadas separado por una coma. Ej: 4,2");


                                        string jugadas = Console.ReadLine();

                                        List<string> partes = new List<string>();

                                        partes = jugadas.Split(',').ToList();

                                        ArbolGeneral<Carta> newRef = nuevaReferencia(refex, partes);

                                        imprimirHojas(newRef);

                                        Console.ReadKey(true);


                                        break;


                                        case "3":

                                        Console.Clear();

                                        ComputerPlayer player1Auxxx = (ComputerPlayer)player1;

                                        ArbolGeneral<Carta> refexx = player1Auxxx.obtenerReferenciaRaiz();


                                        Console.WriteLine("Usted actualmente se encuentra en el nivel: " + nivel);

                                        refexx.ElegirNivel();

                                        Console.ReadKey(true);



                                        break;


                                    }

                                    Console.Clear();
                                    Console.WriteLine("Consultas disponibles: " + (limiteConsultas - limiteConsultasAux));

                                    Console.WriteLine("Limite:" + limite.ToString());






                                    Console.WriteLine("¿Desea hacer otra consulta?");
                                    Console.WriteLine("1) si");
                                    Console.WriteLine("2) no");
                                    opcion = Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Supero las consultas");
                                    opcion = "2";
                                    Console.ReadKey(true);

                                }
                            }







                        }
                        Console.Clear();

                        Console.WriteLine("Limite:" + limite.ToString());

                        nivel=nivel+2;      //Esto es para la consulta "c".

                    }

                
            }

        }


        public void imprimirHojas(ArbolGeneral<Carta> e)
        {

            if (e.esHoja())
            {
                int heu = e.getDatoRaiz().getHeuris();
                if (heu == -1)
                {
                    Console.WriteLine("La IA juega la carta:" + e.getDatoRaiz().getCarta() + " y pierde");
                }

                else
                {
                    Console.WriteLine("El humano juega la carta:" + e.getDatoRaiz().getCarta()+ " y pierde");

                }

            }

            else
            {
                foreach (var hijo in e.getHijos())
                {
                    imprimirHojas(hijo);

                }
            }


        }


        public ArbolGeneral<Carta> nuevaReferencia(ArbolGeneral<Carta> aux, List<string> partes)
        {
            if (partes.Count==0)
            {
                return aux;
            }
            else
            {

                

                for (int i = 0; i <= aux.getHijos().Count-1; i++)
                {
                    if (!(partes.Count == 0))       //Ponemos esto para evitar irnos del indice.
                    {
                        int e = int.Parse(partes[0]);
                        if (aux.getHijos()[i].getDatoRaiz().getCarta().Equals(e))
                        {

                            partes.RemoveAt(0);
                            

                            
                            aux = nuevaReferencia( aux.getHijos()[i], partes);


                        }
                    }
                }
            }


          
            return aux; //Nueva referencia







        }


        private void turn(Jugador jugador, Jugador oponente, List<int> naipes)
		{
			int carta = jugador.descartarUnaCarta();
			naipes.Remove(carta);
			limite -= carta;
			oponente.cartaDelOponente(carta); //Avisa al jugador que carta jugó el contrincante
            juegaHumano = !juegaHumano;       //Pone en true al humano.
		}
		
		
		
		private void printWinner()
		{
			if (!juegaHumano) {
				Console.WriteLine("Gano el Ud");
                Console.ReadKey(true);
			} else {
				Console.WriteLine("Gano Computer");
                Console.ReadKey(true);

            }

        }
		
		private bool fin()
		{
			return limite < 0;
		}
		
		public void play()
        {
            



            while (!this.fin())
            {

                this.printScreen();
                this.turn(player2, player1, naipesHuman); // Juega el usuario
                
                    if (!this.fin())
                    {
                        this.printScreen();
                        this.turn(player1, player2, naipesComputer); // Juega la IA
                    }

                string s = "";              ////**************Cartas IA

                foreach (var x in naipesComputer)
                {
                    s = s + x + ", ";
                }
                Console.WriteLine();
                Console.WriteLine("cartas IA: "+s);     ////****************

            }
            this.printWinner();
            this.nuevaPartida();
               

                
            
		}


        public void nuevaPartida()
        {
            Console.Clear();
            Console.WriteLine("Desea jugar una nueva partida?");
            Console.WriteLine("1) Si");
            Console.WriteLine("2) No");
            string select = Console.ReadLine();

            if(select=="1")
            {
                Console.Clear();


                Game game = new Game();
                game.play();

            }




        }
		
		
	}
}
