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
            var storage = new StudentStorage("students.bin");
            Tree<Student> storageStudents = storage.Load();

            IEnumerable<Student> alices = storageStudents.Inorder().Where(node => node.Firstname == "Alice").OrderBy(node => node.Mark).Take(1);

            Student[] students = new Student[] {
                new Student("John", "Doe", "Math", new DateTime(), 10),
                new Student("Jane", "Doe", "Math", new DateTime(), 9),
                new Student("Alice", "Doe", "Math", new DateTime(), 8),
                new Student("Alice", "Kali", "Math", new DateTime(), 7),
            };

            
            Tree<Student> tree = new Tree<Student>(Comparer<Student>.Default);

            foreach (Student student in students)
            {
                tree.Insert(student);
            }

            IEnumerable<Student> alicesDef =  tree.Inorder().Where(node => node.Firstname == "Alice").OrderBy(node => node.Mark).Take(1);

            foreach (Student alice in alicesDef)
            {
                WriteLine(alice.Firstname + " " + alice.Mark);
            }
            
            ReadKey();
        }
    }
}
