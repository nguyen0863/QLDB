using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _AI_A
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int[,] matrix = {
                                {0,0,9,7,13,20,0,0,0,0},
                                {0,0,0,0,0,0,0,0,0,0},
                                {0,0,0,0,0,0,0,6,0,0},
                                {0,0,0,4,0,0,0,8,0,0},
                                {0,0,0,0,0,0,0,0,3,4},
                                {0,0,0,0,0,0,4,0,6,0},
                                {0,0,0,0,0,0,0,0,0,0},
                                {0,0,0,0,0,0,0,0,0,5},
                                {0,5,0,0,0,0,0,0,0,9},
                                {0,6,0,0,0,0,0,0,0,0}
                            };
            int[] father={-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
            int start = 0;
            int end = 1;
            p.Asearching(matrix,start,end,ref father);
            for (int i = 0; i < father.Length;i++ )
            {
                Console.Write("{0}", father[i]);
            }
            Console.ReadLine();
        }

        public int Asearching(int[,] matrix, int start, int end,ref int[] father )
        {
            int[] G = { 0, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] H = { 14, 0, 15, 6, 8, 7, 12, 10, 4, 2 };
            int[] F = { 0, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] open = new int[10];
            int[] close = new int[10];
            //int[] father = new int[matrix.Length];
            open[0] = start;
            for (int i = 0; i < 10 - 1; i++)
            {
                int u = Fmin(F);
                close[i] = u;
                if (u == end)
                {
                    //return father;
                    return 1;
                }
                else
                {
                    for (int j = 0; j < 10; j++)
                    {
                        int g = G[u] + matrix[u,j];
                        int f = g + H[j];
                        if ((open[j] != 0 && F[j] > f) || open[j] == 0)
                        {
                            father[j] = u;
                            F[j] = f;
                            G[j] = g;
                            open[j] = 1;
                        }
                    }
                }
            }
            return 0;
        }

        public int Fmin(int[] F)
        {
            int min = F[0];
            int index=0;
            for (int i=0;i<F.Length && F[i] > 0 ;i++)
            {
                if (F[i] < min)
                {
                    min = F[i];
                    index = i; 
                }
            }
            return index;
        }

        public void Bubble(int[] open)
        {
            for (int i = 0; i < open.Length - 1; i++)
            {
                for (int j = open.Length - 1; j > i; j--)
                {
                    if (open[j] > open[j - 1])
                        Swap(open[j], open[j - 1]);
                }
            }
        }

        public void Swap(object a, object b)
        {
            object temp;
            temp = b;
            b = a;
            a = temp;
        }
    }
}
