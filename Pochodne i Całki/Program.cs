using System;

namespace Pochodne_i_Całki
{
    class Program
    {
        static double funkcja(double x)
        {
            return (x*x + 3*x);
        }

        static double f(double x, double y)
        {
            return (x * x + 3 * x);
        }

        static void rozniczkowanie_prawostronne()
        {           
            double s, x, n;
            Console.WriteLine("Podaj krok: ");
            n = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj x: ");
            x = Convert.ToDouble(Console.ReadLine());
            s = (funkcja(x + n) - funkcja(x))/n;          
            Console.WriteLine(s);
        }

        static void rozniczkowanie_obustronne()
        {
            double s, x, n;
            Console.WriteLine("Podaj krok: ");
            n = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj x: ");
            x = Convert.ToDouble(Console.ReadLine());
            s = ((funkcja(x + n) - funkcja(x - n))) / (2*n);           
            Console.WriteLine(s);
        }

        static void metoda_prostokatow()
        {
            int n;
            double xp, xk, dx;
            double s = 0;
            Console.WriteLine("Podaj liczbę prostokątów: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj początek przedziału całkowania: ");
            xp = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj koniec przedziału całkowania: ");
            xk = Convert.ToDouble(Console.ReadLine());
            dx = (xk - xp) / n;
            for(int i = 0; i < n; i++)
            {
                s += funkcja(xp + i * dx);
            }
            s *= dx;
            Console.WriteLine(s);
        }

        static void metoda_trapezow()
        {
            int n;
            double xp, xk, dx;
            double s = 0;
            Console.WriteLine("Podaj liczbę trapezów: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj początek przedziału całkowania: ");
            xp = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj koniec przedziału całkowania: ");
            xk = Convert.ToDouble(Console.ReadLine());
            dx = (xk - xp) / n;
            for (int i = 0; i < n; i++)
            {
                s += funkcja(xp + i * dx);
            }
            s = (s + (funkcja(xp) + funkcja(xk)) / 2) * dx;
            Console.WriteLine(s);
        }

        static void metoda_trapezow2()
        {
            int n;
            double xp, xk, dx, maxDelta=0.001, minDelta=0.00001, aktualna_odleglosc, h;
            double s = 0;

            Console.WriteLine("Podaj liczbę trapezów: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj początek przedziału całkowania: ");
            xp = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj koniec przedziału całkowania: ");
            xk = Convert.ToDouble(Console.ReadLine());

            aktualna_odleglosc = xp;
            dx = (xk - xp) / n;
            while(aktualna_odleglosc < xk)
            {
                while(aktualna_odleglosc + dx <= xk)
                {
                    h = Math.Abs(funkcja(aktualna_odleglosc + dx / 2) - (funkcja(aktualna_odleglosc + dx) + funkcja(aktualna_odleglosc)) / 2);
                    if (h < minDelta)
                    {
                        dx *= 2;
                    }
                    else if (h > maxDelta)
                    {
                        dx /= 2;
                    }
                    else break;
                }               
                if(aktualna_odleglosc + dx > xk)
                {
                    dx = xk - aktualna_odleglosc;
                }
                s += ((funkcja(aktualna_odleglosc) + funkcja(aktualna_odleglosc + dx)) / 2 * dx);
                aktualna_odleglosc += dx;
            }         
            Console.WriteLine(s);
        }
   
        static void metoda_Runge_Kutta()
        {
            int n;
            double xp, xk, dx, k1, k2, k3, k4;
            double yp = 0;
            Console.WriteLine("Podaj liczbę prostokątów: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj początek przedziału całkowania: ");
            xp = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj koniec przedziału całkowania: ");
            xk = Convert.ToDouble(Console.ReadLine());
            dx = (xk - xp) / n;
            double y = yp;
            for (int i = 1; i <= n; i++)
            {         
                k1 = dx * f(xp, y);
                k2 = dx * f(xp + 0.5 * dx, y + 0.5 * k1);
                k3 = dx * f(xp + 0.5 * dx, y + 0.5 * k2);
                k4 = dx * f(xp + dx, y + k3);
           
                y = y + (1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4); ;
 
                xp = xp + dx;
            }
            Console.WriteLine(y);
        }
        

    
        static void Main(string[] args)
        {
            Console.WriteLine("## METODA PRAWOSTRONNA ##");
            rozniczkowanie_prawostronne();
            Console.WriteLine();
            Console.WriteLine("## METODA OBUSTRONNA ##");
            rozniczkowanie_obustronne();
            Console.WriteLine();
            Console.WriteLine("## METODA PROSTOKĄTÓW ##");
            metoda_prostokatow();
            Console.WriteLine();
            Console.WriteLine("## METODA TRAPEZÓW ZE ZMIENNYM KROKIEM ##");
            metoda_trapezow2();
            Console.WriteLine();
            Console.WriteLine("## METODA RUNGE-KUTTA ##");
            metoda_Runge_Kutta();
            Console.ReadKey();
        }
    }
}
