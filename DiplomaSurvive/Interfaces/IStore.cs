using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public interface IStore<T>
    {
        T Get();
        void Set(T element);
        T GetByIndex(int index);
        bool Remove(T element);
    }
}
