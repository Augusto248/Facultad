/*
 * Created by SharpDevelop.
 * User: augus
 * Date: 24/10/2018
 * Time: 19:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Trabajo_final
{
	/// <summary>
	/// Description of MENU.
	/// </summary>
	public class MENU
	{
		
		public void funcion_menu_banner()
		{
			Console.Clear();
			Console.WriteLine("***************************************\n" +
			                  "************"+ "    micritos    "+ "***********\n"+
			                 "***************************************\n");
		}
		
		public void funcion_menu_opciones()
		{
		   Console.WriteLine("¿A que modulo desea ingresar?\n");
			
			Console.WriteLine("1) Armado de recorridos");
			Console.WriteLine("2) Gestion de choferes");
			Console.WriteLine("3) Ventas de pasajes");
			Console.WriteLine("4) Estadisticas");
			Console.WriteLine("5) Salir del sistema");
		}
		
		public void funcion_menu_modulo1()
		{

			
			Console.WriteLine("1) Alta de terminales");
			Console.WriteLine("2) Alta de ómnibus");
			Console.WriteLine("3) Armado de recorridos");
			Console.WriteLine("4) Volver");
					
		}
		
		public void funcion_menu_modulo2()
		{

			Console.WriteLine("1) Alta de choferes"); 	
			Console.WriteLine("2) Asignacion de recorridos"); 
			Console.WriteLine("3) Volver"); 						

					
		}
		
		public void funcion_menu_modulo3()
		{

			Console.WriteLine("1) Alta de usuarios"); 	
			Console.WriteLine("2) Compra de pasajes"); 
			Console.WriteLine("3) Volver"); 						

					
		}
		
			public void funcion_menu_modulo4()
		{

			Console.WriteLine("1) Consultar total de pasajes vendidos"); 	
			Console.WriteLine("2) Consultar usuarios"); 
			Console.WriteLine("3) Consultar terminal como partida"); 	
			Console.WriteLine("4) Consultar terminal como arribo"); 		
			Console.WriteLine("5) Volver"); 									

					
		}
		
	}
}
