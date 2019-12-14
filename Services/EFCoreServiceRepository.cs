using System.Collections.Generic;
using System.Linq;

namespace dotnetcore3stu
{
    public class EFCoreServiceRepository : IReposity<Student>
    {
        public EFCoreServiceRepository(DataContext context)
        {
            _context = context;
        }

        public readonly DataContext _context;

        public Student Add(Student newModel)
        {
            _context.Students.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }
    }
}