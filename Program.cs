using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace kmeanss
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dataSet = new Dictionary<int, GenericVector>();

            var parsedData = File
                .ReadAllLines("data.csv")
                .Select(line => line
                    .Split(',')
                    .Select(float.Parse)
                    .ToList()
                )
                .ToList();

            for (var i = 0; i < parsedData.Count(); i++)
            {
                for (var j = 0; j < parsedData[i].Count; j++)
                {
                    if (!dataSet.ContainsKey(j))
                        dataSet[j] = new GenericVector();
                    dataSet[j].Add(parsedData[i][j]);
                }
            }

            var kmeans = new kmeans
            {
                Clusters = 4,
                DataSet = dataSet.Values.ToList(),
                Iterations = 100
            };
            kmeans.Run();
            kmeans.PrintClusters();
            Console.WriteLine(kmeans.SquaredErrors());
        }
    }
}