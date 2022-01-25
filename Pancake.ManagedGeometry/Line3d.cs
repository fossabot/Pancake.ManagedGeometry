﻿using System.Diagnostics;

namespace Pancake.ManagedGeometry
{
    [DebuggerDisplay("{From} -> {End}")]
    public struct Line3d
    {
        public Coord Start;
        public Coord End;

        public double Length => (End - Start).Length;
        public Line3d(Coord start, Coord end)
        {
            Start = start;
            End = end;
        }

        public Line3d(Coord start, Coord vec, double Length)
        {
            Start = start;
            End = start + vec / vec.Length * Length;
        }

        public Line2d GetXYProjection()
        {
            return new Line2d(new Coord2d(Start.X, Start.Y), new Coord2d(End.X, End.Y));
        }
        public static implicit operator Line3d((Coord, Coord) d) => new(d.Item1, d.Item2);
    }
}
