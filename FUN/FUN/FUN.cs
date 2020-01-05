using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FUN
{
    public class FUN
    {
        #region Обычные задачки
        public string StringReverse(string text)
        {
            string res = "";
            for (int i = 0; i<text.Length; i++)
            {
                res +=text[text.Length-1-i];
            }
            return res;
        }

        public int FirstFactorial(int num)
        {
            int res = 1;
            for (int i=1;i<=num;i++)
            {
                res *= i;    
            }
            // code goes here  
            return res;
        }

        public string LongestWord(string text)
        {
            string res = "";
            List<string> words = new List<string>();
            words = Regex.Split(text, "[^a-zA-Z]").ToList();
            foreach (var w in words)
            {
                if (res.Length < w.Length) res = w;
            }
            return res;
        }

        /// <summary>
        /// Have the function LetterChanges(str) take the str parameter being passed and modify it using the following algorithm. 
        /// Replace every letter in the string with the letter following it in the alphabet (ie. c becomes d, z becomes a). 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string LetterChanges(string str)
        {
            string res = "";
            List<char> alphabet = new List<char>();
            for (char l = 'a'; l<='z';l++)
            {
                alphabet.Add(l);
            }

            foreach (char s in str)
            {
                res += alphabet.IndexOf(s) > -1 ?
                    alphabet[(alphabet.IndexOf(s) == alphabet.Count - 1 ? -1 : alphabet.IndexOf(s)) + 1] : s;
            }

            return res;
        }

        /// <summary>
        /// Have the function SimpleAdding(num) add up all the numbers from 1 to num. 
        /// For example: if the input is 4 then your program should return 10 because 1 + 2 + 3 + 4 = 10. For the test cases, the parameter num will be any number from 1 to 1000.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int SimpleAdding(int num)
        {
            int res = 0;
            for (int i = 1; i <= num; i++)
            {
                res += i;
            }
            // code goes here  
            return res;
        }

        /// <summary>
        /// Have the function LetterCapitalize(str) take the str parameter being passed and capitalize the first letter of each word. Words will be separated by only one space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string LetterCapitalize(string str)
        {
            string res = "";
            List<string> words = new List<string>();
            words = str.Split(new[] { ' ' }).ToList();
            for (int i = 0; i<words.Count;i++)
            {
                words[i] = words[i][0].ToString().ToUpper()+words[i].Substring(1);    
            }
            res = string.Join(" ", words);
            return res;
        }
        /// <summary>
        ///  Решение квадратного уравнения с описанием шагов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public string GetCalculateQuadraticEquation(int a, int b, int c)
        {
            double x1 = 0;
            double x2 = 0;
            bool isCalc = true;
            StringBuilder stringBuilder = new StringBuilder();
            if (b != 0)
            {
                //1 поиск дискриминанат
                int D = b * b - 4 * a * c;
                stringBuilder.Append($"Дискриминант равен D={D}").Append(System.Environment.NewLine);

                //2 определяем сколько корней
                if (D > 0)
                {
                    stringBuilder.Append($"Дискриминант больше нуля, корня два").Append(System.Environment.NewLine);

                    x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    x2 = (-b - Math.Sqrt(D)) / (2 * a);
                }
                if (D < 0)
                {
                    stringBuilder.Append($"Дискриминант меньше нуля, решения нет").Append(System.Environment.NewLine);
                    isCalc = false;
                }
                if (D == 0)
                {
                    stringBuilder.Append($"Дискриминант равен нулю, корень один").Append(System.Environment.NewLine);
                    x1 = x2 = (-b) / (2 * a);
                }
            }
            else
            {
                stringBuilder.Append($"b=0, неполное квадратное уравнение").Append(System.Environment.NewLine);
                if((-c)/(a)<0)
                {
                    stringBuilder.Append($"Решения нет").Append(System.Environment.NewLine);
                    isCalc = false;
                }
                else
                {
                    x1 = Math.Sqrt((-c) / (a));
                    x2 = 0 - Math.Sqrt((-c) / (a));
                }
            }
            

            if (isCalc)
            {
                stringBuilder.Append($"x1={x1}; x2={x2}").Append(System.Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
        #endregion

        #region Аглоритмы сортировки массивов
        /// <summary>
        /// мерж массивов с сортировкой
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        private List<int> merge_arrays(List<int> A, List<int> B)
        {
            List<int> res = new List<int>();
            int i = 0;
            int j = 0;
            while (i < A.Count && j < B.Count)
            {
                if (A[i] <= B[j])
                {
                    res.Add(A[i]);
                    i += 1;
                }
                else
                {
                    res.Add(B[j]);
                    j += 1;
                }
            }

            while (i < A.Count)
            {
                res.Add(A[i]);
                i += 1;
            }
            while (j < B.Count)
            {
                res.Add(B[j]);
                j += 1;
            }
            return res;
        }

        /// <summary>
        /// сортировка слиянием
        /// </summary>
        /// <param name="A"></param>
        public void sort_merge(ref List<int> A)
        {
            if (A.Count <= 1)
            {
                return;
            }

            int middle = (int)(A.Count / 2);
            List<int> L = A.Skip(0).Take(middle).ToList();
            List<int> R = A.Skip(middle).ToList();
            sort_merge(ref L);
            sort_merge(ref R);
            var C = merge_arrays(L, R);
            for(int i=0; i < C.Count; i++)
            {
                A[i] = C[i];
            }
        }

        /// <summary>
        /// сортировка Хоара
        /// </summary>
        /// <param name="A"></param>
        public void sort_hoara(ref List<int> A)
        {
            if (A.Count <= 1)
            {
                return;
            }

            int bordier = A[0];
            List<int> L = new List<int>();
            List<int> M = new List<int>();
            List<int> R = new List<int>();
            foreach(var x in A)
            {
                if (bordier == x)
                {
                    M.Add(x);
                }
                else if (x < bordier)
                {
                    L.Add(x);
                }
                else
                {
                    R.Add(x);
                }
            }

            sort_hoara(ref L);
            sort_hoara(ref R);
            List<int> C = new List<int>();
            C.AddRange(L);
            C.AddRange(M);
            C.AddRange(R);
            for(int i=0; i < C.Count; i++)
            {
                A[i] = C[i];
            }
        }

        /// <summary>
        /// пузырек
        /// </summary>
        /// <param name="A"></param>
        public void sort_bubble(ref List<int>A)
        {
            bool isOrdered = false;
            while (!isOrdered)
            {
                isOrdered = true;
                for (int i=0; i<A.Count;i++)
                {
                    if(i!=A.Count-1 && A[i] > A[i + 1])
                    {
                        isOrdered = false;
                        int b = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = b;
                    }
                }
            }
        }
        #endregion

        #region Префикс функция и алгоритм Кнута Морриса Прата
        /// <summary>
        /// префикс функция от строки S
        /// </summary>
        /// <param name="S"></param>
        /// <returns>возвращает вектор длин префиксов</returns>
        public int[] get_prefix_func(string S)
        {
            int[] p = new int[S.Length];
            for (int i=1; i<S.Length;i++)
            {
                int k = p[i - 1];
                while (k>0 && S[i] != S[k])
                {
                    k = p[k - 1];
                }
                if (S[i] == S[k])
                {
                    k += 1;
                }
                p[i] = k;
            }
            return p;
        }

        /// <summary>
        /// Алгоритм Кнута — Морриса — Пратта
        /// </summary>
        /// <param name="S">строка</param>
        /// <param name="subString">подстрока</param>
        /// <returns>содержит ли S значение subString</returns>
        public bool is_exist_substring_knut_morris_pratt(string S, string subString)
        {
            string searchString = subString + "@" + S;
            int[] p = new int[searchString.Length];
            for (int i = 1; i<p.Length;i++)
            {
                int k = p[i - 1];
                while(k>0 && searchString[i]!= searchString[k])
                {
                    k = p[k - 1];
                }
                if(searchString[i] == searchString[k])
                {
                    k += 1;
                }
                p[i] = k;
                if (k == subString.Length)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region ГРАФЫ
        #region обходы
        /// <summary>
        /// Обход графа в ширину
        /// </summary>
        /// <param name="G">Таблица смежности</param>
        /// <returns>Словарь вершин и расстояний</returns>
        // Dictionary<int, int[]> G = new Dictionary<int, int[]>();
        // G.Add(0, new int[] { 1, 3 });
        // G.Add(1, new int[] { 0, 3, 4, 5 }); 
        // G.Add(2, new int[] { 4, 5 });
        // G.Add(3, new int[] { 0, 1, 5 });
        // G.Add(4, new int[] { 1, 2 });
        // G.Add(5, new int[] { 1, 2, 3 }); 
        public Dictionary<int,int> BFS(Dictionary<int, int[]> G)
        {
            Dictionary<int, int> distances = new Dictionary<int, int>();
            distances.Add(G.FirstOrDefault().Key, 0);
            Queue<int> q = new Queue<int>();
            q.Enqueue(G.FirstOrDefault().Key);
            while (q.Count > 0)
            {
                int current = q.Dequeue();
                foreach(int k in G[current])
                {
                    if (!distances.Any(x=>x.Key==k)) 
                    {
                        distances.Add(k, distances[current] + 1);
                        q.Enqueue(k);
                    }
                }
            }

            return distances;
        }

        /// <summary>
        /// Обход графа в глубину
        /// </summary>
        /// <param name="G">Таблица смежности</param>
        /// <param name="used">Посещенные вершины</param>
        /// <param name="vertex">Начальная вершина обхода</param>
        // Dictionary<int, int[]> G = new Dictionary<int, int[]>();
        // G.Add(0, new int[] { 1, 3 });
        // G.Add(1, new int[] { 0, 3, 4, 5 }); 
        // G.Add(2, new int[] { 4, 5 });
        // G.Add(3, new int[] { 0, 1, 5 });
        // G.Add(4, new int[] { 1, 2 });
        // G.Add(5, new int[] { 1, 2, 3 });
        public void DFS(int vertex, Dictionary<int, int[]> G, List<int> used)
        {
            used.Add(vertex);
            foreach (var k in G[vertex])
            {
                if (!used.Any(x => x == k))
                {
                    DFS(k, G, used);
                }
            }
        }
        /// <summary>
        /// Получить кол-во компонент связности
        /// </summary>
        /// <param name="G"></param>
        /// <returns></returns>
        public int GetComponentConnect(Dictionary<int, int[]> G)
        {
            int N = 0;
            List<int> used = new List<int>();
            foreach (var v in G.Select(x=>x.Key).ToList())
            {
                if (!used.Any(x => x == v))
                {
                    DFS(v, G, used);
                    N += 1;
                }
            }
            return N;
        }
        #endregion
        #region Дейкстра

        public Dictionary<string, Dictionary<string, int>> read_grapth()
        {
            Dictionary<string, Dictionary<string, int>> G = new Dictionary<string, Dictionary<string, int>>();
            Console.WriteLine("Укажите кол-во ребер");
            int M = int.Parse(Console.ReadKey().KeyChar.ToString());
            for(int i=0; i < M; i++)
            {
                Console.WriteLine("Укажите вершину от");
                string A = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine("Укажите вершину до");
                string B = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine("Укажите вес");
                int w = int.Parse(Console.ReadKey().KeyChar.ToString());
                AddEdgeToGrpath(G, A, B,  w);
                AddEdgeToGrpath(G, B, A, w);
            }
            return G;
        }

        private void AddEdgeToGrpath(Dictionary<string, Dictionary<string, int>>  G, string a, string b, int weight)
        {
            if(!G.Any(x=>x.Key==a))
            {
                Dictionary<string, int> weigths = new Dictionary<string, int>();
                weigths.Add(b, weight);
                G.Add(a, weigths);
            }
            else
            {
                G[a][b] = weight;
            }
        }

        /// <summary>
        /// Алгоритм дейкстры
        /// </summary>
        /// <param name="G">Граф</param>
        /// <param name="start">Начальная вершина</param>
        /// <returns>Словарь вершин и расстояний</returns>
        public Dictionary<string, int> GetShortestDistance_Dijkstra(Dictionary<string, Dictionary<string, int>> G, string start)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            if (!G.Any(x => x.Key == start))
            {
                return null;
            }

            Queue<string> q = new Queue<string>();
            q.Enqueue(start);
            distances.Add(start, 0);
            while (q.Count > 0)
            {
                string v = q.Dequeue();
                foreach (string neighb in G[v].Select(x=>x.Key).ToList())
                {
                    if (!distances.Any(x=>x.Key == neighb) || distances[v]+G[v][neighb]<distances[neighb])
                    {
                        if (!distances.Any(x => x.Key == neighb)) distances.Add(neighb, distances[v] + G[v][neighb]);
                        else distances[neighb] = distances[v] + G[v][neighb];
                        q.Enqueue(neighb);
                    }
                }
            }

            return distances;
        }

        /// <summary>
        /// Кратчайшее расстояние до вершины
        /// </summary>
        /// <param name="G">Граф</param>
        /// <param name="start">Начальная вершина</param>
        /// <param name="finish">Конечная вершина</param>
        /// <returns>Кратчайшее расстояние до вершины</returns>
        public int GetShortestDistancePoint_Dijkstra(Dictionary<string, Dictionary<string, int>> G, string start, string finish)
        {
            int res = 0;
            if (!G.Any(x => x.Key == start) || !G.Any(x => x.Key == finish))
            {
                return -1;
            }
            Dictionary<string, int> dist = GetShortestDistance_Dijkstra(G, start);
            res = dist[finish];
            return res;
        }
        /// <summary>
        /// Кратчайшее расстояние до вершины, путь
        /// </summary>
        /// <param name="G">Граф</param>
        /// <param name="start">Начальная вершина</param>
        /// <param name="finish">Конечная вершина</param>
        /// <returns>Кратчайшее расстояние до вершины, путь</returns>
        public string GetShortestDistancePath_Dijkstra(Dictionary<string, Dictionary<string, int>> G, string start, string finish)
        {
            string res = "";
            if (!G.Any(x => x.Key == start) || !G.Any(x => x.Key == finish))
            {
                return "";
            }
            Dictionary<string, int> dist = GetShortestDistance_Dijkstra(G, start);

            List<string> points = new List<string>();
            points.Add(finish);
            Queue<string> step = new Queue<string>();
            step.Enqueue(finish);
            while (step.Count > 0)
            {
                string current = step.Dequeue();
                foreach(string n in G[current].Select(x => x.Key).ToList())
                {
                    if (dist[current] - G[current][n] == dist[n])
                    {
                        step.Enqueue(n);
                        points.Add(n);
                    }
                }
            }
            points.Reverse();
            res = string.Join(",", points);
            return res;
        }
        #endregion
        #endregion
    }
}
