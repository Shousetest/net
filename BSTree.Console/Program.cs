using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using BinarySearchTree;

namespace BSTree.Console
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public double Length()
        {
            return Pow((Pow(X, 2) + Pow(Y, 2)), 1.0 / 2);
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y) => (int)(x.Length() - y.Length());
    }

            public class StringComparer: IComparer<string>
        {
            public int Compare(string a, string b)
            {
                return a.Length - b.Length;
            }
        }

    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = new Point[] {new Point(1,2), new Point(3,4), new Point(5,6), new Point(6,7), new Point(7,8) };
            var tree = new Tree<Point>(new PointComparer());
            foreach (Point point in points)
            {
                tree.Insert(point);
            }

            foreach (Point point in tree.Inorder(tree.Root))
            {
                WriteLine(point);
            }

            foreach (Point point in tree.Postorder(tree.Root))
            {
                WriteLine(point);
            }

            foreach (Point point in tree.Preorder(tree.Root))
            {
                WriteLine(point);
            }


            ReadKey();
        }
    }
}
