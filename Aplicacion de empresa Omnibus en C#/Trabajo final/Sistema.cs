/*
 * Created by SharpDevelop.
 * User: Alumnos-UNAJ
 * Date: 30/10/2018
 * Time: 21:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Trabajo_final
{
	/// <summary>
	/// Description of Sistema.
	/// </summary>
	public class Sistema
	{
		
		private ArrayList lista_terminales=new ArrayList();		//LISTA ORIGINAL DE TERMINALES.
		private ArrayList lista_terminales_copia=new ArrayList();	//ES UNA COPIA DE LA LISTA ORIGINAL DE TERMINALES.
		
		private ArrayList lista_terminales_elegidas=new ArrayList();	//LISTA DE RECORRIDOS TEMPORAL.
		private ArrayList lista_recorridos_armados=new ArrayList();		//LISTA QUE ALMACENA CADA RECORRIDO ARMADO.
		
		
		
		private ArrayList lista_omnibus = new ArrayList();
		private ArrayList lista_choferes = new ArrayList();
		private ArrayList lista_recorridos=new ArrayList();
		private ArrayList lista_usuarios=new ArrayList();

		


		

		DIA OBJETO_dia=new DIA();
		MENU OBJETO_menu=new MENU();

		
		public void iniciarSistema()
		{
			
			



			

			

			string var="";
			
			
			while(var!="5") //PARA QUE SE REPITA ESTE MENU O SE TERMINE EL PROCESO
			{
				
				try{
				
				OBJETO_menu.funcion_menu_banner();
				OBJETO_menu.funcion_menu_opciones();
				
				
				var=Console.ReadLine();
				
				switch(var)	//SWITCH DEL MENU PRINCIPAL
				{
						
						
					case "1":    //INICIA EL CASE 1 DEL MODULO 1
						
						while(var!="4") //PARA QUE SE REPITA EL MENU DEL MODULO 1 Y/O VOLVER AL ANTERIOR MENU.
						{
							

							OBJETO_menu.funcion_menu_banner();
							OBJETO_menu.funcion_menu_modulo1();

							var=Console.ReadLine();
							
							switch(var)		//SWITCH DEL MENU DEL MODULO 1
							{
									
								case "1":   //MODULO 1-ALTA DE TERMINALES
									
									
									Console.WriteLine("Ingrese el nombre de la terminal");
									string nombre_terminal=Console.ReadLine();
									Console.WriteLine("Ingrese el nombre de la ciudad");
									string nombre_ciudad=Console.ReadLine();
									TERMINAL T=new TERMINAL(nombre_terminal,nombre_ciudad);
									lista_terminales.Add(T);
									
									Console.WriteLine("\nLa terminal fue dada de alta correctamente!");
									Console.WriteLine("Presione una tecla para continuar");
									Console.ReadKey(true);
									
									break;
									
									
									
								case"2":	//MODULO 1-ALTA DE OMNIBUS
									
									Console.WriteLine("Ingrese la marca");
									string marca=Console.ReadLine();
									Console.WriteLine("Ingrese el modelo");
									string modelo=Console.ReadLine();
									Console.WriteLine("Ingrese la capacidad");
									string capacidad=Console.ReadLine();
									Console.WriteLine("Ingrese el tipo");
									string tipo=Console.ReadLine();
									
									OMNIBUS o=new OMNIBUS(marca,modelo,capacidad,tipo);
									lista_omnibus.Add(o);
									
									int num=o.funcion_numero_unidad();
									
									
									Console.WriteLine("\nEl omnibus fue dada de alta correctamente!. A la unidad se le" +
									                  " asigno el numero "+ num);
									Console.WriteLine("Presione una tecla para continuar");
									Console.ReadKey(true);

									break;
									
									
									
								case"3":	//MODULO 1-ARMADO DE RECORRIDOS
									
						
									
									OBJETO_menu.funcion_menu_banner();
									
									funcion_hacer_copia();		//TODOS LOS ELEMENTOS DE "lista_terminales" LOS
																//AGREGO EN "lista_terminales_copia".
									
									Console.WriteLine("Seleccione las terminales del recorrido, " +
									                  "ingrese 0 para finalizar");
									

									int y=funcion_imprimir_terminales_de_copia();

									funcion_imprimir_recorridos_elegidos(y);
									
									int elegir=int.Parse(Console.ReadLine());
									
									while(elegir!=0)
									{
										
										Console.Clear();
										OBJETO_menu.funcion_menu_banner();
										
										Console.WriteLine("Seleccione las terminales del recorrido, " +
										                  "ingrese 0 para finalizar.");
										
										Asignar_terminalEn_ListaTerminalElegida(elegir);																		
										Eliminar_terminal_deCopia(elegir);
										
										
										

										funcion_imprimir_terminales_de_copia();

										funcion_imprimir_recorridos_elegidos(y);
										elegir=int.Parse(Console.ReadLine());
									}
									
									
									funcion_listaFinal_recorridos();	//ESTA FUNCION AGREGA UN RECORRIDO COMPLETO
									//A MI "lista_recorridos_armados".
									
									
									lista_terminales_elegidas.Clear();	//ELIMINO TODO LO QUE HAYA EN LA
									//"lista_terminales_elegidas".
									
									lista_terminales_copia.Clear();

									Console.WriteLine("El recorrido se ha dado de alta correctamente");
									Console.WriteLine("Presione una tecla para continuar.");
									
									Console.ReadKey(true);
									
									
			
									
									
									break;
							}
							
						} //TERMINA EL WHILE DEL MODULO 1. EN CASO DE QUE NO SE CUMPLA LA CONDICION,
						//SE VUELVE AL WHILE DEL MODULO 1.
						
						break; //TERMINA EL CASE 1 DEL MODULO 1.
						
						
						
					case "2":    //INICIA EL CASE 2 DEL MODULO 2
						
						while(var!="3")
						{
							
							OBJETO_menu.funcion_menu_banner();
							OBJETO_menu.funcion_menu_modulo2();
							
							
							
							var=Console.ReadLine();
							
							switch(var)
							{
								case "1":	//MODULO 2-ALTA DE CHOFERES
									

									Console.WriteLine("Ingrese el nombre");
									string nombre_chofer=Console.ReadLine();
									Console.WriteLine("Ingrese el apellido");
									string apellido_chofer=Console.ReadLine();
									Console.WriteLine("Ingrese el DNI");
									string dni_chofer=Console.ReadLine();
									
									CHOFER cho = new CHOFER(nombre_chofer,apellido_chofer,dni_chofer);
									VerificarChofer(cho);
									
									
									Console.ReadKey(true);
									
									

									//HACER YA QUE "CHOFER" ES UN TIPO DE DATO.
									
									
									break;
									
									
								case "2":	//MODULO 2-ASIGNACION DE RECORRIDOS
									


									
									funcion_imprimir_choferes();
									int chofer_elegido=int.Parse(Console.ReadLine());
									
									funcion_imprimir_omnibus();
									int omnibus_elegido=int.Parse(Console.ReadLine());
									
									imprimir_recorridosArmados();
									int recorrido_elegido=int.Parse(Console.ReadLine());
									
									OBJETO_dia.funcion_imprimir_dias();
									int dia_elegido=int.Parse(Console.ReadLine());
									
									funcion_verificar_chofer_y_omnibus(chofer_elegido,omnibus_elegido,dia_elegido,recorrido_elegido);
									
									
									Console.WriteLine("Presione una tecla para continuar.");
									Console.ReadKey(true);
									
									break;
							}
							
						}
						
						break; //TERMINA EL CASE 2 DEL MODULO 2.
						
						
						

					case "3":		//INICIA EL CASE 3 DEL MODULO 3
												
						
						var="0";	//LO DEJO EN "0" PARA QUE ENTRE AL WHILE.
						
						while(var!="3")
						{
						
						OBJETO_menu.funcion_menu_banner();
						OBJETO_menu.funcion_menu_modulo3();
						
						var=Console.ReadLine();
						
						switch(var)
						{
							case "1":
								
								Console.WriteLine("Ingrese el nombre");
								string nombre=Console.ReadLine();
								Console.WriteLine("Ingrese el apellido");
								string apellido=Console.ReadLine();
						     	Console.WriteLine("Ingrese el dni");
						     	string dni=Console.ReadLine();
						     	Console.WriteLine("Ingrese la fecha de nacimiento");	
								string fecha=Console.ReadLine();

								USUARIO usuario=new USUARIO(nombre,apellido,dni,fecha);

								verificar_usuario(usuario);															
								
								Console.WriteLine("Presione una tecla para continuar");
								Console.ReadKey(true);

								
								break;
								
								
							case "2":
								
								Console.WriteLine("Ingrese el numero de usuario");
								int user_number=int.Parse(Console.ReadLine());
								Console.WriteLine("Ingrese el dni del usuario");
								string user_dni=Console.ReadLine();
								login_usuario(user_number,user_dni);
								Console.ReadKey(true);
								
								break;
								
								
								
							
						
						}
						
						}
						

						
						
						break;		//TERMINA EL CASE 3 DEL MODULO 3.
						
						
					case "4":
						
						var="0";	//LO DEJO EN "0" PARA QUE ENTRE AL WHILE.
						
						while(var!="5")
						{
						
						OBJETO_menu.funcion_menu_banner();
						OBJETO_menu.funcion_menu_modulo4();
						
						var=Console.ReadLine();
						
						switch(var)
						{
							case "1":
								
								VENTA.cantidadPasajes();
								Console.ReadKey(true);
								break;
								
							case "2":
								
								VentasPorUsario();
								
								Console.ReadKey(true);
								break;
								
							case "3":
								
								TerminalPartida();
								
								Console.ReadKey(true);
								
								break;
							
							case "4":
								
								TerminalArribo();
								
								Console.ReadKey(true);
								
								break;
						}
						

						
						}
						
						
					var="0";					
					break;
						
						

						
						
				}  //FINALIZA EL SWITCH DEL MENU PRINCIPAL
				
				Console.Clear();   //LIMPIA LA CONSOLA ANTES DE VOLVER AL MENU ORIGINAL
				
				
				}//FInalizza el try
			
			
			
				catch(FormatException)
				{
					Console.WriteLine("\nError de formato! Volviendo al menu principal");
					Console.ReadKey(true);
				}
				
				catch(ArgumentOutOfRangeException)
				{
					Console.WriteLine("\nError de indice! Volviendo al menu principal");
					Console.ReadKey(true);
				}
				
				
				
				
			} //SE VUELVE AL WHILE DEL MENU PRINCIPAL SINO SE CUMPLE LA CONDICION.
					
			
		}
		
		
		
		
		
		
		
		
		
		
		
			//***************FUNCIONES DEL SISTEMA.*******************//
			
			
			
			public void display(int x, int y, int num ,string s)
			{
				Console.SetCursorPosition(x,y);
				Console.Write(num+s);
			}
			
			public void display2(int x, int y)
			{
				Console.SetCursorPosition(x,y);
			}
			
		
		
		
		
		public void funcion_hacer_copia()			//HAGO UNA COPIA
		{
			foreach(TERMINAL t in lista_terminales)
			{
				lista_terminales_copia.Add(t);
			}
		}
		
		
		
		public int funcion_imprimir_terminales_de_copia()
		{

			
			int numero=1;
			int coordenadaY=6;
			foreach(TERMINAL t in lista_terminales_copia)
			{

				
				display(0,coordenadaY,numero,") "+t.devolver_nombreTerminal());
				coordenadaY=coordenadaY+1;
				numero++;

			}
			
			
			display2(0,coordenadaY);

			
			numero=0;
			
			return coordenadaY+1;		//devuelve la ultima coordenada en "y" pero aumentado en "1".
		}
		

		
		
		
		public void Asignar_terminalEn_ListaTerminalElegida(int elegir)
		{
			
			lista_terminales_elegidas.Add(lista_terminales_copia[elegir-1]);
			
		}
		
		public void Eliminar_terminal_deCopia(int elegir)
		{
			
			lista_terminales_copia.RemoveAt(elegir-1);
			
		}
		
		
		
		public void funcion_imprimir_recorridos_elegidos(int UltimaCoordenadaY)
		{
			int numero=1;
			
			int coordenadaY=6;
			foreach(TERMINAL r in lista_terminales_elegidas)
			{
				display(50,coordenadaY,numero,") "+r.devolver_nombreTerminal());
				coordenadaY=coordenadaY+1;
				numero++;
			}

			display2(0,UltimaCoordenadaY);  //Deja el "set cursor" en la ultima coordenada en "y" recibida por parametro.	
		}
		
		
		
			
		
		
		
		public void funcion_listaFinal_recorridos()	  //VOY A TOMAR LO QUE HAYA EN LA "lista_terminales_elegidas",
													  //Y LO VOY A AGREGAR TODO EN LA "lista_recorridos_armados".
		{

			string concatenado="";
			foreach(TERMINAL t in lista_terminales_elegidas)
			{
				concatenado=concatenado+t.devolver_nombreTerminal()+"-";

			}
			
				lista_recorridos_armados.Add(concatenado);
				concatenado="";			
		}
		
		
		
		public void funcion_imprimir_recorridos_armados()
		{
			int numero=1;
			foreach(string r in lista_recorridos_armados)
			{
				Console.WriteLine(numero+") "+r);
				numero++;
			}
		}
		
		
		
		public void VerificarChofer(CHOFER cho)
		{
			int x=0;
			int legajo;
			if(lista_choferes.Count==0)
			{
				lista_choferes.Add(cho);
				legajo=cho.funcion_legajo_chofer();
				
				Console.WriteLine("El chofer fue dado de alta correctamente. Su legajo es el numero " + legajo );
				Console.WriteLine("Presione una tecla para continuar");
				x=1;
			}
			
			else
			{
			
				foreach(CHOFER c in lista_choferes)
				{
					if(c.DevolverDni()==cho.DevolverDni())
					{
						Console.WriteLine("Ya existe un chofer con ese DNI en la empresa");
						Console.WriteLine("Presione una tecla para continuar");
						x=1;
					}		
				}		
			}
			
			if(x==0)			
			{
			lista_choferes.Add(cho);
			legajo=cho.funcion_legajo_chofer();
			Console.WriteLine("El chofer fue dado de alta correctamente. Su legajo es el numero " + legajo );
			Console.WriteLine("Presione una tecla para continuar");
			}
			
		}
		
		
		
		
		
		public void funcion_imprimir_choferes()
		{
			int numero = 0;
			foreach( CHOFER c in lista_choferes)
			{
				Console.Write(++numero +") ");
				c.imprimirDatos();
			}
			
			numero=0;
		}
		
		
		public void funcion_imprimir_omnibus()
		{
			int numero = 0;
			foreach( OMNIBUS o in lista_omnibus)
			{
				Console.Write(++numero +") "+numero);
				o.imprimirdatos();
				
			}
			
			numero=0;
		}
		
		
		public void imprimir_recorridosArmados()
		{
			int numero = 1;
			foreach( string x in lista_recorridos_armados)
			{
			Console.WriteLine(numero+") "+x);
			numero++;
			}
			numero=0;
		}
		
		public void funcion_verificar_chofer_y_omnibus(int chofer_elegido,int omnibus_elegido,int dia,int recorrido)
		{
			
			int x=0;
			int y=0;

			
		
			CHOFER chofer=(CHOFER)lista_choferes[chofer_elegido-1];		//FUNCIONA COMO PUNTERO.
			
			if(chofer.dia_disponible[dia-1]==true)
			{
				Console.WriteLine("El chofer fue asignado correctamente.");
				chofer.dia_disponible[dia-1]=false;
				
			}
			
			else
			{
				Console.WriteLine("El chofer ya hace un viaje ese dia.");
				x=1;

			}
			
			
			
			OMNIBUS omni=(OMNIBUS)lista_omnibus[omnibus_elegido-1];
			
			if(omni.devolver_disponibilidad()[dia-1]==true)
			{
				Console.WriteLine("El omnibus fue asignado correctamente.");
				omni.devolver_disponibilidad()[dia-1]=false;
			}
			
			else
			{
				Console.WriteLine("El omnibus ya esta reservado ese dia.");
				y=1;
			}
			
			
			if(x==1)
			{
				omni.devolver_disponibilidad()[dia-1]=true;
			}
			
			if(y==1)
			{
				chofer.dia_disponible[dia-1]=true;
			}
			
			if(x==1 & y==1)
			{
				omni.devolver_disponibilidad()[dia-1]=false;
				chofer.dia_disponible[dia-1]=false;
				
			}
			
			if(x==0 & y==0)			//SI EL CHOFER Y EL OMNIBUS NO SE REPITE, ENTONECS QUE SE AGREGUE
									//TODO A LA LISTA.
			{
				string seleccionado=elegirRecorrido(recorrido-1);			
				RECORRIDO OBJETO_recorrido=new RECORRIDO(chofer,omni,OBJETO_dia.dias[dia-1],funcion_slipt(seleccionado));
				lista_recorridos.Add(OBJETO_recorrido);	//ESTA LISTA TIENE EL RECORRIDO ARMADO CON EL CHOFER, OMNBIUS,
														//DIA, Y TERMINALES POR LAS QUE PASA.
				Console.WriteLine("La asignacion del recorrido fue dada de alta correctamente.");
			}
			
			
			
			
			x=0;
			y=0;			
			
		}
		
		
		public string elegirRecorrido(int elegir)
		{
			string seleccionado=(string)lista_recorridos_armados[elegir];
			return seleccionado;
		}
		
		
		public ArrayList funcion_slipt(string seleccionado)	//HAGO UN SLIPT DEL STRING Y AGREGO CADA ELELMENTO
		{													//EN UN LISTA.
			ArrayList temporal=new ArrayList();
			
			string [] partes;
					
	 		partes=seleccionado.Split('-');
	 		
	 		foreach(string x in partes)
	 		{
			
	 			temporal.Add(x);
	 			
	 		}
	 		
	 		return temporal;
	 				
		}
		
		
		
		public void verificar_usuario(USUARIO user)
		{
			int x=1;
			int z=1;
			
			if(lista_usuarios.Count==0)
			{
				lista_usuarios.Add(user);
				Console.WriteLine("El usuario fue dado de alta correctamente con el numero "+
				user.funcion_numero_usuario());
				x=0;			
			}
			

			if(x==1)
			{
			
			foreach(USUARIO u in lista_usuarios)
			{
				if(u.funcion_dni_usuario()==user.funcion_dni_usuario())
				{
					Console.WriteLine("Ya existe un usuario con ese dni en el sistema");
					z=0;
				}			
			}
			
			if(z==1)
			{
				lista_usuarios.Add(user);
				Console.WriteLine("El usuario fue dado de alta correctamente con el numero "+
				user.funcion_numero_usuario());
			}
			
			}
		
		}
		
		
		public void login_usuario(int numero,string dni)
		{
			int x=1;
			
			foreach(USUARIO user in lista_usuarios)
			{
				if(user.funcion_datos_usuario()==numero+dni)
				{
					x=0;
					seleccionar_terminal(user);
					
				}
				
				
			}	
				
				if(x==1)
				{
					Console.WriteLine("El usuario solicitado no existe en el sistema");
				}
			
		}
		
		
		public void seleccionar_terminal(USUARIO user)
		{
			OBJETO_menu.funcion_menu_banner();
			Console.WriteLine("Seleccione la terminal de partida\n");
			int numero=1;
			int x=0;
			int z=1;
			int condicion=0;
			
			foreach(TERMINAL ter in lista_terminales)
			{	
				Console.Write(numero+")");
				ter.funcion_imprimir_terminal();
				numero++;
			}
			
			int var=int.Parse(Console.ReadLine());
			TERMINAL term=(TERMINAL)lista_terminales[var-1];
			string terminalPartida=term.devolver_nombreTerminal();
			

			
			OBJETO_menu.funcion_menu_banner();
			Console.WriteLine("Seleccione la terminal de arribo\n");
			numero=1;
			
			foreach(TERMINAL ter in lista_terminales)
			{	
				Console.Write(numero+")");
				ter.funcion_imprimir_terminal();
				numero++;
			}
			
			int var2=int.Parse(Console.ReadLine());
			TERMINAL term2=(TERMINAL)lista_terminales[var2-1];
			string terminalArribo=term2.devolver_nombreTerminal();
			
			if(terminalPartida==terminalArribo)
			{
				Console.WriteLine("La terminal de partida y arribo es la misma");
				Console.WriteLine("Presione una tecla para continuar");
			}
			
			else
			{
				
				OBJETO_menu.funcion_menu_banner();
				Console.WriteLine("Seleccione el itinerario\n");
				int numeros=1;
				ArrayList Lista_Itinerarios=new ArrayList();
				ArrayList Itinerario_Elegido=new ArrayList();

				
				foreach(RECORRIDO r in lista_recorridos)
				{
					
					string tipo=r.DevolverTipoOmnibus();
					string dia=r.Devolverdia();

					
					condicion=r.imprimirTerminales(terminalPartida,terminalArribo,dia,tipo,numeros);
					
					if(condicion==1)	
					{					
						numeros++;								
						z=0;								
						x=1;

					}						
				}
				
				numeros=0;
				
					
				
								
				if(x==1)
				{
					
				comprarPasaje(user,terminalPartida,terminalArribo);				
				
				}
				
				if(z==1)
			{
				Console.WriteLine("No existe ningun recorrido con las terminales de partida y arribo solicitadas.");
				Console.WriteLine("Presione una tecla para continuar.");				
				}
						
				
			}
											
		}
		
		
		
		public void comprarPasaje(USUARIO us,string terminalPartida,string terminalArribo)
		{
			
			
			int elegir=int.Parse(Console.ReadLine());
				
			Console.WriteLine("Cuantos pasajes desea?");
			int cantidad=int.Parse(Console.ReadLine());
			
														
			foreach(USUARIO u in lista_usuarios)
			{
				if(u.funcion_datos_usuario()==us.funcion_datos_usuario())
				{
					u.Pasaje_comprado(cantidad);						//INDICO LA CANTIDAD DE PASAJES 
				}														//QUE COMPRO EL USUARIO

			}
			
			foreach(TERMINAL t in lista_terminales)
			{
				if(t.devolver_nombreTerminal()==terminalPartida)
				{
					t.terminalPartida_Vendidos(cantidad);
				}
			}
			
			foreach(TERMINAL t in lista_terminales)
			{
				if(t.devolver_nombreTerminal()==terminalArribo)
				{
					t.terminalLLegada_Vendidos(cantidad);
				}
			}
			
	
			VENTA OBJETO_venta=new VENTA(cantidad);
			
			Console.WriteLine("La venta se ha realizado con exito");
			Console.WriteLine("Presione una tecla para continuar");
			
		}
		
		
		
		public void VentasPorUsario()
		{
			Console.WriteLine("\nListado de ventas por usuario");
			foreach(USUARIO v in lista_usuarios)
			{
				Console.WriteLine(v.funcion_nombre_Apellido_usuario()+" ("+v.DevolverPasajes_comprados()+")");
			}
		}
		
		
		public void TerminalPartida()
		{
			Console.WriteLine("\nListado de terminales como partida");
			foreach(TERMINAL t in lista_terminales)			
			{												

				Console.WriteLine(t.devolver_nombreTerminal()+" ("+t.Devolver_TerminalPartida_Vendido()+")");
					
				
			}
		}
		
			public void TerminalArribo()
		{
			Console.WriteLine("\nListado de terminales como arribo");
			foreach(TERMINAL t in lista_terminales)
			{
				Console.WriteLine(t.devolver_nombreTerminal()+" ("+t.Devolver_TerminalLLegada_Vendido()+")");
			}
		}
		
		
	
		
		
		
		

		
	}
}
