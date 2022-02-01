/*
 * Created by SharpDevelop.
 * User: augus
 * Date: 24/10/2018
 * Time: 16:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Trabajo_final
{
	/// <summary>
	/// Description of OMNIBUS.
	/// </summary>
	public class OMNIBUS
	{
				
		private string modelo;
		private string marca;
		private string capacidad;
		private string tipo;
		private static int unidad=0;
		
		private bool[] dia_disponible=new bool[]{true,true,true,true,true,true,true};
						
	
		public OMNIBUS(string mod,string mar,string cap,string tip)
		{
			modelo=mod;
			marca=mar;
			capacidad=cap;
			tipo=tip;
		}
			
		
		public int funcion_numero_unidad()
		{
			unidad=unidad+1;
			return unidad;
		}
		
		public bool[] devolver_disponibilidad()
		{
			return dia_disponible;
		}
		
		public void imprimirdatos()
		{
			Console.WriteLine(" ("+modelo+" - "+marca+" , "+tipo+" , "+capacidad+")");
		}
		
		public string omnibus_tipo()
		{
			return tipo;
		}
		
	}
}
