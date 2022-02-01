/*
 * Created by SharpDevelop.
 * User: augus
 * Date: 12/11/2018
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Trabajo_final
{
	/// <summary>
	/// Description of VENTA.
	/// </summary>
	public class VENTA
	{
		
		private static int pasajes;
		
		public VENTA(int pas)
		{
			pasajes=pasajes+pas;			
		}
		
		
		public static void cantidadPasajes()
		{
			Console.WriteLine("En total se han vendido "+pasajes+" pasajes");
		}
		
		
	
		
	}
}
