
//
// Copyright 2017 Paul Perrone.  All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
//using IDA.DAPO;

namespace IDA.Optimization
{
    internal class TestOptimization
    {
        private static int numberOfCities = 250;
        //private static string XMLOutputPath = "c:\\temp\\TravelingSalesman.xml";

        public static void Main(string[] args)
        {
            TravelingSalesman tsm = new TravelingSalesman(numberOfCities)
            {
                DoLogging = true,
                DetailedLogging = false
            };

            //// Use the DAPO Drawings object to output a DAPO XML file of a drawing with 
            //// a Before Polyline and an After Polyline

            //Drawings drawings = new Drawings();

            //Drawing drawing = new Drawing();
            //Sheet sheet = new Sheet();
            //View view = new View(new Point(0.0,0.0), 0.0, 0.0);
            //drawings.Add(drawing);
            //drawing.Sheets.Add(sheet);
            //sheet.Views.Add(view);

            //view.Polylines = new List<List<Point>>();
            //List<Point> polyline1 = new List<Point>();
            //tsm.locations.ForEach(loc => polyline1.Add(loc.Point));
            //// Add the Before Polyline
            //view.Polylines.Add(polyline1);

            //double minX = polyline1.Min<Point>(p => p.X);
            //double maxX = polyline1.Max<Point>(p => p.X);
            //double xTranslate = 1.25 * (maxX - minX);

            tsm.optimizationSolution.Optimize();

            //List<Point> polyline2 = new List<Point>();
            //tsm.locations.ForEach
            //    (loc =>
            //    {
            //        loc.Point.X = loc.Point.X + xTranslate;
            //        polyline2.Add(loc.Point);
            //    }
            //    );
            //// Add the After Polyline
            //view.Polylines.Add(polyline2);

            //// Output DAPO XML file
            //drawings.OutputXML(XMLOutputPath);

            System.Console.Write(tsm.ToString());
        }
    }
}
