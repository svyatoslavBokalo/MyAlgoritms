using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafAttemptWindowsForm
{
    internal class Graph
    {
        private int n;
        private int[,] mas;
        public Graph()
        {
            this.n = 0;
            this.mas = new int[0, 0];
        }

        public Graph(int n)
        {
            this.n = n;
            this.mas = new int[n,n];
        }

        public Graph(int n, int[,] mas)
        {
            this.n = n;
            this.mas = mas;
        }
        public Graph(string fileName)
        {
            ReadFromFile(fileName);
        }

        public int N { get => n; set => n = value; }
        public int[,] Mas { get => mas; }

        public void ReadFromFile(string fileName)
        {
            using(StreamReader sr = new StreamReader(fileName))
            {
                this.n = int.Parse(sr.ReadLine());
                this.mas = new int[n, n];

                int i = 0;
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitMas = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < splitMas.Length; j++)
                    {
                        this.mas[i, j] = int.Parse(splitMas[j]);
                    }

                    i++;
                }

                //string line = "";
                //for (int i = 0; (line = sr.ReadLine()) != null; i++)
                //{
                //    string[] splitMas = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //    for (int j = 0; j < splitMas.Length; j++)
                //    {
                //        this.mas[i, j] = int.Parse(splitMas[j]);
                //    }
                //}
            }
        }

        public int[] DijkstraAlgorithm(int startPoint)
        {
            int[] result = new int[n];
            int[] masVisited = new int[n];

            for(int i = 0; i < n ; i++)
            {
                result[i] = int.MaxValue;
                masVisited[i] = int.MaxValue;
            }
            result[startPoint] = 0;
            

            for(int k = 0; k < n-1; k++)
            {
                int min = int.MaxValue;
                int numberMin = -1;
                for(int j = 0; j < n; j++)
                {
                    MessageBox.Show("k = " + k + " \n j = " + j + "\n startPoint = " + startPoint);
                    //MessageBox.Show("j = " + j);
                    //MessageBox.Show("startPoint = " + startPoint);
                    if (mas[startPoint, j] != 0 && masVisited[j] == int.MaxValue)
                    {
                        //result[j] = mas[startPoint, j];
                        //MessageBox.Show($"{k} - {j} \n {result[j]}");
                        if (mas[startPoint, j] < min)
                        {
                            min = mas[startPoint, j];
                            numberMin = j;
                        }
                    }
                }

                masVisited[startPoint] = 0;
                if (result[startPoint] + min < result[numberMin])
                {
                    //MessageBox.Show($"{result[startPoint] + min} - {result[numberMin]}");
                    result[numberMin] = min + result[startPoint];
                    //MessageBox.Show($"{result[startPoint] + min} - {result[numberMin]}");
                }
                int min1 = int.MaxValue;
                int numberMin1 = -1;
                bool isVisitedAll = true;
                bool isOk = true;
                for(int j = 0; j< n; j++)
                {
                    if(masVisited[j] != 0)
                    {
                        isVisitedAll = isVisitedAll && false;
                    }
                    if(masVisited[j] != 0 && mas[numberMin, j] != 0 && mas[numberMin,j] <= min1)
                    {
                        isOk = isOk && false;
                        min1 = mas[numberMin, j];
                        numberMin1 = j;
                    }
                }
                if(isOk == true)
                {
                    MessageBox.Show("is visited all");
                    break;
                }
                startPoint = numberMin1;
            }
            //int k = 0;
            //double distance = double.MaxValue;
            //for(int i = 0; i < n ; i++)
            //{
            //    for(int j = 0; j < n ; j++)
            //    {
            //        if (result[i] > mas[i, j] && mas[i,j] != 0) 
            //        {
            //            result[i] = mas[i, j];
            //        }
            //    }
                
            //}

            return result;
        }


        public int[] DijkstraAlgorithm1(int startPoint)
        {
            int[] result = new int[n];
            int[] masVisited = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = int.MaxValue;
                masVisited[i] = int.MaxValue;
            }
            result[startPoint] = 0;

            while (true)
            {
                for (int j = 0; j < n; j++)
                {
                    if (masVisited[j] != 0)
                    {
                        if (mas[startPoint, j] != 0 && (mas[startPoint, j] + result[startPoint]) < result[j])
                        {
                            result[j] = mas[startPoint, j] + result[startPoint];
                        }
                    }
                }
                masVisited[startPoint] = 0;

                int min1 = int.MaxValue;
                int numberMin1 = -1;
                for (int i = 0; i < n; i++)
                {
                    if (masVisited[i] != 0)
                    {
                        if (result[i] < min1)
                        {
                            min1 = result[i];
                            numberMin1 = i;
                        }
                    }
                }

                if (numberMin1 == -1)
                {
                    break;
                }
                else
                {
                    startPoint = numberMin1;
                }
            }

            string s = "";
            for(int i = 0; i<result.Length; i++)
            {
                s += result[i] + "\n";
            }

            //MessageBox.Show(s);
            return result;
        }
    }   
}
