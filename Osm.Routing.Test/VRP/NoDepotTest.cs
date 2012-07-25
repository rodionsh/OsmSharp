﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Math.Graph.Routing;
using Tools.Math.Geo;
using Osm.Routing.Core;
using Osm.Routing.Core.Route;
using Osm.Routing.Raw;
using Tools.Xml.Sources;
using Tools.Math.Units.Time;
using Osm.Core;
using Osm.Data.Raw.XML.OsmSource;

namespace Osm.Routing.Test.VRP
{
    public static class NoDepotTest<ResolvedType>
        where ResolvedType : ILocationObject
    {
        public static void TestEeklo()
        {
            string source_file = @"C:\PRIVATE\Dropbox\Ugent\Thesis\Test Cases\Post\Eeklo Osm\post.osm";
            OsmDataSource osm_data = new OsmDataSource(
                new Osm.Core.Xml.OsmDocument(new XmlFileSource(source_file)));
            Router raw_router = new Router(osm_data, new Osm.Routing.Raw.Graphs.Interpreter.GraphInterpreterTime(osm_data, Osm.Routing.Core.VehicleEnum.Car));

            string points_file = @"C:\PRIVATE\Dropbox\Ugent\Thesis\Test Cases\Post\Eeklo Osm\post.csv";

            int latitude_idx = 23;
            int longitude_idx = 24;

            NoDepotTest<ResolvedPoint>.MinMaxTest(raw_router, points_file, latitude_idx, longitude_idx);
        }

        public static void MinMaxTest(IRouter<ResolvedType> router, string csv, int latitude_idx, int longitude_idx)
        {
            System.Data.DataSet data = Tools.Core.DelimitedFiles.DelimitedFileHandler.ReadDelimitedFile(null,
                new System.IO.FileInfo(csv), Tools.Core.DelimitedFiles.DelimiterType.DotCommaSeperated,
                true, true);
            int cnt = -1;
            int max_count = 250;
            List<ResolvedType> points = new List<ResolvedType>();
            foreach (System.Data.DataRow row in data.Tables[0].Rows)
            {
                cnt++;
                if (cnt < max_count)
                {
                    //int latitude_idx = 8;
                    //int longitude_idx = 9;

                    string latitude_string = (string)row[latitude_idx];
                    string longitude_string = (string)row[longitude_idx];

                    double longitude = 0;
                    double latitude = 0;
                    if (double.TryParse(longitude_string, System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out longitude) &&
                       double.TryParse(latitude_string, System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out latitude))
                    {
                        GeoCoordinate point = new GeoCoordinate(latitude, longitude);

                        points.Add(router.Resolve(point));
                    }

                    Tools.Core.Output.OutputTextStreamHost.WriteLine("Processed {0}/{1}!",
                        data.Tables[0].Rows.IndexOf(row), data.Tables[0].Rows.Count);
                }
            }

            double elitism_percentage = 10;
            double cross_percentage = 60;
            double mutation_percentage = 30;

            double min = 1000;
            double max = 1500;

            int population = 100;
            int stagnation = 500;

            //for (mutation_percentage = 4; mutation_percentage <= 60; mutation_percentage = mutation_percentage + 4)
            //{
            //    NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, 500,
            //        elitism_percentage, cross_percentage, mutation_percentage, 10, null);
            //}

            //for (mutation_percentage = 4; mutation_percentage <= 60; mutation_percentage = mutation_percentage + 4)
            //{
            //    NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, 500,
            //        elitism_percentage, cross_percentage, mutation_percentage, 10, null);
            //}

            //for (elitism_percentage = 0; elitism_percentage <= 10; elitism_percentage++)
            //{
            //    NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, 500,
            //        elitism_percentage, cross_percentage, mutation_percentage, 10, probabilities);
            //}
            //for (double prob1 = 0.25; prob1 <= 1; prob1 = prob1 + 0.25)
            //{
            //List<double> probabilities = new List<double>();
            //probabilities.Add(1.0 - prob1);
            //probabilities.Add(prob1);
            //probabilities.Add(0);
            //probabilities.Add(0);

            //for (stagnation = 10; stagnation <= 100; stagnation = stagnation + 10)
            //{
            //    NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, stagnation,
            //        elitism_percentage, cross_percentage, mutation_percentage, 10, null);
            //}


            //for (stagnation = 150; stagnation <= 500; stagnation = stagnation + 50)
            //{
            //    NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, stagnation,
            //        elitism_percentage, cross_percentage, mutation_percentage, 10, null);
            //}


            //    probabilities = new List<double>();
            //    probabilities.Add(0);
            //    probabilities.Add(prob1);
            //    probabilities.Add(1.0 - prob1);
            //    probabilities.Add(0);

            NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, stagnation,
                elitism_percentage, cross_percentage, mutation_percentage, 10, null);


            //    probabilities = new List<double>();
            //    probabilities.Add(0);
            //    probabilities.Add(prob1);
            //    probabilities.Add(0);
            //    probabilities.Add(1.0 - prob1);

            //    NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, 500,
            //        elitism_percentage, cross_percentage, mutation_percentage, 10, probabilities);
            //}

            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 10, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 20, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 30, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 40, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 50, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 60, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 70, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 80, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 90, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 100, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 150, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);
            //NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, 200, 500, elitism_percentage, cross_percentage, mutation_percentage, 10);

            //for (int stagnation = 500; stagnation <= 4000; stagnation = stagnation + 500)
            ////{
            //for (population = 60; population <= 200; population = population + 20)
            //{
            //    NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, stagnation, 
            //        elitism_percentage, cross_percentage, mutation_percentage, 5, null);
            //}  
            ////}

            //            for (population = 20; population <= 200; population = population + 20)
            //{
            //    NoDepotTest<ResolvedType>.MinMaxTest(router, points.ToArray(), min, max, population, stagnation, 
            //        elitism_percentage, cross_percentage, mutation_percentage, 5, null);
            //}  
        }

        public static void MinMaxTest(IRouter<ResolvedType> router, ResolvedType[] points, Second min, Second max, int population, int stagnation,
            double elitism_percentage, double cross_percentage, double mutation_percentage, int tests, List<double> probabilities)
        {
            Osm.Routing.Core.VRP.NoDepot.MinMaxTime.Genetic.RouterGeneticSimple<ResolvedType> vrp_router
                 = new Core.VRP.NoDepot.MinMaxTime.Genetic.RouterGeneticSimple<ResolvedType>(router, min, max, population, stagnation, elitism_percentage,
                     cross_percentage, mutation_percentage, probabilities);
            for (int idx1 = 0; idx1 < tests; idx1++)
            {
                OsmSharpRoute[] routes = vrp_router.CalculateNoDepot(points);

                int idx = 0;
                foreach (OsmSharpRoute route in routes)
                {
                    if (route != null)
                    {
                        idx++;

                        route.SaveAsGpx(new System.IO.FileInfo(string.Format("route_{0}_{1}.gpx", points.Length, idx)));
                    }
                }
            }
        }
    }
}