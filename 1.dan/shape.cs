using System;

namespace abstractExample
{
	// abstract class
	abstract class Shape
	{
		public abstract int Area();
		
	}

	class Kvadrat : Shape
    {
		public int a;

		public Kvadrat(int _a) { this.a = _a; }

        public override int Area()
        {
			Console.WriteLine(a * a);
			return 0;
        }
    }

	class Pravokutnik : Shape
	{
		public int a;
		public int b;

		public Pravokutnik(int _a, int _b) 
		{
			this.a = _a; 
			this.b = _b; 
		}

		public override int Area()
		{
			Console.WriteLine(a * b);
			return 0;
		}
	}
	// interface
	class Shapes : IKvadrat, IPravokutnik
	{
		public void KvadratIspis()
		{
			Console.WriteLine("Ovo je kvadrat");
		}

		public void PravokutnikIspis()
		{
			Console.WriteLine("Ovo je pravokutnik");
		}
	}

	interface IKvadrat
	{
		void KvadratIspis();
	}

	interface IPravokutnik
	{
		void PravokutnikIspis();
	}

	class Nasljeđivanje
	{
		static void Main(string[] args)
		{
			Kvadrat k = new Kvadrat(5);
			Pravokutnik p = new Pravokutnik(5, 6);
			Console.WriteLine("Površina pravokutnika stranica a=5 i b=6");
			p.Area();
			Console.WriteLine("Površina kvadrata stranica a=5");
			k.Area();
			IKvadrat kvadrat = new Shapes();
			kvadrat.KvadratIspis();
			IPravokutnik pravokutnik = new Shapes();
			pravokutnik.PravokutnikIspis();

		}
	}
}
