using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class BaseStore<T>
    {
        protected List<T> _elements = new List<T>();
        protected INumberGenerator _numberGen;

        public BaseStore(INumberGenerator numberGenerator = null)
        {
            _numberGen = numberGenerator ?? new DefaultNumberGenerator();
        }

        public virtual T Get()
        {
            if (_elements.Count == 0)
            {
                return default;
            }
            int num = _numberGen.Next(_elements.Count);
            return _elements[num];
        }
        public virtual void Set(T element)
        {
            _elements.Add(element);
        }
        public virtual T GetByIndex(int index)
        {
            if (index < 0 || index >= _elements.Count)
            {
                throw new IndexOutOfRangeException("Index must be more than 0 and less than number of elements in store!");
            }
            return _elements[index];
        }
        public virtual bool Remove(T element)
        {
            return _elements.Remove(element);
        }
    }
}
