using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day03:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day3.txt");

            string ln = "";
            string[,] hill = new string[2500, 500];
            int r = 0;
            //Map = Input.SplitByNewline().Select(line => line.Select(c => c == '#')
            int m = 0;
            while ((ln = sr.ReadLine()) != null)
            {
                m = ln.Length;

                for (int j=0; j < ln.Length;j++)
                {
                    hill[j, r] = ln.Substring(j, 1);
                }
                r++;
            }

            
            int x = 0;
            int y = 0;
            int trees = 0;
            while (y < r)
            {
                x = x + 3;
                y = y + 1;
                if (y < r)
                { 
                    if (hill[x%m, y] == "#")
                    {
                        trees++;
                    }
                }


            }

            sw.Stop();

            sr.Close();
            string ret = "Trees:" + trees.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day3.txt");

            

            string ln = "";
            
            string[,] hill = new string[35, 350];
            int r = 0;
            int m = 0;

            while ((ln = sr.ReadLine()) != null)
            {
                m = ln.Length;   
                for (int j = 0; j < ln.Length; j++)
                {
                    hill[j, r] = ln.Substring(j, 1);
                }
                r++;
            }


            long trees = toboggan(1, 1, r, m, hill) * toboggan(3, 1, r, m, hill) * toboggan(5, 1, r, m, hill) * toboggan(7, 1, r, m, hill)
                        * toboggan(1, 2, r, m, hill);



            sw.Stop();

            sr.Close();
            string ret = "Trees:" + trees.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        long toboggan(int right, int down, int rows, int cols, string[,] hill)
        {
            int x = 0;
            int y = 0;
            long trees = 0;
            while (y < rows)
            {
                x = x + right;
                y = y + down;
                if (y < rows)
                {
                    if (hill[x % cols, y] == "#")
                    {
                        trees++;
                    }
                }


            }
            return trees;
        }
    }
}
