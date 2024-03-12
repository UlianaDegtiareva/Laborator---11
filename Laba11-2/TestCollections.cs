using ClassLibraryLaba10;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba11_2
{
    public class TestCollections
    {
        HashSet<Plants> collection1 = new HashSet<Plants>();
        HashSet<string> collection2 = new HashSet<string>();
        Dictionary<Plants, Flowers> collection3 = new Dictionary<Plants, Flowers>();
        Dictionary<string, Flowers> collection4 = new Dictionary<string, Flowers>();

        Flowers first, middle, last, noexist;

        // Конструктор класса
        public TestCollections()
        {
            noexist = new Flowers();
            noexist.RandomInit();
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    Flowers flower = new Flowers();
                    flower.RandomInit();
                    flower.Name += i.ToString();
                    collection1.Add(flower.BasePlant);
                    collection2.Add(flower.BasePlant.ToString());
                    collection3.Add(flower.BasePlant, flower);
                    collection4.Add(flower.BasePlant.ToString(), flower);

                    if (i == 0)
                        first = (Flowers)flower.Clone();
                    if (i == 1000 / 2)
                        middle = (Flowers)flower.Clone();
                    if (i == 1000 - 1)
                        last = (Flowers)flower.Clone();
                }
                catch
                {
                    i--;
                }
            }
        }
        public double TimeSearchElementInCollection(HashSet<Plants> collection, Plants element)
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsElement = !collection.Contains(element);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection1()
        {
            return TimeSearchElementInCollection(collection1, first.BasePlant);
        }

        public double TimeSearchMiddleElementCollection1()
        {
            return TimeSearchElementInCollection(collection1, last.BasePlant);
        }

        public double TimeSearchLastElementCollection1()
        {
            return TimeSearchElementInCollection(collection1, middle.BasePlant);
        }

        public double TimeSearchElementNotInCollection1()
        {
            return TimeSearchElementInCollection(collection1, noexist.BasePlant);
        }
        public double TimeSearchElementInCollection2(HashSet<string> collection, string element)
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsElement = !collection.Contains(element);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection2()
        {
            return TimeSearchElementInCollection2(collection2, first.BasePlant.ToString());
        }

        public double TimeSearchMiddleElementCollection2()
        {
            return TimeSearchElementInCollection2(collection2, middle.BasePlant.ToString());
        }

        public double TimeSearchLastElementCollection2()
        {
            return TimeSearchElementInCollection2(collection2, last.BasePlant.ToString());
        }

        public double TimeSearchElementNotInCollection2()
        {
            return TimeSearchElementInCollection2(collection2, noexist.BasePlant.ToString());
        }
        public double TimeSearchElementInDictionaryCol3Key(Dictionary<Plants, Flowers> collection, Plants element)
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsElement = !collection.ContainsKey(element);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection3()
        {
            return TimeSearchElementInDictionaryCol3Key(collection3, first.BasePlant);
        }

        public double TimeSearchMiddleElementCollection3()
        {
            return TimeSearchElementInDictionaryCol3Key(collection3, middle.BasePlant);
        }

        public double TimeSearchLastElementCollection3()
        {
            return TimeSearchElementInDictionaryCol3Key(collection3, last.BasePlant);
        }

        public double TimeSearchElementNotInCollection3()
        {
            return TimeSearchElementInDictionaryCol3Key(collection3, noexist.BasePlant);
        }
        public double TimeSearchElementInDictionaryValue(Dictionary<Plants, Flowers> collection, Flowers element)
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsElement = !collection.ContainsValue(element);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection3Value()
        {
            return TimeSearchElementInDictionaryValue(collection3, first);
        }

        public double TimeSearchMiddleElementCollection3Value()
        {
            return TimeSearchElementInDictionaryValue(collection3, middle);
        }

        public double TimeSearchLastElementCollection3Value()
        {
            return TimeSearchElementInDictionaryValue(collection3, last);
        }

        public double TimeSearchElementNotInCollection3Value()
        {
            return TimeSearchElementInDictionaryValue(collection3, noexist);
        }
        public double TimeSearchElementInDictionaryCollection4Key(Dictionary<string, Flowers> collection, string element)
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsElement = !collection.ContainsKey(element);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }
        public double TimeSearchFirstElementCollection4Key()
        {
            return TimeSearchElementInDictionaryCollection4Key(collection4, first.BasePlant.ToString());
        }

        public double TimeSearchMiddleElementCollection4Key()
        {
            return TimeSearchElementInDictionaryCollection4Key(collection4, middle.BasePlant.ToString());
        }

        public double TimeSearchLastElementCollection4Key()
        {
            return TimeSearchElementInDictionaryCollection4Key(collection4, last.BasePlant.ToString());
        }

        public double TimeSearchElementNotInCollection4Key()
        {
            return TimeSearchElementInDictionaryCollection4Key(collection4, noexist.BasePlant.ToString());
        }
        public double TimeSearchElementInDictionaryCollection4Value(Dictionary<string, Flowers> collection, Flowers element)
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsElement = !collection.ContainsValue(element);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection4Value()
        {
            return TimeSearchElementInDictionaryCollection4Value(collection4, first);
        }

        public double TimeSearchMiddleElementCollection4Value()
        {
            return TimeSearchElementInDictionaryCollection4Value(collection4, middle);
        }

        public double TimeSearchLastElementCollection4Value()
        {
            return TimeSearchElementInDictionaryCollection4Value(collection4, last);
        }

        public double TimeSearchElementNotInCollection4Value()
        {
            return TimeSearchElementInDictionaryCollection4Value(collection4, noexist);
        }
    }
}
