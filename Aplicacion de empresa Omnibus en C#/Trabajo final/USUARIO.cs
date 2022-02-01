/*
 * Created by SharpDevelop.
 * User: augus
 * Date: 4/11/2018
 * Time: 01:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Trabajo_final
{
	/// <summary>
	/// Description of USUARIO.
	/// </summary>
	public class USUARIO
	{
		
		private string usuario_nombre;
		private string usuario_apellido;
		private string usuario_dni;
		private string usuario_fecha;
		private static int numero;			
		private int numero_user;
		private int pasajesComprados;
		
		public USUARIO(string nom,string ape,string dni,string fecha)
		{
			usuario_nombre=nom;
			usuario_apellido=ape;
			usuario_dni=dni;
			usuario_fecha=fecha;

				
		}
		
		public int funcion_numero_usuario()
		{
			numero++;			
			numero_user=numero;
			return numero;
		}
		
		public string funcion_nombre_Apellido_usuario()
		{
			return usuario_nombre+" "+usuario_apellido;
		}
		
		public string funcion_dni_usuario()
		{
			return usuario_dni;
		}
		
		public string funcion_datos_usuario()
		{
			return numero_user+usuario_dni;
		}
		
		public void Pasaje_comprado(int cant)
		{
			pasajesComprados=pasajesComprados+cant;
		}
		
		public int DevolverPasajes_comprados()
		{
			return pasajesComprados;
		}
		
	}
}
