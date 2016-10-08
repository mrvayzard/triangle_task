using System;
using System.Collections.Generic;

class Program
{
    public struct edge
    {
        public int a, b, cost;

        public edge(int a, int b, int cost)
        {
            this.a = a;
            this.b = b;
            this.cost = cost;
        }
    }

    static void Main(string[] args)
    {

        var watch = System.Diagnostics.Stopwatch.StartNew();
        // the code that you want to measure comes here

        int countVertexes = 0;
        List<int> weight = new List<int> { };
        List<edge> ed = new List<edge> { };

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
                    if(rowNums[i]!="")
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

        int[,] newMatrix = new int [countVertexes, countVertexes];

        int rowCount = 0;
        int endValue = 0;
        int zeroCount = 0;
        int zeroCount2 = 0;
        for (int i = 0; i < countVertexes; i++)
        {
            zeroCount2=0;
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

        //Belman-Ford algorithm

        int[] d = new int[countVertexes];

        for (int i = 0; i < countVertexes; i++)
        {
            d[i] = -999999999;
        }

        d[0] = 0;

        for (int i = 0; i < countVertexes; i++)
        {
            for (int k = 0; k < ed.Count; k++)
            {
                if (d[ed[k].b] < d[ed[k].a] + ed[k].cost)
                    d[ed[k].b] = d[ed[k].a] + ed[k].cost;
            }
        }

        Console.WriteLine("Max way: " + (d.Max() + weight[0]));
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine(elapsedMs);
        Console.Read();
    }

}
