using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class BaseStore<T> : IStore<T>
    {
        protected List<T> _elements;
        protected INumberGenerator _numberGen;

        public BaseStore(ICollection<T> elements = null, INumberGenerator numberGenerator = null)
        {
            _numberGen = numberGenerator ?? new DefaultNumberGenerator();
            _elements = elements.ToList() ?? new List<T>();
        }

        public virtual T Get(BaseContext context = null)
        {
            if (_elements.Count == 0)
            {
                return default(T);
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

        public ICollection<T> GetAll()
        {
            return _elements;
        }
    }
}
