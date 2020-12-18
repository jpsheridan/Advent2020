using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace AdventCode
{
    public class Day17:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day17.txt");

            string[,,] cubes = Utils.Get3dGridFromFile("c:\\temp\\advent_2020\\advent_2020_day17.txt");

            //DrawIt(cubes, 50);
            for (int i = 0; i < 6; i++)
            {
                cubes = ProcessCubes(cubes, 50-i, 51+i);
                //DrawIt(cubes, 51);
            }

            int active = CountActive(cubes);

            sw.Stop();

            
            string ret = "Active: " + active.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day17.txt");

            string[,,,] cubes = Get4dGridFromFile("c:\\temp\\advent_2020\\advent_2020_day17.txt");

            //DrawIt(cubes, 50);
            for (int i = 0; i < 6; i++)
            {
                cubes = ProcessCubes2(cubes, 25 - i, 26 + i);
                //DrawIt2(cubes, 25, 25);
            }

            int active = CountActive2(cubes);

            sw.Stop();


            string ret = "Active: " + active.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        string[,,] ProcessCubes(string[,,] cube, int minslice, int maxslice)
        {
            string[,,] newcube = cube.Clone() as string[,,];

            for (int z = minslice - 1; z <= maxslice; z++)
            {
                for (int r = 1; r < cube.GetLength(2) - 1; r++)
                {
                    for (int c = 1; c < cube.GetLength(1) - 1; c++)
                    {
                        if (r==8 && c==5)
                        {
                            int k = 0;
                        }
                        int active = CountAdjacent(cube, z, c, r);
                        
                        if (cube[z, c, r] == "#")
                        {
                            if (active == 2 || active == 3)
                            {
                                newcube[z, c, r] = "#";
                            }
                            else
                            {
                                newcube[z, c, r] = ".";
                            }
                        }
                        else if (cube[z,c, r] == ".")
                        {
                            if (active == 3)
                            {
                                newcube[z, c, r] = "#";
                            }
                            else
                            {
                                newcube[z, c, r] = ".";
                            }
                        }
                        else
                        {
                            // do nothing
                        }
                    }
                }
            }

            return newcube;

        }


        string[,,,] ProcessCubes2(string[,,,] cube, int minslice, int maxslice)
        {
            string[,,,] newcube = cube.Clone() as string[,,,];

            for (int w = minslice - 1; w <= maxslice; w++)
            {
                for (int z = minslice - 1; z <= maxslice; z++)
                {
                    for (int r = 1; r < cube.GetLength(3) - 1; r++)
                    {
                        for (int c = 1; c < cube.GetLength(2) - 1; c++)
                        {
                            if (r == 8 && c == 5)
                            {
                                int k = 0;
                            }
                            int active = CountAdjacent2(cube, w, z, c, r);

                            if (cube[w, z, c, r] == "#")
                            {
                                if (active == 2 || active == 3)
                                {
                                    newcube[w,z, c, r] = "#";
                                }
                                else
                                {
                                    newcube[w,z, c, r] = ".";
                                }
                            }
                            else if (cube[w, z, c, r] == ".")
                            {
                                if (active == 3)
                                {
                                    newcube[w, z, c, r] = "#";
                                }
                                else
                                {
                                    newcube[w, z, c, r] = ".";
                                }
                            }
                            else
                            {
                                // do nothing
                            }
                        }
                    }
                }
            }
            return newcube;

        }

        int CountAdjacent(string[,,] cube, int z, int c, int r)
        {
            int activecount = 0;
            for (int w = z - 1; w < z + 2; w++)
            {
                for (int y = r - 1; y < r + 2; y++)
                {
                    for (int x = c - 1; x < c + 2; x++)
                    {
                        if (x == c && y == r && z==w)
                        {
                        }
                        else
                        {
                            if (cube[w, x, y] == "#")
                            {
                                activecount ++;
                            }
                        }
                    }
                }
            }
            return activecount;
        }


        int CountAdjacent2(string[,,,] cube, int w, int z, int c, int r)
        {
            int activecount = 0;
            for (int w2 = w - 1; w2 < w + 2; w2++)
            {
                for (int z2 = z - 1; z2 < z + 2; z2++)
            {
                    for (int y = r - 1; y < r + 2; y++)
                    {
                        for (int x = c - 1; x < c + 2; x++)
                        {
                            if (x == c && y == r && z2 == z && w2 == w)
                            {
                            }
                            else
                            {
                                if (cube[w2, z2, x, y] == "#")
                                {
                                    activecount++;
                                }
                            }
                        }
                    }
                }
            }
            return activecount;
        }

        int CountActive(string[,,] cube)
        {
            int c = 0;
            for (int z = 0; z < cube.GetLength(0) - 1; z++)
            {
                for (int y = 1; y < cube.GetLength(2) - 1; y++)
                {
                    for (int x = 1; x < cube.GetLength(1) - 1; x++)
                    {
                        if (cube[z,x, y] == "#")
                        {
                            c++;
                        }

                    }
                }
            }
            return c++;
        }

        int CountActive2(string[,,,] cube)
        {
            int c = 0;
            for (int w = 0; w < cube.GetLength(0) - 1; w++)
            {
                for (int z = 0; z < cube.GetLength(1) - 1; z++)
            {
                for (int y = 1; y < cube.GetLength(3) - 1; y++)
                {
                        for (int x = 1; x < cube.GetLength(2) - 1; x++)
                        {
                            if (cube[w,z, x, y] == "#")
                            {
                                c++;
                            }
                        }
                    }
                }
            }
            return c++;
        }

        void DrawIt(string[,,] cube, int slice)
        {

            for (int y = 1; y < cube.GetLength(2) - 1; y++)
            {
                string row = "";
                for (int x = 1; x < cube.GetLength(1) - 1; x++)
                {
                    row += cube[slice, x, y];
                }
                Debug.WriteLine(row);
            }

            Debug.WriteLine(Environment.NewLine);
                


        }


        public static string[,,,] Get4dGridFromFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);


            string ln = "";
            int r = 0;
            int c = 0;
            int z = 25;
            int w = 25;

            ln = sr.ReadLine();
            r++;
            c = ln.Length;

            while ((ln = sr.ReadLine()) != null)
            {
                r++;
            }

            string[,,,] grid = new string[50, 50, c + 2, r + 2];

            for (int w2 = 0; w2 < 50; w2++)
            {


                for (int z2 = 0; z2 < 50; z2++)
                {
                    for (int x = 0; x < c + 1; x++)
                    {
                        for (int y = 0; y < r + 1; y++)
                        {
                            grid[w2, z2, x, y] = ".";
                        }
                    }
                }
            }

            r = 0;
            c = 0;

            sr.BaseStream.Position = 0;

            while ((ln = sr.ReadLine()) != null)
            {
                r++;
                for (c = 0; c < ln.Length; c++)
                {
                    grid[w, z, c + 1, r] = ln.Substring(c, 1);
                }

            }

            return grid;
        }

        void DrawIt2(string[,,,] cube, int slice, int slice2)
        {

            for (int y = 1; y < cube.GetLength(3) - 1; y++)
            {
                string row = "";
                for (int x = 1; x < cube.GetLength(2) - 1; x++)
                {
                    row += cube[slice2, slice, x, y];
                }
                Debug.WriteLine(row);
            }

            Debug.WriteLine(Environment.NewLine);



        }

    }
}
