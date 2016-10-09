/*Created by Yablonskyy Denys <mrvayzard@ukr.net>*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Ex1
{
    class Program
    {
        public struct edge
        {
            public int a, b, cost;

            public edge(int a, int b, int cost)
            {
                this.a = a; //first vertex
                this.b = b; //second vertex
                this.cost = cost;   //edge weight
            }
        }

        static void Solution()
        {
            int countVertexes = 0;  //count of vertex
            List<int> weight = new List<int> { };   //list of weight all edges
            List<edge> ed = new List<edge> { }; //list of edges

            //read data from file

            try
            {
                using (StreamReader sr = new StreamReader("Test.txt"))
                {
                    String line = null;
                    line = sr.ReadToEnd();
                    string[] rowNums = line.Split();
                    for (int i = 0; i < rowNums.Length; i++)
                    {
                        if (rowNums[i] != "")
                            weight.Add(Convert.ToInt32(rowNums[i]));
                    }
                    countVertexes = weight.Count;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //creating edges data

            int[,] newMatrix = new int[countVertexes, countVertexes];

            int rowCount = 0;
            int endValue = 0;
            int zeroCount = 0;
            int zeroCount2 = 0;
            for (int i = 0; i < countVertexes; i++)
            {
                zeroCount2 = 0;
                for (int j = zeroCount; j < countVertexes; j++)
                {
                    zeroCount2++;
                    if (rowCount != 0 || j != zeroCount && zeroCount2 <= 3)
                    {
                        edge smth = new edge(i, j, weight[j]);
                        ed.Add(smth);
                    }
                }

                if (rowCount == endValue)
                {
                    zeroCount += 2;
                    rowCount = 0;
                    endValue++;
                }
                else
                {
                    zeroCount++;
                    rowCount++;
                }
            }

            //Belman-Ford algorithm (modificated)

            int[] distanse = new int[countVertexes];    //an array of distances between the start vertex and the rest

            distanse[0] = 0; //distance to first vertex

            for (int i = 1; i < countVertexes; i++)
            {
                distanse[i] = -Int32.MaxValue;  //initialization distanse to rest vertexes
            }

            for (int i = 0; i < countVertexes; i++)
            {
                bool flag = false;  //check changes in distance
                for (int k = 0; k < ed.Count; k++)
                {
                    if (distanse[ed[k].b] < distanse[ed[k].a] + ed[k].cost)
                    {
                        distanse[ed[k].b] = distanse[ed[k].a] + ed[k].cost;
                        flag = true;
                    }
                }
                if (flag != true) break;    //if no change
            }

            //Output result to concole
            Console.WriteLine("Max way: " + (distanse.Max() + weight[0]));  //max way
        }

        static void Main(string[] args)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();    //measure time (start clock) 

            Solution(); //create task solution (find max way from first vertex)

            watch.Stop();   //stop clock
            var elapsedMs = watch.ElapsedMilliseconds;  //time of execution
            Console.WriteLine("Execute time: " + elapsedMs);
            Console.Read();
        }
        
    }
}
