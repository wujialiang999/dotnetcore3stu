using System.Collections.Generic;

namespace dotnetcore3stu
{
    public class InMertoryRepository : IReposity<Student>
    {
        public IEnumerable<Student> GetAll()
        {
            return new List<Student>{
               new Student
            {
                Id = 1,
                FirstName = "Nick1",
                LastName = "Tom"
            },
            new Student
            {
                Id = 2,
                FirstName = "Nick2",
                LastName = "Tom"
            },
            new Student
            {
                Id = 3,
                FirstName = "Nick3",
                LastName = "Tom"
            }
            };
        }
    }
}