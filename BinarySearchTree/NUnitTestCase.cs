using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using NUnit.Framework;

namespace BinarySearchTree
{
    [TestFixture]
    class NUnitTestCase
    {
        public class IntComparer : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                return Abs(a) - Abs(b);
            }
        }

        public class StringComparer: IComparer<string>
        {
            public int Compare(string a, string b)
            {
                return a.Length - b.Length;
            }
        }

        [TestCase]
        public void TestSystemInt32()
        {
            int[] ints = new int[] { 100, 2, 3, 6, 5, 6, 7, 8 };
            Tree<int> tree = new Tree<int>(new IntComparer());
            foreach (int integer in ints)
            {
                tree.Insert(integer);
            }
            Assert.AreEqual(tree.Root.Value, 100);
        }

        [TestCase]
        public void TestSystemString()
        {
            string[] strings = new string[] { "hellow", "world", "glatestz", "ice" };

            Tree<string> tree = new Tree<string>(new StringComparer());

            foreach (string str in strings)
            {
                tree.Insert(str);
            }
            Assert.AreEqual(tree.Root.Value, "hellow");
        }

        [TestCase]
        public void TestStudent()
        {
            Student[] students = new Student[] {
                new Student("John", "Doe", "Math", new DateTime(), 10),
                new Student("Jane", "Doe", "Math", new DateTime(), 9),
                new Student("Alice", "Doe", "Math", new DateTime(), 8),
            };

            Tree<Student> tree = new Tree<Student>(Comparer<Student>.Default);

            foreach (Student student in students)
            {
                tree.Insert(student);
            }

        }

    }
}
