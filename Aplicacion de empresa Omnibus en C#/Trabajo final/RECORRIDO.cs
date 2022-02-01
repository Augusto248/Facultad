/*
 * Created by SharpDevelop.
 * User: augus
 * Date: 31/10/2018
 * Time: 12:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Trabajo_final
{
	/// <summary>
	/// Description of RECORRIDO.
	/// </summary>
	public class RECORRIDO
	{
		
		private CHOFER c;
		private	OMNIBUS omni;
		private string Dia;
		private ArrayList terminales;	
		private string primerParada="";
		private	string segundaParada="";

		
		
		public RECORRIDO(CHOFER cho,OMNIBUS om,string d,ArrayList ter)
		{
			c=cho;
			omni=om;
			Dia=d;
			terminales=ter;	
			
		}
		
		

		
		public string DevolverTipoOmnibus()
		{
			
			string tipo=(string)omni.omnibus_tipo();	//LE RESTO "2" PORQUE EL ULTIMO ELEMENTO ES UN

			return tipo;;			
		}
		
		
		
		public string Devolverdia()
		{
			
			return Dia;
			
		}
		

		
		public int imprimirTerminales(string parada1,string parada2,string dia,string tipo,int numeros)
		{
			ArrayList paradasIntermediasDeIda=new ArrayList();
			ArrayList paradasIntermediasDeVuelta=new ArrayList();
			
			int x=0;
			int y=0;
			int v=0;

			
			foreach(string z in terminales)
			{
				if(z==parada1)
				{
					primerParada=z;					//ALMACENO CUAL FUE LA TERMINAL ELEGIDA POR EL USUARIO.
					x=1;
				}
				
				else
				{
					if(x==0)
					{
						paradasIntermediasDeVuelta.Add(z);
					}
					
					if(x==1)
					{
						paradasIntermediasDeIda.Add(z);
					}
				}
				
			}	
			
			foreach(string z in terminales)
			{			
				if(z==parada2)
				{
					segundaParada=z;
					y=1;
				}
				
				else
				{
					if(y==0)
					{
						paradasIntermediasDeVuelta.Remove(z);	
					}
					
					if(y==1)
					{
						paradasIntermediasDeIda.Remove(z);
					}
				}
				
			}	
				
				if((x==1)&&(y==1))
				{
					if(paradasIntermediasDeIda.Count-1>=0)
					{
					
					int cantidad=paradasIntermediasDeIda.Count-1;
					Console.WriteLine(numeros+") Saliendo de "+primerParada+ " y llegando a "+segundaParada+" ("+ cantidad +" paradas intermedias, "+dia+", "+tipo+")");

					v=1;		//SI ENCONTRO UN ITINERARIO CON LAS PARADAS ESPECIFICADAS, ENTONCES "V" ES IGUAL A 1
					}
					
					if(paradasIntermediasDeVuelta.Count-1>=0)
					{
					
					int cantidad=paradasIntermediasDeVuelta.Count-1;
					Console.WriteLine(numeros+") Saliendo de "+primerParada+ " y llegando a "+segundaParada+" ("+ cantidad +" paradas intermedias, "+dia+", "+tipo+")");

					v=1;	
					}
					
				}
				
				

			return v;
		}
		
	
		
	}
}
