using System;
using System.IO;

namespace SLAR
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = "matr2.txt";
            StreamReader sr = new StreamReader(fileName);
            SLAR slar = new SLAR(sr);
            Console.WriteLine(slar);
            Console.WriteLine();

            //slar.DirectMove();
            //Console.WriteLine("left: " + "\n" + slar.Left);
            //Console.WriteLine();
            //Console.WriteLine("right = " + "\n" + slar.Right);

            Matrix x = slar.Inverse();
            Console.WriteLine(x);

            //Matrix x = slar.MathodSimpleIteration();
            //Console.WriteLine(x);


            //Console.WriteLine("input row count: ");
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine("input column count: ");
            //int m = int.Parse(Console.ReadLine());
            //try
            //{
            //    Matrix matr1 = new Matrix(n, m);
            //    matr1.FillingTheMatrix();
            //    Matrix matr2 = new Matrix(n, m);
            //    matr2.FillingTheMatrix();

            //    Console.WriteLine("matr1 + matr2 = ");
            //    Matrix matr3 = matr1 + matr2;
            //    matr3.Show();
            //    Console.ReadLine();

            //    Console.WriteLine("matr1 - matr2 = ");
            //    matr3 = matr1 - matr2;
            //    //matr3.Show();
            //    Console.WriteLine(matr3);
            //    Console.ReadLine();

            //    Console.WriteLine("matr1 * matr2 = ");
            //    matr3 = matr1 * matr2;
            //    matr3.Show();
            //    Console.ReadLine();

            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}






        }
    }
}
