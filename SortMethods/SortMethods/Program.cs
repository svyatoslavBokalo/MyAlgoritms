// See https://aka.ms/new-console-template for more information
using SortMethods;
using System.Diagnostics;

//Console.WriteLine("Hello, World!");
//MyClassT<string> myClassT = new MyClassT<string>("mama");
//Console.WriteLine(myClassT);
//MyClassT<int> myClassT1 = new MyClassT<int>(100);
//Console.WriteLine(myClassT1);

Console.WriteLine("Hello, World!");

//List<int> lst = new List<int>() { 2, 5, 7, 1, 5, 85, 32, 64, 54, 3 };

//List<int> lst = new List<int>();
//List<int> lst1 = new List<int>();
//int a = 0;
//Random rnd = new Random();
//for(int i = 0; i < 6000000; i++)
//{
//    a = rnd.Next(0, 100);
//    lst.Add(a);
//    lst1.Add(a);
//}

//Stopwatch stopWatch = new Stopwatch();
//stopWatch.Start();
////Thread.Sleep(1000);
//QuickSort.QSListMethod(lst, 0, lst.Count - 1);
//stopWatch.Stop();
//// Get the elapsed time as a TimeSpan value.
//TimeSpan ts = stopWatch.Elapsed;
//// Format and display the TimeSpan value.
//string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
//    ts.Hours, ts.Minutes, ts.Seconds,
//    ts.Milliseconds);
//Console.WriteLine("RunTime " + elapsedTime);

//stopWatch = new Stopwatch();
//stopWatch.Start();
////Thread.Sleep(1000);
//QuickSort.BublleSortList(lst1);
//stopWatch.Stop();
//// Get the elapsed time as a TimeSpan value.
//ts = stopWatch.Elapsed;
//// Format and display the TimeSpan value.
//elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
//    ts.Hours, ts.Minutes, ts.Seconds,
//    ts.Milliseconds);
//Console.WriteLine("RunTime " + elapsedTime);


//foreach(int i in lst)
//{
//    Console.Write(i + "; ");
//}


int n = 100;
int[] mas = new int[] { 2, 6, 8, 6, 42, 3, 1, 5 };
QuickSort.SplitSort(ref mas, 0, mas.Length - 1);
foreach (int el in mas)
{
    Console.Write(el + " ");
}

//int[] mas1 = new int[] { 6, 8};
//int[] mas2 = new int[] { 3, 7, 10, 11};
//int[] res = new int[6];
//QuickSort.MergeForMas(mas1, mas2, ref res);

//foreach (int el in res)
//{
//    Console.Write(el + " ");
//}