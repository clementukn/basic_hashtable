using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace HashTableApp
{
    class Program
    {
        public static void TestHash()
        {
            HashTable<int, string> myHash = new HashTable<int, string>();

            // checking size after initializing
            Debug.Assert(myHash.Size == 0, "size is corrupted after initialization");

            // adding some random data
            myHash.Add(new Tuple<int, string>(1, "test1"));
            myHash.Add(new Tuple<int, string>(2, "test2"));
            myHash.Add(new Tuple<int, string>(3, "test3"));
            myHash.Add(new Tuple<int, string>(10, "test10"));

            Debug.WriteLine(myHash.ToString());

            // test size
            Debug.Assert(myHash.Size == 4, "size is corrupted");

            // test get
            Debug.Assert(myHash.Get(2).Item2 == "test2", "get_test(1) failed");
            Debug.Assert(myHash.Get(10).Item2 == "test10", "get_test(2) failed");


            // check exception working
            try
            {
                string sresult = myHash.Get(15).Item2;
                Debug.WriteLine("ERROR: exception should have arose.");
            }
            catch (Exception e)
            {
                Debug.Assert(e.Message == HashTable<int, string>.ERROR_KEY);
            }

            // deletion with existing key
            myHash.Remove(2);
            Debug.Assert(myHash.Size == 3, "size is corrupted after deletion");

            // deletion with non-existing key
            myHash.Remove(20);
            Debug.Assert(myHash.Size == 3, "size is corrupted after deletion");

            // clearing
            myHash.Clear();
            Debug.Assert(myHash.Size == 0, "size is corrupted after clearing");
        }

        static void Main(string[] args)
        {
            TestHash();
        }
    }
}
