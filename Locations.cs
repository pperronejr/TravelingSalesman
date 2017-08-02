
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
    internal class Locations : List<Location>
    {
        internal Locations(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Add(new Location(new Point(randomNumberGenerator.NextDouble(),
                                           randomNumberGenerator.NextDouble()),
                                 this));
            }
        }
        private Random randomNumberGenerator = new Random();
        private int randomIndex()
        {
            // Do not include the first (index = 0) since that is always 
            // the start and end location
            return randomNumberGenerator.Next(1, Count);
        }
        /// <summary>
        /// Randomly changes position of loc in the Locations list.  DO not do anything
        /// if loc is the first item in the list. The first item is defined to always be 
        /// the start and end location so only the intermediate locations can change order.
        /// </summary>
        /// <param name="loc"></param>
        internal void RandomlyReorderLocation(Location loc)
        {
            int oldIndex = IndexOf(loc);
            // Make sure loc to be ordered is not the first one
            if (oldIndex > 0)
            {
                int newIndex;
                // Make sure newIndex is different than oldIndex
                do
                {
                    newIndex = randomIndex();
                } while (newIndex == oldIndex);
                ReorderLocation(loc, newIndex);
            }
        }
        internal void ReorderLocation(Location loc, int newIndex)
        {
            if (newIndex >= 0)
            {
                Remove(loc);
                Insert(newIndex, loc);
            }
        }
    }
}
