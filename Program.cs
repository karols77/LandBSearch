/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: k.szewczyk
 * Data: 06.02.2026
 * Godzina: 11:38
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Diagnostics;

namespace BinaryS
{
	class BinaryS
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			//Definicja wektora
			Random rand = new Random();
			int[] vdata = new int[100000000];
			for (int i = 0; i < vdata.Length; i++)
				vdata[i] = i + 1;
			
			//Konfigurowanie narzędzia diagnostycznego
			Stopwatch sw = new Stopwatch();
			
			//Rozruch
			for(int i=0; i<5; i++)
				LinearSearch(vdata, 100000000);
			
			//Pierwsze testy
			Testuj(vdata, 1, sw);
			
			//Środkowa liczba
			Testuj(vdata, 100000000 / 2, sw);

			//Daleka liczba
			Testuj(vdata, 100000000, sw);
			
			
			//Szukanie
			for (int i = 0; i < 20; i++) {
				//Zmienna losowa
				int x = rand.Next(1, 100000001);
				Testuj(vdata, x, sw);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		static void Testuj(int[] vdata, int x, Stopwatch sw)
		{
			long tavg = 0;
			int n = 0;
			//Test liniowy
			for (int i = 0; i < 10; i++) {
				sw.Restart();
				n = LinearSearch(vdata, x);
				sw.Stop();
				tavg += sw.ElapsedTicks;
			}
			Console.WriteLine("Szukanie zmiennej x={0} liniowo. Wynik n={1}. Cykle={2}", x, n, tavg / 5);
				
			//Test binarny
			tavg = 0;
			for (int i = 0; i < 10; i++) {
				sw.Restart();
				n = BinarySearch(vdata, x);
				sw.Stop();
				tavg += sw.ElapsedTicks;
			}
			Console.WriteLine("Szukanie zmiennej x={0} binarnie. Wynik n={1}. Cykle={2}", x, n, tavg / 5);
		}
		static int LinearSearch(int[] vdata, int number)
		{
			//Szukanie
			int n = vdata.Length - 1;
			int i = 0;
			int x;
			do {
				x = vdata[i++];
				if (x == number)
					return i - 1;
			} while(i <= n);
		
			//Powrót
			return -1;
		}
		static int BinarySearch(int[] vdata, int number)
		{
			//Szukanie
			int ia = 0;
			int ib = vdata.Length - 1;
			int n = ib / 2;
			int x;
			do {
				x = vdata[n];
				if (x == number)
					return n;
				else if (x < number) {
					ia = n + 1;
					n = ia + (ib - ia) / 2;
				} else {
					ib = n - 1;
					n = ia + (ib - ia) / 2;
				}
			} while (ia <= ib);
			
			//Powrót
			return -1;
		}
	}
}