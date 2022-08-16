using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//1.Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. Эту задачу
//выполняют два садовника, которые не хотят встречаться друг с другом. Первый садовник начинает работу с верхнего
//левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. Второй садовник начинает работу
//с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. Если садовник видит,
//что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно. Создать
//многопоточное приложение, моделирующее работу садовников.
namespace Part_1
{
    internal class Program
    {
        const int n = 10;
        const int m = 10;
        static int[,] poleG = new int[n, m];

        static void Main(string[] args)
        {
            Console.WriteLine("Необработанное поле");
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    poleG[i, j] = rnd.Next(0, 100);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", poleG[i, j]);
                }
                Console.WriteLine();
            }

            ThreadStart threadStart = new ThreadStart(man_1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            man_2();

            Console.WriteLine();
            Console.WriteLine("Обработанное поле");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", poleG[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void man_1()
        {
            int b = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (poleG[i, j] >= 0)
                    {
                        int delay = poleG[i, j];
                        poleG[i, j] = b;
                        Thread.Sleep(delay);
                    }
                }
                b--;
            }
        }
        static void man_2()
        {
            int d = -100;
            for (int g = n - 1; g >= 0; g--)
            {
                for (int r = m - 1; r >= 0; r--)
                {
                    if ((poleG[r, g] >= 0))
                    {
                        int delay = poleG[r, g];
                        poleG[r, g] = d;
                        Thread.Sleep(delay);
                    }
                }
                d--;
            }
        }
    }
}
