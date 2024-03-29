﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public class JarvisMarch : BaseAlgorithm, IConvexHullAlgorithm
    {
        public string AlgorithmName => "Jarvis March";

        public List<Point> GetConvexHullPoints(IEnumerable<Point> points)
        {
            CheckInputPoints(points);

            var startingPoint = points.OrderBy(p => p.X).ThenBy(p => p.Y).First();
            var currentPoint = startingPoint;
            var convexHull = new List<Point>();

            do
            {
                convexHull.Add(currentPoint);
                var nextPoint = points.ElementAt(0);

                for (int i = 1; i < points.Count(); i++)
                {
                    var direction = GeometryHelper.GetOrientation(currentPoint, nextPoint, points.ElementAt(i));
                    if (nextPoint == currentPoint || direction == Orientation.CounterClockwise || (direction == Orientation.Collinear
                        && GeometryHelper.GetDistance(currentPoint, points.ElementAt(i)) > GeometryHelper.GetDistance(currentPoint, nextPoint)))
                        nextPoint = points.ElementAt(i);
                }

                currentPoint = nextPoint;
            }
            while (currentPoint != startingPoint);

            return convexHull;
        }
    }
}
