/*
 * Created by SharpDevelop.
 * User: augus
 * Date: 24/10/2018
 * Time: 22:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Trabajo_final
{
	/// <summary>
	/// Description of CHOFER.
	/// </summary>
	public class CHOFER
	{
		private string nombre_chofer;
		private string apellido_chofer;
		private string dni_chofer;
		private static int legajo;	
		
		
		public bool[] dia_disponible=new bool[]{true,true,true,true,true,true,true};
				
	
		public CHOFER(String nom, String ape, String dni)														
		{
			
			nombre_chofer = nom;
			apellido_chofer = ape;
			dni_chofer = dni;
			
		}
		
			
		
		
		public void imprimirDatos()
		{
			
			Console.WriteLine(nombre_chofer +" "+ apellido_chofer);
			
		}
		
		public string DevolverDni()
		{
			return dni_chofer;
		}
		
		public int funcion_legajo_chofer()
		{
			legajo++;					
			return legajo;
		}
		
		
	}
}
