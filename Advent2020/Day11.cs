using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day11:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day11.txt");

            string ln = "";
            string code = "";

            //string[,] seats = new string[12, 12];
            string[,] seats = new string[99, 93];


            int r = 0;
            while ((ln = sr.ReadLine()) != null)
            {
                r++;
                for (int c = 0; c < ln.Length; c++)
                {
                    seats[c+1, r] = ln.Substring(c, 1);
                }
                
            }

            int lastchange = -1;
            int thischange = 0;
            while (lastchange != thischange)
            {
                lastchange = thischange;
                seats = ProcessSeats(seats, out thischange);

                DrawIt(seats);
            }

            sw.Stop();
            sr.Close();
            string ret = CountOcc(seats).ToString() ;
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day11.txt");
            string ln = "";

            //string[,] seats = new string[12, 12];

            string[,] seats = Utils.GetGridFromFile("c:\\temp\\advent_2020\\advent_2020_day11.txt");

            //string[,] seats = new string[99, 93];
            // 2089


            //int r = 0;
            //while ((ln = sr.ReadLine()) != null)
            //{
            //    r++;
            //    for (int c = 0; c < ln.Length; c++)
            //    {
            //        seats[c + 1, r] = ln.Substring(c, 1);
            //    }

            //}

            int lastchange = -1;
            int thischange = 0;
            while (lastchange != thischange)
            {
                lastchange = thischange;
                seats = ProcessSeats2(seats, out thischange);

                //DrawIt(seats);
            }


            sw.Stop();
            sr.Close();
            string ret = "Answer:" + CountOcc(seats).ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        string[,] ProcessSeats(string[,] seats, out int ch)
        {
            string[,] newseats = seats.Clone() as string[,];

            int changed = 0;
            for (int r= 1; r < seats.GetLength(1)-1; r++)
            {
                for (int c = 1; c < seats.GetLength(0) -1; c++)
                {
                    if (seats[c,r]=="L")
                    {
                        if (CountAdjacent(seats, c,r)==0)
                        {
                            newseats[c, r] = "#";
                            changed++;
                        }
                    }
                    else if (seats[c,r] == "#")
                    {
                        if (CountAdjacent(seats, c, r) >= 4)
                        {
                            newseats[c, r] = "L";
                            changed++;
                        }
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }

            ch = changed;
            return newseats;

        }

        int CountAdjacent(string[,] seats, int c, int r)
        {
            int seatcount = 0;
            for (int y = r - 1; y < r + 2; y++)
            {
                for (int x = c - 1; x < c + 2; x++)
                {
                    if (x == c && y == r)
                    {
                    }
                    else
                    { 
                        if (seats[x, y] == "#")
                        {
                            seatcount++;
                        }
                    }
                }
            }  

            return seatcount;
        }


        int CountAdjacent2(string[,] seats, int c, int r)
        {
            int seatcount = 0;
            // go right
            for (int x = c + 1; x < seats.GetLength(0) - 1; x++)
            {
                if (seats[x,r]=="L")
                {
                    break;
                }
                else if (seats[x,r]=="#")
                {
                    seatcount++;
                    break;
                }
            }
            // go left
            for (int x = c - 1; x > 0; x--)
            {
                if (seats[x, r] == "L")
                {
                    break;
                }
                else if (seats[x, r] == "#")
                {
                    seatcount++;
                    break;
                }
            }
            // go up[
            for (int y = r - 1; y > 0; y--)
            {
                if (seats[c, y] == "L")
                {
                    break;
                }
                else if (seats[c, y] == "#")
                {
                    seatcount++;
                    break;
                }
            }
            // go down
            for (int y = r + 1; y < seats.GetLength(1)-1; y++)
            {
                if (seats[c, y] == "L")
                {
                    break;
                }
                else if (seats[c, y] == "#")
                {
                    seatcount++;
                    break;
                }
            }

            // diagonal left up
            int x1 = c-1;
            int y1 = r - 1;
            while (x1 > 0 && y1 > 0)
            {
                if (seats[x1, y1] == "L")
                {
                    break;
                }
                else if (seats[x1, y1] == "#")
                {
                    seatcount++;
                    break;
                }
                x1--;
                y1--;
            }
            // diagonal right up
            x1 = c + 1;
            y1 = r - 1;
            while (x1 < seats.GetLength(0) && y1 > 0)
            {
                if (seats[x1, y1] == "L")
                {
                    break;
                }
                else if (seats[x1, y1] == "#")
                {
                    seatcount++;
                    break;
                }
                x1++;
                y1--;
            }


            // diagonal left down
            x1 = c - 1;
            y1 = r + 1;
            while (x1 > 0 && y1 < seats.GetLength(1))
            {
                if (seats[x1, y1] == "L")
                {
                    break;
                }
                else if (seats[x1, y1] == "#")
                {
                    seatcount++;
                    break;
                }
                x1--;
                y1++;
            }

            // diagonal right down
            x1 = c + 1;
            y1 = r + 1;
            while (x1 < seats.GetLength(0) - 1 && y1 < seats.GetLength(1)-1)
            {
                if (seats[x1, y1] == "L")
                {
                    break;
                }
                else if (seats[x1, y1] == "#")
                {
                    seatcount++;
                    break;
                }
                x1++;
                y1++;
            }

            return seatcount;
        }

        int CountOcc(string[,] seats)
        {
            int seatcount = 0;
            for (int y = 1; y < seats.GetLength(1)-1; y++)
            {
                for (int x = 1; x < seats.GetLength(0)-1; x++)
                {
                        if (seats[x, y] == "#")
                        {
                            seatcount++;
                        }
                    
                }
            }

            return seatcount;
        }

        void DrawIt(string[,] seats)
        {
            
            for (int y = 1; y < seats.GetLength(1) - 1; y++)
            {
                string row = "";
                for (int x = 1; x < seats.GetLength(0) - 1; x++)
                {
                        row += seats[x, y];
                    }

                Debug.WriteLine(row);
            }
            
            
        }


        string[,] ProcessSeats2(string[,] seats, out int ch)
        {
            string[,] newseats = seats.Clone() as string[,];
            //new string[seats.GetLength(0), seats.GetLength(1)];
            //Array.Copy(seats, 0, newseats, 0, seats.Length);
            int changed = 0;
            for (int r = 1; r < seats.GetLength(1) - 1; r++)
            {
                
                for (int c = 1; c < seats.GetLength(0) - 1; c++)
                {
                    if (seats[c, r] == "L")
                    {
                        if (CountAdjacent2(seats, c, r) == 0)
                        {
                            newseats[c, r] = "#";
                            changed++;
                        }
                    }
                    else if (seats[c, r] == "#")
                    {
                        if (CountAdjacent2(seats, c, r) >= 5)
                        {
                            newseats[c, r] = "L";
                            changed++;
                        }
                    }
                    else
                    {
                        // do nothing
                    }
                }
                //Array.Copy(newseats, 0, seats, 0, seats.Length);

            }
            //seats = newseats.Clone() as string[,];
            ch = changed;
            return newseats;

        }

    }
}
