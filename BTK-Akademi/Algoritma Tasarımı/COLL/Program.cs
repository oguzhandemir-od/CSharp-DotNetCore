using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Concurrent;

namespace COLL
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }
        internal class MyCollection:IEnumerable
        {
            int[] data = { 1, 2, 3 };

            public IEnumerator GetEnumerator()
            {
                foreach (int i in data)
                {
                    yield return i;
                }
            }
        }

        internal class MyGenericCollection : IEnumerable<int>
        {
            int[] data = { 1, 2, 3 };
            public IEnumerator<int> GetEnumerator()
            {
                foreach (int i in data)
                {
                    yield return i;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
