using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanning.Interfaces
{
    public interface IRepositoryForReg<T> : IRepository<T>
    {
        int CountReg(int t);
        bool Get(string id, int evId);
    }
}
