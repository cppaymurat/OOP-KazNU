using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Matrix
    {
        protected double[,] matrix;
        protected int rows;
        protected int cols;
        public Matrix(int _rows, int _cols)
        {
            this.rows = _rows;
            this.cols = _cols;
            this.matrix = new double[_rows, _cols];
        }
        public void Copy(Matrix tmp)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = tmp.matrix[i, j];
                }
            }
        }
        public int getRows()
        {
            return this.rows;
        }
        public int getCols()
        {
            return this.cols;
        }
        public void Init(Random rand)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.NextDouble() * rand.Next(-100, 100);
                }
            }
        }
        public void Display()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0:F} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static Matrix add(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.getRows(), a.getCols());
            try
            {
                if (a.getRows() != b.getRows() ||
                    a.getCols() != b.getCols()) throw new Exception();
                for (int i = 0; i < a.getRows(); i++)
                {
                    for (int j = 0; j < b.getCols(); j++)
                    {
                        c.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                    }
                }
            }
            catch
            {
                Console.Write("����������! ������� ������ �� ���������!\n");
            }
            return c;
        }
        public static Matrix sub(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.getRows(), a.getCols());
            try
            {
                if (a.getRows() != b.getRows() ||
                    a.getCols() != b.getCols()) throw new Exception();
                for (int i = 0; i < a.getRows(); i++)
                {
                    for (int j = 0; j < b.getCols(); j++)
                    {
                        c.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                    }
                }
            }
            catch
            {
                Console.Write("����������! ������� ������ �� ���������!\n");
            }
            return c;
        }
        public static Matrix mul(Matrix a, Matrix b)
        {
            //A[l, m] * B[m, n] = C[l, n]
            Matrix ans = new Matrix(a.getRows(), b.getCols());
            try
            {
                if (a.getCols() != b.getRows()) throw new Exception();
                for (int i = 0; i < a.getRows(); i++)
                {
                    for (int j = 0; j < b.getCols(); j++)
                    {
                        ans.matrix[i, j] = 0;
                        for (int r = 0; r < a.getCols(); r++)
                        {
                            ans.matrix[i, j] += a.matrix[i, r] * b.matrix[r, j];
                        }
                    }
                }
            }
            catch
            {
                Console.Write("����������! ������� ������ �� ��������� ��������� ���������!\n");
            }
            return ans;
        }
        public void mul(double a)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] *= a;
                }
            }
        }
        public void div(double a)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] /= a;
                }
            }
        }
        public void getInverse()
        {
            Matrix additional = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    additional.matrix[i, j] = 0.0;
                    if (i == j) additional.matrix[i, j] = 1.0;
                }
            }
            for (int k = 0; k < rows; k++)
            {
                double tmp = matrix[k, k];
                for (int j = 0; j < rows; j++)
                {
                    matrix[k, j] /= tmp;
                    additional.matrix[k, j] /= tmp;
                }
                for (int j = k + 1; j < rows; j++)
                {
                    tmp = matrix[j, k];
                    for (int i = 0; i < rows; i++)
                    {
                        matrix[j, i] -= matrix[k, i] * tmp;
                        additional.matrix[j, i] -= additional.matrix[k, i] * tmp;
                    }
                }
            }
            for (int k = rows - 1; k > 0; k--)
            {
                for (int i = k - 1; i >= 0; i--)
                {
                    double tmp = matrix[i, k];
                    for (int j = 0; j < rows; j++)
                    {
                        matrix[i, j] -= matrix[k, j] * tmp;
                        additional.matrix[i, j] -= additional.matrix[k, j] * tmp;
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = additional.matrix[i, j];
                }
            }
        }
        public int getRank()
        {
            Matrix additional = new Matrix(rows, cols);
            Matrix reserve = new Matrix(rows, cols);
            reserve.Copy(this);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    additional.matrix[i, j] = 0.0;
                    if (i == j) additional.matrix[i, j] = 1.0;
                }
            }
            for (int k = 0; k < rows; k++)
            {
                double tmp = reserve.matrix[k, k];
                for (int j = 0; j < rows; j++)
                {
                    reserve.matrix[k, j] /= tmp;
                    additional.matrix[k, j] /= tmp;
                }
                for (int j = k + 1; j < rows; j++)
                {
                    tmp = reserve.matrix[j, k];
                    for (int i = 0; i < rows; i++)
                    {
                        reserve.matrix[j, i] -= reserve.matrix[k, i] * tmp;
                        additional.matrix[j, i] -= additional.matrix[k, i] * tmp;
                    }
                }
            }
            for (int k = rows - 1; k > 0; k--)
            {
                for (int i = k - 1; i >= 0; i--)
                {
                    double tmp = reserve.matrix[i, k];
                    for (int j = 0; j < rows; j++)
                    {
                        reserve.matrix[i, j] -= reserve.matrix[k, j] * tmp;
                        additional.matrix[i, j] -= additional.matrix[k, j] * tmp;
                    }
                }
            }
            int rank = rows;
            for (int i = 0; i < rows; i++)
            {
                int d = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (reserve.matrix[i, j] == 0) d++;
                }
                if (d == cols) rank--;
            }
            return rank;
}
        public static Matrix div(Matrix a, Matrix b)
        {
            //A[l, m] * B[m, n] = C[l, n]
            //A[l, m] / B[m, n] = A[l,m] * B[m, n]^-1
            Matrix ans = new Matrix(a.getRows(), b.getCols());
            try
            {
                if (a.getCols() != b.getRows()) throw new Exception();
                Matrix c = new Matrix(b.getRows(), b.getCols());
                c.Copy(b);
                c.getInverse();
                for (int i = 0; i < a.getRows(); i++)
                {
                    for (int j = 0; j < c.getCols(); j++)
                    {
                        ans.matrix[i, j] = 0;
                        for (int r = 0; r < a.getCols(); r++)
                        {
                            ans.matrix[i, j] += a.matrix[i, r] * c.matrix[r, j];
                        }
                    }
                }
            }
            catch
            {
                Console.Write("����������! ������� ������ �� ��������� ��������� �������!\n");
            }
            return ans;
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix ans = mul(A, B);
            return ans;
        }
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix C = add(A, B);
            return C;
        }
        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix C = sub(A, B);
            return C;
        }
        public static Matrix operator /(Matrix A, Matrix B)
        {
            Matrix ans = div(A, B);
            return ans;
        }
        public static Matrix operator *(Matrix A, double b)
        {
            A.mul(b);
            return A;
        }
        public static Matrix operator /(Matrix A, double b)
        {
            A.div(b);
            return A;
        }
    }

    class Program
    {
        public static void menu()
        {
            Console.WriteLine("�������� �������� � ���������: ");
            Console.WriteLine("1. ��������� �������� A * B");
            Console.WriteLine("2. ��������� �������� A + C");
            Console.WriteLine("3. ��������� �������� A - C");
            Console.WriteLine("4. ��������� �������� A / B");
            Console.WriteLine("5. ������������� ����� ������� A");
            Console.WriteLine("6. ������������� ����� ������� B");
            Console.WriteLine("7. ������� ������� A");
            Console.WriteLine("8. ������� ������� B");
            Console.WriteLine("9. ����� �������� ������� A");
            Console.WriteLine("10. ����� �������� ������� B");
            Console.WriteLine("11. ����� ���� ������� A");
            Console.WriteLine("12. ����� ���� ������� B");
            Console.WriteLine("13. ����� �� ���������");
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            int A_rows, A_cols, B_rows, B_cols;
            Console.Write("������� ���������� ����� ������� �: ");
            A_rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("������� ���������� �������� ������� A: ");
            A_cols = Convert.ToInt32(Console.ReadLine());
            Matrix A = new Matrix(A_rows, A_cols);
            A.Init(rand);
            Console.WriteLine("������� �: ");
            A.Display();
            Console.Write("������� ���������� ����� ������� B: ");
            B_rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("������� ���������� �������� ������� B: ");
            B_cols = Convert.ToInt32(Console.ReadLine());
            Matrix B = new Matrix(B_rows, B_cols);
            B.Init(rand);
            Console.WriteLine("������� �: ");
            A.Display();
            Matrix C;
            int sw;
            do
            {
                menu();
                sw = Convert.ToInt32(Console.ReadLine());
                switch (sw)
                {
                    case 1:
                        {
                            if (A.getCols() != B.getRows())
                            {
                                Console.WriteLine("�������� ����������: ������� ������ �� ��������� ��������� ���������!");
                            }
                            else
                            {
                                C = A * B;
                                Console.WriteLine("A * B = ");
                                C.Display();
                            }
                            break;
                        }
                    case 2:
                        {
                            if (A.getCols() != B.getRows())
                            {
                                Console.WriteLine("�������� ����������: ������� ������ �� ��������� ��������� ��������!");
                            }
                            else
                            {
                                C = A + B;
                                Console.WriteLine("A + B = ");
                                C.Display();
                            }
                            break;
                        }
                    case 3:
                        {
                            if (A.getCols() != B.getRows())
                            {
                                Console.WriteLine("�������� ����������: ������� ������ �� ��������� ��������� ���������!");
                            }
                            else
                            {
                                C = A - B;
                                Console.WriteLine("A - B = ");
                                C.Display();
                            }
                            break;
                        }
                    case 4:
                        {
                            if (A.getCols() != B.getRows())
                            {
                                Console.WriteLine("�������� ����������: ������� ������ �� ��������� ��������� �������!");
                            }
                            else
                            {
                                C = A / B;
                                Console.WriteLine("A / B = ");
                                C.Display();
                            }
                            break;
                        }
                    case 5:
                        {
                            A.Init(rand);
                            Console.WriteLine("������������� ����� ������� �!");
                            break;
                        }
                    case 6:
                        {
                            B.Init(rand);
                            Console.WriteLine("������������� ����� ������� B!");
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("������� A: ");
                            A.Display();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("������� B: ");
                            B.Display();
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("�������� ������� �� �: ");
                            Matrix inverse = new Matrix(A.getRows(), A.getCols());
                            inverse.Copy(A);
                            inverse.getInverse();
                            inverse.Display();
                            break;
                        }
                    case 10:
                        {
                            Console.WriteLine("�������� ������� �� B: ");
                            Matrix inverse = new Matrix(B.getRows(), B.getCols());
                            inverse.Copy(B);
                            inverse.getInverse();
                            inverse.Display();
                            break;
                        }
                    case 11:
                        {
                            Console.WriteLine("���� ������� A: {0} ", A.getRank());
                            break;
                        }
                    case 12:
                        {
                            Console.WriteLine("���� ������� B: {0} ", B.getRank());
                            break;
                        }
                }
            } while (sw != 13);
            Console.ReadKey();
        }
    }
}
