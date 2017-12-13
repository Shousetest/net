using System;
using System.Collections.Generic;
using System.IO;
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

        public override string ToString()
        {
            return $"({Firstname} {Lastname} {Mark})";
        }

    }

    public interface IStudentStorage
    {
        void Save(IEnumerable<Student> students);

        IEnumerable<Student> Load();
    }

    public class StudentStorage : IStudentStorage
    {
        #region Private fields

        private string filepath;

        #endregion

        #region Constructor

        public StudentStorage(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new ArgumentException($"{nameof(filepath)} is not exist.");
            }

            this.filepath = string.Copy(filepath);
        }

        #endregion

        #region Interface implementations
        public Tree<Student> Load()
        {
            if (!File.Exists(filepath))
            {
                throw new ArgumentException($"{nameof(filepath)} is not exist.");
            }

            var students = new Tree<Student>(Comparer<Student>.Default);

            using (BinaryReader reader = new BinaryReader(File.Open(filepath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    students.Insert(ReadStudent(reader));
                }
            }

            return students;
        }

        public void Save(IEnumerable<Student> students)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filepath, FileMode.Create)))
            {
                foreach (Student student in students)
                {
                    WriteStudent(writer, student);
                }
            }
        }

        
        private void WriteStudent(BinaryWriter writer, Student student)
        {
            writer.Write(student.Firstname);
            writer.Write(student.Lastname);
            writer.Write(student.Testname);
            writer.Write(student.Date.ToBinary());
            writer.Write(student.Mark);
        }

        private Student ReadStudent(BinaryReader reader)
        {
            string Firstname = reader.ReadString();
            string Lastname = reader.ReadString();
            string Testname = reader.ReadString();
            DateTime Date = Convert.ToDateTime(reader.ReadString());
            int mark = reader.ReadInt32();
            return new Student(Firstname, Lastname, Testname, Date, mark);
        }
        
    }
}
