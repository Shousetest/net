using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Student : IEquatable<Student>, IComparable<Student>
    {
        public Student(string firstname, string lastname, string testname, DateTime date, int mark)
        {
            Firstname = firstname;
            Lastname = lastname;
            Testname = testname;
            Date = date;
            Mark = mark;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Testname { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }
        public int CompareTo(Student other)
        {
            if (null != other)
            {
                return Mark.CompareTo(other.Mark);
            }
            return 1;
        }

        public bool Equals(Student other)
        {
            return other.GetType() == GetType() && Equals(other);
        }
    }
}
