namespace SortMethods
{
    internal class QuickSort
    {
        static public void QSListMethod(List<int> lst, int left, int right)
        {
            //Console.WriteLine("left = "+left);
            //Console.WriteLine("right = " + right);
            if (left >= right)
            {
                return;
            }
            int i = left;
            int j = right;
            int pivot = lst[left + ((right - left + 1) >> 1)];

            while (i <= j)
            {
                while ((lst[i] < pivot))
                {
                    ++i;
                }
                while (lst[j] > pivot)
                {
                    --j;
                }

                if (i <= j)
                {
                    int temp = lst[i];
                    lst[i] = lst[j];
                    lst[j] = temp;
                    ++i;
                    --j;
                }

            }

            //Console.WriteLine("i = " + i);
            //Console.WriteLine("j = " + j);
            if (j > left)
                QSListMethod(lst, left, j);
            if (i < right)
                QSListMethod(lst, i, right);
        }

        static public void BublleSortList(List<int> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < lst.Count - i - 1; j++)
                {
                    if (lst[j] < lst[j + 1])
                    {
                        int buff = lst[j];
                        lst[j] = lst[j + 1];
                        lst[j + 1] = buff;
                    }
                }
            }
        }

        static public void FillTheFile(int n, string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                sw.WriteLine(rnd.Next(0, 100));
            }

            sw.Close();
        }

        private void Split(string fileName, out int[] res, out int[] mas)
        {
            StreamReader sr = new StreamReader(fileName);
            int n = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                ++n;
            }

            sr.Close();

            res = new int[n/2];
            mas = new int[n-n/2];



            sr = new StreamReader(fileName);

            for(int i = 0; i < n / 2; i++)
            {
                res[i] = int.Parse(sr.ReadLine());
            }
            for (int i = 0; i < n - n / 2; i++)
            {
                mas[i] = int.Parse(sr.ReadLine());
            }

            sr.Close();
        }

        static public void SplitSort(ref int[] mas, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            //int i = start;
            //int j = end;
            int number = (start + end)/2;
            //Console.WriteLine("start = "+start + " end = "+end);
            //int pivot = mas[number];
            int[] mas1 = new int[number-start+1];
            int[] mas2 = new int[end- number];
            int[] mas3 = new int[end - start + 1];

            SplitSort(ref mas, start, number);
            //if (i < end)
            SplitSort(ref mas, number+1, end);
            
            for (int i = start; i <= number; i++)
            {
                mas1[i-start] = mas[i];
            }

            //Console.WriteLine("mas1");
            //for(int i = 0; i < mas1.Length; i++)
            //{
            //    Console.Write(mas1[i] + " ");
            //}
            //Console.WriteLine();

            for (int i = number+1; i <= end; i++)
            {
                //Console.WriteLine(i);
                mas2[i-number-1] = mas[i];
            }

            //Console.WriteLine("mas2");
            //for (int i = 0; i < mas2.Length; i++)
            //{
            //    Console.Write(mas2[i] + " ");
            //}
            //Console.WriteLine();

            MergeForMas(mas1, mas2,ref mas3);

            for(int i = start; i <= end; i++)
            {
                mas[i] = mas3[i - start];
            }
        }

        static public void MergeForMas(int[] mas1, int[] mas2,ref int[] mas)
        {
            int i1 = 0;
            int i2 = 0;
            int k = 0;

            while (i1 < mas1.Length && i2 < mas2.Length)
            {
                if (mas1[i1] < mas2[i2])
                {
                    mas[k] = mas1[i1];
                    //Console.WriteLine("if mas[k]  = " + mas[k]);
                    k++;
                    i1++;
                }
                else
                {
                    mas[k] = mas2[i2];
                    //Console.WriteLine("else mas[k] = " + mas[k]);
                    k++;
                    i2++;
                }
            }

            //for (int i = 0; i < mas1.Length + mas2.Length; i++)
            //{
            //    Console.Write(mas[i] + " ");
            //}
            //Console.WriteLine();

            if (i1 == mas1.Length)
            {
                for (int i = i2; i < mas2.Length; i++)
                {
                    //Console.WriteLine(" k = " + k);
                    mas[k] = mas2[i];
                    k++;
                }
            }
            if (i2 == mas2.Length)
            {
                for (int i = i1; i < mas1.Length; i++)
                {
                    //Console.WriteLine(" k = " + k);
                    mas[k] = mas1[i];
                    k++;
                }
            }

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
        }
        private void Merge(int[] mas1, int[] mas2, string fileName)
        {
            int i1 = 0;
            int i2 = 0;

            StreamWriter sw = new StreamWriter(fileName);

            while(i1<mas1.Length && i2 < mas2.Length)
            {
                if (mas1[i1] < mas2[i2])
                {
                    sw.WriteLine(mas1[i1]);
                    i1++;   
                }
                else
                {
                    sw.WriteLine(mas2[i2]);
                    i2++;
                }
            }

            if(i1 == mas1.Length)
            {
                for(int i = i2; i < mas2.Length; i++)
                {
                    sw.WriteLine(mas2[i]);
                }
            }
            if(i2 == mas2.Length)
            {
                for (int i = i1; i < mas1.Length; i++)
                {
                    sw.WriteLine(mas1[i]);
                }
            }
        }

        public void SplitMerge(string fileName)
        {
            int[] mas1 = null;
            int[] mas2 = null;

            Split(fileName, out mas1, out mas2);

            SplitSort(ref mas1, 0, mas1.Length);
            SplitSort(ref mas2, 0, mas2.Length);

            Merge(mas1, mas2, "data1.txt");
        }
        
    }
}
