/*
 * Created by SharpDevelop.
 * User: augus
 * Date: 24/10/2018
 * Time: 15:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Trabajo_final
{
	/// <summary>
	/// Description of TERMINAL.
	/// </summary>
	public class TERMINAL
	{

		
		private string nombre_terminal;
		private  string nombre_ciudad;
		private int terminal_partida;
		private int terminal_llegada;

		
		public TERMINAL(string ter,string ciu)
		{
			nombre_terminal=ter;
			nombre_ciudad=ciu;			
		}
		
		
		
		public void funcion_imprimir_terminal()
		{
			Console.WriteLine(nombre_terminal);
		}
		
		public string devolver_nombreTerminal()
		{
			return nombre_terminal;
		}
		
		public void terminalPartida_Vendidos(int cantidad)
		{
			terminal_partida=terminal_partida+cantidad;
		}
		
		public void terminalLLegada_Vendidos(int cantidad)
		{
			terminal_llegada=terminal_llegada+cantidad;
			
		}
		
		public int Devolver_TerminalPartida_Vendido()
		{
			return terminal_partida;
		}
		
		public int Devolver_TerminalLLegada_Vendido()
		{
			return terminal_llegada;
		}
		

	}
}
