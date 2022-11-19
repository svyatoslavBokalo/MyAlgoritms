using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SLAR
{
    class SLAR
    {
        private Matrix left;
        private Matrix right;
        private Matrix x;
        private Matrix leftC;
        private Matrix rightC;

        internal Matrix Left { get => left; set => left = value; }
        internal Matrix Right { get => right; set => right = value; }
        internal Matrix X { get => x; set => x = value; }

        public SLAR(Matrix left, Matrix right)
        {
            this.left = left;
            this.right = right;
            this.x = new Matrix(left.ColumnCount, right.ColumnCount);
            this.leftC = new Matrix(left);
            this.rightC = new Matrix(right);
        }
        
        public SLAR(double[,] a, double[] b)
        {
            this.left = new Matrix(a);
            this.right = new Matrix(b);
            this.x = new Matrix(b.Length, 1);
            this.leftC = new Matrix(left);
            this.rightC = new Matrix(right);
        }

        public SLAR(double[,] a, double[,] b)
        {
            this.left = new Matrix(a);
            this.right = new Matrix(b);
            this.x = new Matrix(b);
            this.leftC = new Matrix(left);
            this.rightC = new Matrix(right);
        }

        public SLAR(StreamReader sr)
        {
            this.left = new Matrix();
            this.left.ReadFromFile(sr);

            this.right = new Matrix();
            this.right.ReadFromFile(sr);

            this.x = new Matrix(left.RowCount, right.ColumnCount);

            this.leftC = new Matrix(left);
            this.rightC = new Matrix(right);
        }



        public void DirectMove()
        {
            double cof = 0;
            double v = 0;

            for (int i = 0; i < leftC.ColumnCount; i++)
            {
                double max = Math.Abs(leftC[i, i]);
                int numberMax = i;

                for (int k = i; k < leftC.RowCount; k++)
                {
                    if (Math.Abs(leftC[k, i]) > max)
                    {
                        max = Math.Abs(leftC[k, i]);
                        numberMax = k;
                    }
                }

                if (i != numberMax)
                {
                    for (int j = i; j < leftC.ColumnCount; j++)
                    {
                        double buff = leftC[i, j];
                        leftC[i, j] = leftC[numberMax, j];
                        leftC[numberMax, j] = buff;
                    }
                    double buff1 = rightC[i, 0];
                    rightC[i, 0] = rightC[numberMax, 0];
                    rightC[numberMax, 0] = buff1;
                }

                v = leftC[i, i];

                for (int j = i + 1; j < leftC.RowCount; j++)
                {
                    cof = leftC[j, i];
                    for (int k = i; k < leftC.ColumnCount; k++)
                    {
                        leftC[j, k] = leftC[j, k] * v - leftC[i, k] * cof;
                    }
                    rightC[j, 0] = rightC[j, 0] * v - rightC[i, 0] * cof;
                }
            }

        }

        public void ReversMove()
        {
            for (int i = x.RowCount - 1; i > -1; i--)
            {
                double s = 0;
                for (int k = i + 1; k < leftC.ColumnCount; k++)
                {
                    s += leftC[i, k] * x[k, 0];
                }
                x[i, 0] = (rightC[i, 0] - s) / leftC[i, i];
            }
        }

        public List<Matrix> DirectMoveList(Matrix left, Matrix right)
        {
            List<Matrix> resList = new List<Matrix>();
            Matrix res = new Matrix(left);
            Matrix res1 = new Matrix(right);
            double cof = 0;
            double v = 0;

            for (int i = 0; i < left.ColumnCount; i++)
            {
                double max = Math.Abs(res[i, i]);
                int numberMax = i;

                for (int k = i; k < left.RowCount; k++)
                {
                    if (Math.Abs(res[k, i]) > max)
                    {
                        max = Math.Abs(res[k, i]);
                        numberMax = k;
                    }
                }

                if (i != numberMax)
                {
                    for (int j = i; j < left.ColumnCount; j++)
                    {
                        double buff = res[i, j];
                        res[i, j] = res[numberMax, j];
                        res[numberMax, j] = buff;
                    }
                }

                v = res[i, i];

                for (int j = i + 1; j < left.RowCount; j++)
                {
                    cof = res[j, i];
                    for (int k = i; k < left.ColumnCount; k++)
                    {
                        res[j, k] = res[j, k] * v - res[i, k] * cof;
                    }
                    res1[j, 0] = res1[j, 0] * v - res1[i, 0] * cof;
                }
            }

            resList.Add(res);
            resList.Add(res1);
            return resList;

        }

        public Matrix ReversMoveList(List<Matrix> list)
        {
            Matrix x = new Matrix(list[1].RowCount, 1);

            for (int i = x.RowCount - 1; i > -1; i--)
            {
                double s = 0;
                for (int k = i + 1; k < list[0].ColumnCount; k++)
                {
                    s += list[0][i, k] * x[k, 0];
                }
                x[i, 0] = (list[1][i, 0] - s) / list[0][i, i];
            }

            return x;
        }

        public Matrix GauseMethod()
        {
            DirectMove();
            ReversMove();
            return this.x;
        }

        public Matrix MathodSimpleIteration(double eps = 0.1)
        {
            Matrix alpha = new Matrix(left.RowCount, left.ColumnCount);
            Matrix beta = new Matrix(right.RowCount, 1);
            
            for(int i = 0; i < beta.RowCount; i++)
            {
                beta[i, 0] = right[i, 0] / left[i, i];
            }

            for(int i = 0; i < alpha.RowCount; i++)
            {
                for(int j = 0; j < alpha.ColumnCount; j++)
                {
                    alpha[i, j] = -left[i, j] / left[i, i];
                }
            }

            for(int i = 0; i < alpha.RowCount; i++)
            {
                alpha[i, i] = 0;
            }
            Console.WriteLine(alpha);
            Console.WriteLine(beta);
            
            Matrix prevX = new Matrix(beta.RowCount, 1);
            Matrix nextX = new Matrix(beta);
            int count = 0;

            //while ((nextX - prevX).Norma() > eps)
            //{
            //    prevX.Clone(nextX);
            //    nextX = beta + alpha * prevX;
            //    count++;

            //}
            while ((nextX - prevX).Norma1() > eps)
            {
                prevX.Clone(nextX);
                nextX = beta + alpha * prevX;
                count++;
                Console.WriteLine(nextX);

            }

            Console.WriteLine("count = "+count);
            x.Clone(nextX);

            return prevX;
        }

        public Matrix Inverse()
        {
            try
            {
                Console.WriteLine("inverse: ");
                Console.WriteLine(x);
                Console.WriteLine("size = " + right.ColumnCount);
                Console.WriteLine();
                for (int j = 0; j < right.ColumnCount; j++)
                {
                    Console.WriteLine("location:");
                    Matrix matr = new Matrix(right.RowCount, 1);
                    for (int i = 0; i < x.RowCount; i++)
                    {
                        matr[i, 0] = right[i, j];
                    }
                    //List<Matrix> list = DirectMoveList(left, matr);
                    //Matrix res = ReversMoveList(list);
                    SLAR slarLocation = new SLAR(left, matr);
                    Matrix res = slarLocation.GauseMethod();
                    //Console.WriteLine("location:");
                    Console.WriteLine(slarLocation);
                    Console.WriteLine();
                    Console.WriteLine(res);

                    for (int k = 0; k < x.RowCount; k++)
                    {
                        x[k, j] = res[k, 0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return this.x;
        }

        public override string ToString()
        {
            return left.ToString() + "\n" + right.ToString();
        }
    }
}
