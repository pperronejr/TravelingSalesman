
//
// Copyright 2017 Paul Perrone.  All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDA.Optimization
{
    internal class TravelingSalesman
    {
        internal TravelingSalesman(int LocationQuantity)
        {
            locations = new Locations(LocationQuantity);
            optimizationSolution =
                new OptimizationSolution(
                    searchOperators,
                    OptimizationItems<Location>.Convert(locations.GetRange(1, LocationQuantity - 1)),
                    ObjectiveItems<Location>.Convert(locations)
                    );
        }
        internal bool DoLogging
        {
            get { return optimizationSolution.DoLogging; }
            set { optimizationSolution.DoLogging = value; }
        }
        internal bool DetailedLogging
        {
            get { return optimizationSolution.DetailedLogging; }
            set { optimizationSolution.DetailedLogging = value; }
        }
        public Locations locations;
        internal OptimizationSolution optimizationSolution;
        private List<SearchOperator> searchOperators = new List<SearchOperator>() 
        { 
            new SimulatedAnnealing()
            { TInitial = 2.0,
                TReductionFactor = 0.8,
                TQuantityMax = 100}
        };
    }
}
