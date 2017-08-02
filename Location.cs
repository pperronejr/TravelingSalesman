
//
// Copyright 2017 Paul Perrone.  All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IDA.Optimization
{
    internal class Location : OptimizationItem
    {
        internal Location(Point point, Locations tripLocations)
        {
            Point = point;
            TripLocations = tripLocations;
        }

        internal Point Point;
        internal Locations TripLocations;
        private int previousIndex = -1;

        public override void UndoIndependentVariable()
        {
            // Can only undo to the state previous to the most recent set
            TripLocations.ReorderLocation(this, previousIndex);
        }
        public override void SetIndependentVariableRandomly()
        {
            previousIndex = GetIndex();
            TripLocations.RandomlyReorderLocation(this);
        }
        public override double GetCost()
        {
            // Distance from this locations point to the next locations point
            return Point.Subtract(Point, NextLocation().Point).Length;
        }

        public override bool IsValid()
        {
            return true;
        }

        internal int GetIndex()
        {
            return TripLocations.IndexOf(this);
        }
        internal Location NextLocation()
        {
            int index = GetIndex();
            if (index == (TripLocations.Count - 1))
                return TripLocations[0];
            else
                return TripLocations[index + 1];
        }
        public override string ToString()
        {
            return base.ToString() + ": " + Point.ToString();
        }
    }
}
