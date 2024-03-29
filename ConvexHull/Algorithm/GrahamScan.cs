﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public class GrahamScan : BaseAlgorithm, IConvexHullAlgorithm
    {
        public string AlgorithmName => "Graham scan";

        public List<Point> GetConvexHullPoints(IEnumerable<Point> points)
        {
            CheckInputPoints(points);

            var startingPoint = points.OrderBy(p => p.Y).ThenBy(p => p.X).First();
            var sortedPoints = GeometryHelper.OrderByPolarAngle(startingPoint, points);
            
            var hull = new Stack<Point>();
            hull.Push(startingPoint);
            hull.Push(sortedPoints[1]);

            for (int i = 2; i < sortedPoints.Count; i++)
            {
                while (hull.Count >= 2 && GeometryHelper.GetOrientation(hull.ElementAt(1), hull.Peek(), sortedPoints[i]) != Orientation.CounterClockwise)
                    hull.Pop();
                hull.Push(sortedPoints[i]);
            }

            return hull.ToList();
        }
    }
}
