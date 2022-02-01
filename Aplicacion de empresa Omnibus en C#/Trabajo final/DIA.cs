/*
 * Created by SharpDevelop.
 * User: augus
 * Date: 25/10/2018
 * Time: 01:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Trabajo_final
{
	/// <summary>
	/// Description of DIA.
	/// </summary>
	public class DIA
	{
		
		public string[] dias=new string[]{"lunes","martes","miercoles","jueves","viernes","sabado","domingo"};
		
		public void funcion_imprimir_dias()
		{
			Console.WriteLine("1) Lunes");
			Console.WriteLine("2) Martes");
			Console.WriteLine("3) Miercoles");
			Console.WriteLine("4) Jueves");
			Console.WriteLine("5) Viernes");
			Console.WriteLine("6) Sabado");
			Console.WriteLine("7) Domingo");
		}
		
					
		
	}
}
