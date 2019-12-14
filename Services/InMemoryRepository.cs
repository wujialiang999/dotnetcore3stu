using System.Collections.Generic;
using System.Linq;

namespace dotnetcore3stu
{
    public class InMertoryRepository : IReposity<Student>
    {
        private List<Student> _students = new List<Student>{
               new Student
            {
                Id = 1,
                FirstName = "Nick1",
                LastName = "Tom",
                BirthDate = new System.DateTime(1974,1,4)
            },
            new Student
            {
                Id = 2,
                FirstName = "Nick2",
                LastName = "Tom",
                BirthDate = new System.DateTime(1984,1,4)
            },
            new Student
            {
                Id = 3,
                FirstName = "Nick3",
                LastName = "Tom",
                BirthDate = new System.DateTime(1994,1,4)
            }
            };
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }
    }
}