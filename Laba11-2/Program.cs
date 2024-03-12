using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLaba10;

namespace Laba11_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack plantStack = new Stack();
            // Добавление Plants в стек
            for (int i = 0; i < 2; i++)
            {
                Plants plants = new Plants();
                plants.RandomInit();
                plantStack.Push(plants);
            }
            // Добавление Trees в стек
            for (int i = 2; i < 4; i++)
            {
                Trees trees = new Trees();
                trees.RandomInit();
                plantStack.Push(trees);
            }
            Flowers flowers = new Flowers();
            flowers.RandomInit();
            plantStack.Push(flowers);
            // Добавление Roses в стек
            for (int i = 6; i < 8; i++)
            {
                Rose rose = new Rose();
                rose.RandomInit();
                plantStack.Push(rose);
            }
            Console.WriteLine("-------- СТЕК --------");
            Console.WriteLine();
            foreach (Plants plant in plantStack)
            {
                Console.WriteLine(plant);
            }
            int capacity = plantStack.Count;
            Console.WriteLine($"Количество элементов = {plantStack.Count} ");
            Console.WriteLine($"Емкость = {capacity}");
            Console.WriteLine();

            // Удаление объектов из стека
            for (int i = 0; i < 2; i++)
            {
                Plants removedPlant = plantStack.Pop() as Plants;
                Console.WriteLine("Удален объект из стека: " + removedPlant);
            }
            if (capacity / 2 > plantStack.Count) { capacity /= 2; }
            Console.WriteLine();
            foreach (Plants plant in plantStack)
            {
                Console.WriteLine(plant);
            }
            Console.WriteLine($"Количество элементов = {plantStack.Count} ");
            Console.WriteLine($"Емкость = {capacity}");
            Console.WriteLine();
            //Добавление элементов в стек
            Rose rose1 = new Rose("Алая роза", "Алый", "Легкий", true);
            rose1.RandomInit();
            plantStack.Push(rose1);
            Console.WriteLine("В стек добавлен объект: " + rose1);
            Console.WriteLine();
            if (capacity < plantStack.Count) { capacity *= 2; }
            foreach (Plants plant in plantStack)
            {
                Console.WriteLine(plant);
            }
            Console.WriteLine($"Количество элементов = {plantStack.Count} ");
            Console.WriteLine($"Емкость = {capacity}");
            Console.WriteLine();

            Console.WriteLine("ВЫПОЛНЕНИЕ ЗАПРОСОВ: ");
            Console.WriteLine("1. Розы без шипов, находящиеся в стеке: ");
            Stack thornlessRoses = ThornlessRosesFromStack(plantStack);
            if (thornlessRoses.Count == 0) Console.WriteLine("Массив пуст или не содержит роз без шипов");
            else
            {
                foreach (var item in thornlessRoses)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();

            Console.WriteLine("2. Вычисление средней длины деревьев");
            double height = MiddleHeight(plantStack, 11);
            if (height == 0)
            {
                Console.WriteLine("Исходный стек пуст");
            }
            else Console.WriteLine($"Средняя высота деревьев, которые ниже заданного числа = {height}");
            Console.WriteLine();
            Console.WriteLine("3. Поиск дерева с наименьшей высотой: ");
            Stack shorttrees = FindShortestTrees(plantStack);
            if (shorttrees.Count == 0) Console.WriteLine("Массив пуст или не содержит деревьев");
            else
            {
                foreach (var item in shorttrees)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Клонирование стека");
            Stack cloneStack = CloneStack(plantStack);

            foreach (Plants plant in cloneStack)
            {
                Console.WriteLine(plant);
            }

            Console.WriteLine();
            Console.WriteLine($"Сортировка стека");
            Stack sortedstack = SortStack(plantStack);

            foreach (Plants plant in sortedstack)
            {
                Console.WriteLine(plant);
            }
            Console.WriteLine();
            Console.WriteLine("Поиск элемента");
            int result = Search(plantStack, flowers);
            if (result > -1) Console.WriteLine($"Элемент '{flowers}' находится в стеке на {result + 1}");
            else Console.WriteLine($" Элемент '{flowers}' не содержится в стеке");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            SortedDictionary<Plants, Plants> sDict = new SortedDictionary<Plants, Plants>();
            Plants p1 = new Plants();
            p1.RandomInit();
            sDict.Add(p1, p1);
            Plants p2 = new Plants();
            p2.RandomInit();
            sDict.Add(p2, p2);

            Trees t1 = new Trees();
            t1.RandomInit();
            Plants plants3 = new Plants(t1.Name, t1.Color);
            sDict.Add(plants3, t1);
            Trees t2 = new Trees();
            t2.RandomInit();
            Plants plants4 = new Plants(t2.Name, t2.Color);
            sDict.Add(plants4, t2);

            Flowers f1 = new Flowers();
            f1.RandomInit();
            Plants plants5 = new Plants(f1.Name, f1.Color);
            sDict.Add(plants5, f1);
            Flowers f2 = new Flowers();
            f2.RandomInit();
            Plants plants6 = new Plants(f2.Name, f2.Color);
            sDict.Add(plants6, f2);

            Rose r1 = new Rose();
            r1.RandomInit();
            Plants plants7 = new Plants(r1.Name, r1.Color);
            sDict.Add(plants7, r1);
            Rose r2 = new Rose();
            r2.RandomInit();
            Plants plants8 = new Plants(r2.Name, r2.Color);
            sDict.Add(plants8, r2);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("- - - -  ОТСОРТИРОВАННЫЙ СЛОВАРЬ -  - -- - -");
            Console.WriteLine();
            Console.WriteLine();

            foreach (var pair in sDict)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }
            Console.WriteLine();
            //удаление элемента по ключу

            Console.WriteLine($"Удален элемент с ключом: {plants4}");
            sDict.Remove(plants4);
            foreach (var pair in sDict)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }
            Console.WriteLine();

            Flowers newelevent = new Flowers("Мимоза", "Желтый", "Приятный");
            Plants newflower = new Plants(newelevent.Name, newelevent.Color);
            sDict.Add(newflower, newelevent);
            Console.WriteLine($"Добавление элемента : {newflower}");
            foreach (var pair in sDict)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }
            Console.WriteLine();
            Console.WriteLine("ВЫПОЛНЕНИЕ ЗАПРОСОВ: ");
            Console.WriteLine("1. Розы без шипов, находящиеся в словаре: ");
            SortedDictionary<Plants, Plants> thornlessDict = ThornlessRosesFromDict(sDict);
            if (thornlessDict.Count == 0) Console.WriteLine("Словарь пуст или не содержит роз без шипов");
            else
            {
                foreach (KeyValuePair<Plants, Plants> pair in thornlessDict)
                {
                    Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("2. Вычисление средней высоты деревьев, находящихся в словаре: ");
            double heightsDict = MiddleHeightFromDict(sDict, 11);
            if (heightsDict == 0)
            {
                Console.WriteLine("Исходный стек пуст");
            }
            else Console.WriteLine($"Средняя высота деревьев, которые ниже заданного числа = {height}");
            Console.WriteLine();

            Console.WriteLine("3. Поиск дерева с наименьшей высотой: ");
            SortedDictionary<Plants, Plants> shorttrees1 = FindShortestTreesromDict(sDict);
            if (shorttrees1.Count == 0) Console.WriteLine("Cловарь пуст");
            else
            {
                foreach (KeyValuePair<Plants, Plants> pair in shorttrees1)
                {
                    Console.WriteLine(pair);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Поиск элемента");
            Console.WriteLine();
            int resultsDict = Search(sDict, newflower);
            if (resultsDict > 0)
                Console.WriteLine($"Элемент '{newflower}' находится на {resultsDict + 1} месте");
            else Console.WriteLine($"Элемент '{newflower}' не существует в словаре");

            Console.WriteLine();
            Console.WriteLine("Клонирование словаря");
            SortedDictionary<Plants, Plants> cloneDict = CloneSortedDictionary(sDict);
            foreach (KeyValuePair<Plants, Plants> pair in cloneDict)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента коллекции---------------------------------------");
            TestCollections test = new TestCollections();

            double time1 = test.TimeSearchFirstElementCollection1();
            double time2 = test.TimeSearchFirstElementCollection2();
            double time3 = test.TimeSearchFirstElementCollection3();
            double time4 = test.TimeSearchFirstElementCollection4Key();
            double time17 = test.TimeSearchFirstElementCollection3Value();
            double time18 = test.TimeSearchFirstElementCollection4Value();

            Console.WriteLine("Среднее время в HashSet<Plants>: " + time1 + " ticks");
            Console.WriteLine("Среднее время в HashSet<string>: " + time2 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<Plants, Flowers> по ключу: " + time3 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<Plants, Flowers> по значению: " + time17 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<string, Flowers> по ключу: " + time4 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<string, Flowers> по значению: " + time18 + " ticks");

            Console.WriteLine();
            Console.WriteLine("Поиск серединного элемента коллекции---------------------------------------");
            double time5 = test.TimeSearchMiddleElementCollection1();
            double time6 = test.TimeSearchMiddleElementCollection2();
            double time7 = test.TimeSearchMiddleElementCollection3();
            double time8 = test.TimeSearchMiddleElementCollection4Key();
            double time19 = test.TimeSearchMiddleElementCollection3Value();
            double time20 = test.TimeSearchMiddleElementCollection4Value();

            Console.WriteLine("Среднее время в HashSet<Plants>: " + time5 + " ticks");
            Console.WriteLine("Среднее время в HashSet<string>: " + time6 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<Plants, Flowers> по ключу: " + time7 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<Plants, Flowers> по значению: " + time19 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<string, Flowers> по ключу:  " + time8 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<string, Flowers> по значению: " + time20 + " ticks");

            Console.WriteLine();
            Console.WriteLine("Поиск последнего элемента коллекции---------------------------------------");
            double time9 = test.TimeSearchLastElementCollection1();
            double time10 = test.TimeSearchLastElementCollection2();
            double time11 = test.TimeSearchLastElementCollection3();
            double time12 = test.TimeSearchLastElementCollection4Key();
            double time21 = test.TimeSearchLastElementCollection3Value();
            double time22 = test.TimeSearchLastElementCollection4Value();

            Console.WriteLine("Среднее время в HashSet<Plants>: " + time9 + " ticks");
            Console.WriteLine("Среднее время в HashSet<string>: " + time10 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<Plants, Flowers> по ключу: " + time11 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<Plants, Flowers> по значению: " + time21 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<string, Flowers> по ключу: " + time12 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<string, Flowers> по значению: " + time22 + " ticks");

            Console.WriteLine();
            Console.WriteLine("Поиск элемента не из коллекции---------------------------------------");
            double time13 = test.TimeSearchElementNotInCollection1();
            double time14 = test.TimeSearchElementNotInCollection2();
            double time15 = test.TimeSearchElementNotInCollection3();
            double time16 = test.TimeSearchElementNotInCollection4Key();
            double time23 = test.TimeSearchElementNotInCollection3();
            double time24 = test.TimeSearchElementNotInCollection4Value();

            Console.WriteLine("Среднее время в HashSet<Plants>: " + time13 + " ticks");
            Console.WriteLine("Среднее время в HashSet<string>: " + time14 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<Plants, Flowers> по ключу: " + time15 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<Plants, Flowers> по значению: " + time23 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<string, Flowers> по ключу: " + time16 + " ticks");
            Console.WriteLine("Среднее время в Dictionary<string, Flowers> по значению: " + time24 + " ticks");
        }




        static Stack ThornlessRosesFromStack(Stack stack)
        {
            if (stack == null || stack.Count == 0)
            {
                return new Stack(); // Возвращаем пустой стек, если исходный стек пуст
            }

            Stack thornlessRosesStack = new Stack();

            foreach (Plants plant in stack)
            {
                if (plant is Rose rose && !rose.Thorns)
                {
                    thornlessRosesStack.Push(plant);
                }
            }
            return thornlessRosesStack;
        }
        static double MiddleHeight(Stack stack, double value)
        {
            double middleHeight = 0;
            int count = 0;

            Stack<Trees> treesStack = new Stack<Trees>();

            foreach (Plants plant in stack)
            {
                Trees tree = plant as Trees;
                if (tree != null)
                {
                    if (tree.Height < value)
                    {
                        middleHeight += tree.Height;
                        count++;
                        treesStack.Push(tree);
                    }
                }
            }
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return middleHeight / count;
            }
        }
        public static Stack FindShortestTrees(Stack stack)
        {
            if (stack == null || stack.Count == 0)
            {
                return new Stack(); // Возвращаем пустой стек, если входной стек пуст
            }

            Stack shortestTrees = new Stack();
            double shortestHeight = 11;

            foreach (Plants plant in stack)
            {
                if (plant is Trees tree)
                {
                    if (tree.Height < shortestHeight)
                    {
                        shortestHeight = tree.Height;
                        shortestTrees.Clear();
                        shortestTrees.Push(tree);
                    }
                    else if (tree.Height == shortestHeight)
                    {
                        shortestTrees.Push(tree);
                    }
                }
            }
            // Для возврата стека с наименьшими деревьями в порядке обхода
            Stack result = new Stack();
            foreach (Trees shortestTree in shortestTrees)
            {
                result.Push(shortestTree);
            }
            return result;
        }
        static Stack CloneStack(Stack original)
        {
            Stack cloneStack = new Stack();

            foreach (Plants item in original)
            {
                if (item is Flowers)
                {
                    cloneStack.Push(((Flowers)item.Clone()) as Plants);
                }
                else if (item is Trees)
                {
                    cloneStack.Push(((Trees)item.Clone()) as Plants);
                }
                else if (item is Rose)
                {
                    cloneStack.Push(((Rose)item.Clone()) as Plants);
                }
                else
                {
                    cloneStack.Push(item.Clone() as Plants);
                }
            }
            // Поворачиваем клонированный стек, так как он будет в обратном порядке
            Stack reversedCloneStack = new Stack();
            while (cloneStack.Count > 0)
            {
                reversedCloneStack.Push(cloneStack.Pop());
            }

            return reversedCloneStack;
        }
        static Stack SortStack(Stack stack)
        {
            Stack tempStack = new Stack();
            foreach (Plants item in stack)
            {
                tempStack.Push(item);
            }
            if (tempStack == null || tempStack.Count <= 1)
            {
                return tempStack; // Нечего сортировать, если стек пуст или содержит один элемент
            }
            // Перевод стекa в массив для сортировки
            Plants[] array = new Plants[tempStack.Count];
            int index = 0;
            foreach (Plants plant in tempStack)
            {
                array[index] = plant;
                index++;
            }
            Array.Sort(array);
            // Создание нового стека для хранения отсортированных элементов
            Stack sortedStack = new Stack();
            // Перевод отсортированного массива обратно в стек
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedStack.Push(array[i]);
            }
            return sortedStack;
        }
        static SortedDictionary<K, T> ThornlessRosesFromDict<K, T>(SortedDictionary<K, T> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                return new SortedDictionary<K, T>(); // Возвращаем пустой словарь, если исходный словарь пуст
            }
            SortedDictionary<K, T> thornlessRosesDictionary = new SortedDictionary<K, T>();

            foreach (KeyValuePair<K, T> pair in dictionary)
            {
                if (pair.Value is Rose rose && !rose.Thorns)
                {
                    thornlessRosesDictionary.Add(pair.Key, pair.Value);
                }
            }
            return thornlessRosesDictionary;
        }
        static double MiddleHeightFromDict<K, T>(SortedDictionary<K, T> dict, double value)
        {
            double middleHeight = 0;
            int count = 0;

            SortedDictionary<K, T> treesDictionary = new SortedDictionary<K, T>();

            foreach (KeyValuePair<K, T> pair in dict)
            {
                Trees tree = pair.Value as Trees;
                if (tree != null && tree.Height < value)
                {
                    middleHeight += tree.Height;
                    count++;
                    treesDictionary.Add(pair.Key, pair.Value);
                }
            }
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return middleHeight / count;
            }
        }
        static SortedDictionary<K, T> FindShortestTreesromDict<K, T>(SortedDictionary<K, T> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                return new SortedDictionary<K, T>();
            }
            SortedDictionary<K, T> shortestTrees = new SortedDictionary<K, T>();
            double shortestHeight = double.MaxValue;

            foreach (KeyValuePair<K, T> pair in dictionary)
            {
                Trees tree = pair.Value as Trees;
                if (tree != null && tree.Height < shortestHeight)
                {
                    shortestHeight = tree.Height;
                    shortestTrees.Add(pair.Key, pair.Value);
                }
                else if (tree != null && tree.Height == shortestHeight)
                {
                    shortestTrees.Add(pair.Key, pair.Value);
                }
            }
            return shortestTrees;
        }
        static int Search<K, T>(SortedDictionary<K, T> d, K keyToFind)
        {
            if (d.ContainsKey(keyToFind))
            {
                int index = 0;
                foreach (KeyValuePair<K, T> pair in d)
                {
                    if (pair.Key.Equals(keyToFind))
                    {
                        return index;
                    }
                    index++;
                }
            }

            return -1;
        }
        public static SortedDictionary<K, T> CloneSortedDictionary<K, T>(SortedDictionary<K, T> original) where T : ICloneable
        {
            SortedDictionary<K, T> cloneDict = new SortedDictionary<K, T>();

            foreach (var pair in original)
            {
                if (pair.Key is ICloneable && pair.Value is ICloneable)
                {
                    K clonedKey = (K)((pair.Key as ICloneable).Clone());
                    T clonedValue = (T)((pair.Value as ICloneable).Clone());
                    cloneDict.Add(clonedKey, clonedValue);
                }
            }

            return cloneDict;
        }
        static int Search(Stack stack, Plants plants)
        {
            if (stack == null || plants == null)
            {
                return -1;
            }

            if (stack.Contains(plants))
            {
                int index = 0;
                foreach (Plants item in stack)
                {
                    if (plants.Equals(item))
                    {
                        return index;
                    }
                    index++;
                }
            }

            return -1;
        }

    }
}
