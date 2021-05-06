using System;
using System.Collections.Generic;

namespace RTS_Labs_Technical_Exercise
{
    internal class LiveInterview
    {
        public static void main(string[] args)
        {
            MyCache<int> myCache = new MyCache<int>();
            myCache.SetMaxSize(6);
            myCache.Put("1", 1);
            myCache.Put("3", 3);
            myCache.Put("5", 5);
            myCache.Put("21", 21);

            Console.WriteLine(myCache.ToString());

            myCache.Put("43", 43);
            myCache.Put("32", 32);
            myCache.Put("99", 99);

            Console.WriteLine(myCache.ToString());

            myCache.Put("3", 4);

            Console.WriteLine(myCache.ToString());

            myCache.Put("10", 10);

            Console.WriteLine(myCache.ToString());
        }
    }

    /// <summary>
    /// A key-value cache with a size limit.
    /// </summary>
    public interface ICache<T>
    {
        /// <summary>
        /// Gets the value stored by the key.
        /// </summary>
        /// <param name="key">The key from which to get a value.</param>
        /// <returns>The value, or <code>null</code> if no value is cached for the given key.</returns>
        T Get(String key);

        /// <summary>
        /// Puts the value into the cache by the key.  Only one key of the same value can be cached such that the value
        /// with the most recently put key is kept.
        /// If putting the value would extend the cache past the maximum size limit defined by <code>SetMaxSize()</code>
        /// </summary>
        /// <param name="key">key The key for which to cache the value.</param>
        /// <param name="value">The cached value.</param>
        void Put(String key, T value);

        /// <summary>
        /// Gets the allowed maximum size of the cache.
        /// </summary>
        /// <returns>The current maximum size of the cache.</returns>
        int GetMaxSize();

        /// <summary>
        /// Adjusts the maximum size of the cache.  If the cache is resized to hold less values that are currently cached
        /// then values must be ejected until the current size is equal to the maximum size.
        /// </summary>
        /// <param name="maxSize">The new maximum size of the cache.</param>
        /// <exception name="IllegalArgumentException">If maxSize is less than or equal to 0</exception>
        void SetMaxSize(int maxSize);

        /// <summary>
        /// Gets the number of currently cached items.
        /// </summary>
        /// <returns>The cached item count.</returns>
        int GetCurrentCacheSize();
    }

    public class MyCache<T> : ICache<T>
    {
        Dictionary<string, T> myDict = new Dictionary<string, T>();
        Queue<string> myQueue = new Queue<string>();
        int maxSize = 0;

        public T Get(string key)
        {
            T success;
            if (myDict.TryGetValue(key, out success))
            {
                return success;
            }
            return default(T);
        }

        public int GetCurrentCacheSize()
        {
            return myDict.Count;
        }

        public int GetMaxSize()
        {
            return myDict.Count;
        }

        public void Put(string key, T value)
        {
            if (myDict.ContainsKey(key))
            {
                myDict[key] = value;
                return;
            }

            if (myDict.Count + 1 > maxSize)
            {
                myDict.Remove(myQueue.Dequeue());
                myDict.TryAdd(key, value);
                myQueue.Enqueue(key);
            }
            else
            {
                myDict.TryAdd(key, value);
                myQueue.Enqueue(key);
            }
        }

        public void SetMaxSize(int maxSize)
        {
            if (maxSize >= 0)
            {
                if (this.maxSize > maxSize && myDict.Count > maxSize)
                {
                    while (myDict.Count > maxSize)
                    {
                        myDict.Remove(myQueue.Dequeue());
                    }
                    this.maxSize = maxSize;
                }
                else
                {
                    this.maxSize = maxSize;
                }
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            foreach(var pair in myDict)
            {
                stringBuilder.Append(pair.Key + " " + pair.Value + "\n");
            }

            return stringBuilder.ToString();
        }
    }
}