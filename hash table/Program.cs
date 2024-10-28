using System;

namespace hash_table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable hashtable = new HashTable(11);
            string name = "";
            hashtable.Add("Mia", 123);
            hashtable.Add("Tim", 456);
            hashtable.Add("Bea", 645);
            hashtable.Add("Zoe", 89);
            hashtable.Add("Sue", 189);
            hashtable.Add("Len", 289);
            hashtable.Add("Moe", 489);
            hashtable.Add("Lou", 389);
            hashtable.Add("Rae", 589);
            hashtable.Add("Max", 689);
            hashtable.Add("Tod", 889);
            Console.WriteLine("Enter a name to search for:");
            name = Console.ReadLine();
            while (name != "")
            {
                int index = hashtable.Find(name);
                if (index == -1)
                {
                    Console.WriteLine("Not in array");
                }
                else
                {
                    Console.WriteLine("Located at " + index);
                }
                Console.WriteLine("Enter next search:");
                name = Console.ReadLine();
            }
        }

        class HashTable
        {
            private int size;
            private (string key, object value)?[] table; 

            public HashTable(int size)
            {
                this.size = size;
                table = new (string, object)?[size]; 
            }

            private int hash(string key)
            {
                return GetHashCode() % size; 
            }

            public void Add(string key, object value)
            {
                int index = hash(key);
                Console.WriteLine($"Hash calculated as {index}");

                
                while (table[index] != null)
                {
                    index = (index + 1) % size; 
                    Console.WriteLine($"Hash updated to {index}");
                }

                table[index] = (key, value); 
                Console.WriteLine($"{key} stored at {index}");
            }

            public int Find(string key)
            {
                int index = hash(key);
                bool loop = false;
                int h = index;
                while (table[index] != null)
                {
                    if (table[index]?.key == key)
                    {
                        Console.WriteLine($"{key} found at {index}");
                        return index;
                    }
                    else 
                    {
                        index = (index + 1)%size;

                        if (index == h) 
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine($"{key} not found");
                return -1; 
            }
        }
    }
}