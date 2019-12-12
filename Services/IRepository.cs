using System.Collections.Generic;

namespace dotnetcore3stu{
    public interface IReposity<T> where T :class{
        IEnumerable<T> GetAll();
    }
}