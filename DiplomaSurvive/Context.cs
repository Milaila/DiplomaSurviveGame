using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public class Context
    {
        Dictionary<string, int> numberVars = new Dictionary<string, int>();
        Dictionary<string, string> textVars = new Dictionary<string, string>();
        Dictionary<string, bool> booleanVars = new Dictionary<string, bool>();

        public int? GetNumberVariable(string variableName)
        {
            int value;
            if (numberVars.TryGetValue(variableName, out value))
            {
                return value;
            }
            return null;
        }
        public string GetTextVariable(string variableName)
        {
            string value;
            if (textVars.TryGetValue(variableName, out value))
            {
                return value;
            }
            return null;
        }
        public bool? GetBooleanVariable(string variableName)
        {
            bool value;
            if (booleanVars.TryGetValue(variableName, out value))
            {
                return value;
            }
            return null;
        }
    }
}
