using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PolynomOperations
{
    public class CopyMaker<T> where T : class, new()
    {
        private T polynom = new T();

        internal CopyMaker(T toCopy)
        {
            this.polynom = toCopy;
        }

        public T DeepCopy()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, polynom);
                stream.Seek(0, SeekOrigin.Begin);
                object copy = formatter.Deserialize(stream);
                return (T)copy;
            }
        }
    }
}
