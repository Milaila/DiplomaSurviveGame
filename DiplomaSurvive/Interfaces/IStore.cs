using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public interface IStore<T>
    {
        T Get(BaseContext context = null);
        void Set(T element);
        T GetByIndex(int index);
        ICollection<T> GetAll();
        bool Remove(T element);
    }
}
