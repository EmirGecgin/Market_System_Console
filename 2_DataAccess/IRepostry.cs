using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_DataAccess
{
    public interface IRepostry<T>
    {
        List<T> GetAll();
        T GetById(int id);
        string Add(T entity);
        string Update(T entity);
        string Delete(int entityId);
    }
}
