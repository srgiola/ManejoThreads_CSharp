using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;


namespace threads
{
	class Program
	{
		public static Stack<string> cadenas = new Stack<string>();
		public static Thread t1, t2, t3, t4;
		private static void Go() // t1 y t2
		{
			while (true)
			{
				Thread thread = Thread.CurrentThread;
				string fecha = DateTime.Now.ToString("yyyy-MM-dd hh_mm_ss");
				string cadena = "Thread " + thread.Name + " " + fecha;
				cadenas.Push(cadena);
				Console.WriteLine(cadena);

				Thread.Sleep(500);

				t3 = new Thread(Go2);
				t3.Name = "03";
				t3.Start();

				t4 = new Thread(Go2);
				t4.Name = "04";
				t4.Start();
				
			}
		}

		private static void Go2() // t3 y t4
		{
			while (true)
			{
				Thread thread = Thread.CurrentThread;
				Thread.Sleep(10000);
				string cadena = cadenas.Pop();
				string ruta = "C:\\Users\\srgio\\Desktop\\Threads\\" + cadena;
				using (StreamWriter log = File.AppendText(ruta))
				{
					log.WriteLine("log");
				}
			}
		}
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("1 - Iniciar Thread 01");
				Console.WriteLine("2 - Inicair Thread 02");
				Console.WriteLine("3 - Pausar Thread 01");
				Console.WriteLine("4 - Pausar Thread 02");
				Console.WriteLine("5 - Pausar Thread 03");
				Console.WriteLine("6 - Pausar Thread 04");
				Console.WriteLine("7 - Eliminar Thread 01");
				Console.WriteLine("8 - Eliminar Thread 02");
				Console.WriteLine("9 - Eliminar Thread 03");
				Console.WriteLine("10 - Eliminar Thread 04");
				switch (Console.ReadLine())
				{
					case "1":
						t1 = new Thread(Go);
						t1.Name = "01";
						t1.Start();
						
						break;
					case "2":
						t2 = new Thread(Go);
						t2.Name = "02";
						t2.Start();
						break;
					case "3":
						
						break;
					case "4":
						break;
					case "5":
						break;
					case "6":
						break;
					case "7":
						break;
					case "8":
						break;
					case "9":
						break;
					case "10":
						break;
					default:
						Console.WriteLine("Opción incorrecta");
						break;
				}
			}
		}
	}
	public class Cadena
	{
		public string texto { get; set; }
		public bool taken { get; set; }
	}
}
