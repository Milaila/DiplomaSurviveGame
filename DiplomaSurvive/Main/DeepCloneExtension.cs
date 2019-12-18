﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaSurvive
{
    public static class DeepCLoneExtension
    {
        public static T DeepClone<T>(this T data)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
