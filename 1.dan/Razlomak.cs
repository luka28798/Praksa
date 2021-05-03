using System;
using System.Collections.Generic;

namespace oop
{
    public class Razlomak
    {
        protected int brojnik;
        protected int nazivnik;

        public int nzv(int x,int  y)
        {
            while (x%y != 0)
            {
                int temp_x = 0;
                int temp_y = 0;
                temp_x = x;
                temp_y = y;
                x = temp_y;
                y = temp_x % temp_y;        
            }
            return y;
        }

        public Razlomak(int _brojnik, int _nazivnik)
        {
            this.brojnik = (int)(_brojnik/nzv(Math.Abs(_brojnik), Math.Abs(_nazivnik)));
            this.nazivnik = (int)(_nazivnik/(nzv(Math.Abs(_brojnik), Math.Abs(_nazivnik))));
        }
        // polimorfizam
        //overridanje operatora zbrajanja
        public static Razlomak operator +(Razlomak razlomak1, Razlomak razlomak2)
        {
            int sumaBrojnik = razlomak1.brojnik * razlomak2.nazivnik + razlomak1.nazivnik * razlomak2.brojnik;
            int sumaNazivnik = razlomak1.nazivnik * razlomak2.nazivnik;
            return new Razlomak(sumaBrojnik, sumaNazivnik);
        }
        // overloadanje
        public void recenica(Razlomak razlomak1, Razlomak razlomak2)
        {
            Console.WriteLine("Prosljeðena su 2 razlomka");
        }

        public void recenica(Razlomak razlomak1, Razlomak razlomak2, Razlomak razlomak3)
        {
            Console.WriteLine("Prosljeðena su 3 razlomka");
        }
        //overridanje ToString() f-je
        public override string ToString()
        {
            return brojnik + "/" + nazivnik;
        }
    }
    // inheritance
    public class PraviNepravi: Razlomak
    {
        public PraviNepravi(int _brojnik, int _nazivnik) : base(_brojnik, _nazivnik)
        {
            this.brojnik = _brojnik;
            this.nazivnik = _nazivnik;
        }
        public void Decide()
        {
            if (brojnik > nazivnik)
            {
                Console.WriteLine("Nepravi razlomak");
            }else if ( brojnik < nazivnik )
            {
                Console.WriteLine("Pravi razlomak");
            }
            else
            {
                Console.WriteLine("Ovaj razlomak jednak je 1");
            }
        }
    }
    // generics
    struct Generics<T> {
        public T brojnik;
        public T nazivnik;
        
    }
    // composition
    public class CompositionRazlomci
    {
        Razlomak razlomak;
        public CompositionRazlomci(Razlomak _razlomak)
        {
            razlomak = _razlomak;
        }
    }
    class Nasljeðivanje
    {
        static void Main(string[] args)
        {
            Razlomak razlomak1 = new Razlomak(5, 6);
            Razlomak razlomak2 = new Razlomak(2, 3);
            Razlomak razlomak3 = new Razlomak(9, 5);
            Razlomak razlomak4 = new Razlomak(25, 10);
            

            Razlomak zbroj = razlomak1 + razlomak2;
            Console.WriteLine(zbroj.ToString());
            Console.WriteLine(razlomak4.ToString());
            razlomak1.recenica(razlomak1, razlomak2, razlomak3);
            razlomak1.recenica(razlomak1, razlomak2);

            PraviNepravi prnpr1 = new PraviNepravi(4, 4);
            prnpr1.Decide();
            PraviNepravi prnpr2 = new PraviNepravi(4, 5);
            prnpr2.Decide();

            Generics<int> intRazlomak;
            intRazlomak.brojnik = 1;
            intRazlomak.nazivnik = 3;
            Console.WriteLine("intRazlomak = {0}/{1}", intRazlomak.brojnik, intRazlomak.nazivnik);

            Generics<float> floatRazlomak;
            floatRazlomak.brojnik = 3.14f;
            floatRazlomak.nazivnik = 5.34567f;
            Console.WriteLine("floatRazlomak = {0}/{1}", floatRazlomak.brojnik, floatRazlomak.nazivnik);

            Generics<string> stringRazlomak;
            stringRazlomak.brojnik = "tri";
            stringRazlomak.nazivnik = "pet";
            Console.WriteLine("stringRazlomak = {0} kroz {1}", stringRazlomak.brojnik, stringRazlomak.nazivnik);
        }
    }
}
