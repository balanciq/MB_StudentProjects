using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diff_Kursovoj
{
    class Parsing
    {
        
        Differential Dictionary = new Differential();

        public Parsing()
        {

        }

        string[] accept = { "sin", "cos", "tan", "ln", "sqrt" };

        public void GeneralProcess(ref string IN, ref string CopyIN, ref string poland, ref string OUT)
        {
            Dictionary.ClearDC();
            IN = IN.Replace(" ", string.Empty);
            CopyIN = IN;
            CheckToValidInput(IN);
            SearchEXP(ref IN, CopyIN);
            SearchNumbers(ref IN, CopyIN);
            bool check = true;
            while (check)
            {
                check = false;
                string t = BeforeSearch(IN);
                if (t != string.Empty) Search(ref IN, t, ref check, CopyIN);
                else check = false;
            }
            Dictionary.Test();
            poland = Polska(IN);
            if (poland.Length == 2 && poland[1] == '-')
            {
                poland = poland[0].ToString();
                Dictionary.GetDif(poland, ref OUT);
                OUT = "-" + OUT;
            }
            else
            {
                Dictionary.GetDif(poland, ref OUT);
            }
            After(ref OUT);
        }
        
        string BeforeSearch(string text)
        {
            int k = -1;
            string t = string.Empty;
            for (int i = 0; i < accept.Length; i++)
            {
                bool b = text.Contains(accept[i]);
                if (b)
                {
                    if (k < text.LastIndexOf(accept[i]))
                    {
                        k = text.LastIndexOf(accept[i]);
                        t = accept[i];
                    }
                }
            }
            return t;
        }

        void SearchEXP(ref string text, string CopyIN)
        {
            bool b = text.Contains("exp");
            if (b)
            {
                char l = ChoseLetter(CopyIN);
                Dictionary.AddOne(l.ToString(), "exp", "e", "");
                text = text.Replace("exp", l.ToString());
            }
        }

        void Search(ref string text, string S, ref bool check, string CopyIN) // поиск функций по типу синуса
        {
            int z;
            bool b = text.Contains(S);
            if (b)
            {
                check = true;
                z = text.LastIndexOf(S);
                int start = z + S.Length;
                if (text[start] != '(') throw new Exception("Используйте скобки");
                int end = start;
                int c = 0;
                for (int i = start + 1; i < text.Length; i++)
                {
                    if (text[i] == ')' && c == 0)
                    {
                        end = i;
                        break;
                    }
                    else if (text[i] == '(') c++;
                    else if (text[i] == ')') c--;
                }
                char l = ChoseLetter(CopyIN);
                Dictionary.AddOne(l.ToString(), S, Polska(text.Substring(start, end - start + 1)), "");/////
                text = text.Replace(text.Substring(start - S.Length, end - start + S.Length + 1), l.ToString());
            }
        }

        void CheckErrors(string text) //проверка симметричности скобок
        {
            if (text.Contains("()")) throw new Exception("Проверьте входящую строку");
            int start = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(') start++;
                else if (text[i] == ')') start--;
                if (start < 0 ) throw new Exception("Проверьте скобки");
            }
            if (start !=0) throw new Exception("Проверьте скобки");
        }

        char ChoseLetter(string text) // проверка на занятость буквы для словаря
        {
            char t = '|';
            for (int i = 0; i < SomeDif.variables.Length; i++)
            {
                bool f = true;
                for (int j = 0; j < text.Length; j++)
                {
                    if (SomeDif.variables[i] == text[j]) f = false;
                }
                if (f && Dictionary.CheckLetter(SomeDif.variables[i].ToString())) t = SomeDif.variables[i];
            }
            return t;
        }

        string Polska(string text)//перевод строки в постфиксуню запись(обратная польская)
        {
            string p = string.Empty;
            Stack<char> St = new Stack<char>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= (char)48 && text[i] <= (char)57) p += text[i];
                else if ((text[i] >= (char)65 && text[i] <= (char)90) || (text[i] >= (char)97 && text[i] <= (char)122)) p += text[i];
                else if (GetPriority(text[i]) > 0)
                {
                    if (St.Count > 0 && St.Peek() == '(') St.Push(text[i]);
                    else
                    {
                        if (St.Count > 0 && GetPriority(text[i]) > GetPriority(St.Peek()))
                        {
                            St.Push(text[i]);
                        }
                        else
                        {
                            while (St.Count > 0 && GetPriority(text[i]) <= GetPriority(St.Peek()))
                            {
                                p += St.Pop();
                            }
                            St.Push(text[i]);
                        }
                    }
                }
                else if (text[i] == '(') St.Push(text[i]);
                else if (text[i] == ')')
                {
                    while (St.Peek() != '(')
                    {
                        p += St.Peek();
                        St.Pop();
                    }
                    St.Pop();
                }
            }
            while (St.Count > 0)
            {
                p += St.Pop();
            }
            return p;
        }

        int GetPriority(char h)//получение приоритета знака
        {
            switch (h)
            {
                case '(':
                case ')':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 4;
            }

            //if (h == '(' || h == ')') return 0;
            //if (h == '+' || h == '-') return 1;
            //if (h == '*' || h == '/') return 2;
            //if (h == '^') return 3;
            //else return 4;
        }

        void SearchNumbers(ref string text, string CopyIN) //поиск чисел 
        {
            for (int i = 0; i < text.Length; i++)
            {
                string p = string.Empty;
                while (text[i] >= (char)48 && text[i] <= (char)57)
                {
                    p += text[i];
                    i++;
                    if (i == text.Length) break;
                }
                if (p != string.Empty)
                {
                    if (p.Length > 1 && p[0] == '0') throw new Exception("Число не может начинаться с нуля");
                    char l = ChoseLetter(CopyIN);
                    Dictionary.AddOne(l.ToString(), "number", p, "");
                    text = text.Replace(p, l.ToString());
                }
            }
        }

        void After(ref string input)
        {
            bool Reapeat = true;
            input = input.Replace("((x))", "(x)");
            PM(ref input);
            SearchOne(ref input);
            while (Reapeat)
            {
                Reapeat = false;
                SearchZeroR(ref input, ref Reapeat, 0);
                SearchZeroR(ref input, ref Reapeat, 1);
                SearchZeroR(ref input, ref Reapeat, 2);
                SearchZeroR(ref input, ref Reapeat, 3);
                SearchZeroL(ref input, ref Reapeat, 0);
                SearchZeroL(ref input, ref Reapeat, 1);
                SearchZeroL(ref input, ref Reapeat, 2);
                SearchZeroL(ref input, ref Reapeat, 3);
                SearchZ(ref input);
            }
            SearchOne(ref input);
            LastStep(ref input);
            PM(ref input);
        }

        void PM(ref string input)
        {
            bool b = input.Contains("+-");
            if (b) input = input.Replace("+-", "-");
            if (input[0] == '-' && input[1] == '-') input = input.Substring(2);
        }

        void SearchZeroL(ref string input, ref bool Reapeat, int t)
        {
            string L = string.Empty, R = string.Empty;
            for (int i = 0; i < t; i++)
            {
                L += '(';
                R += ')';
            }
            string search = "*" + L + "0" + R ;
            bool b = input.Contains(search);
            if (b)
            {
                Reapeat = true;
                string fordel = string.Empty;
                int k = input.IndexOf(search);
                if (input[k - 1] == ')')
                {
                    int str = 1;
                    fordel += input[k - 1];
                    for (int i = k - 2; i >= 0; i--)
                    {
                        fordel = input[i] + fordel;
                        if (input[i] == ')') str++;
                        else if (input[i] == '(') str--;
                        if (str < 0) throw new Exception("Error");
                        else if (str == 0)
                        {
                            break;
                        }
                    }
                    fordel = fordel + search;
                    k = input.IndexOf(fordel);
                    if (k!=0)
                    {
                        for (int i=0;i<accept.Length;i++)
                        {
                            input = input.Replace(accept[i] + fordel, "0");
                        }
                    }
                    input = input.Replace(fordel, "0");
                }
            }
        }

        void SearchZeroR(ref string input, ref bool Reapeat, int t)
        {
            string L = string.Empty, R = string.Empty;
            for (int i = 0; i < t; i++)
            {
                L += '(';
                R += ')';
            }
            string search = L + "0" + R + "*";
            bool b = input.Contains(search);
            if (b)
            {
                Reapeat = true;
                string fordel = string.Empty;
                int k = input.IndexOf(search);
                if (input[k] == '(')
                {
                    int str = 1;
                    fordel += input[k];
                    for (int i = k + search.Length + 1; i < input.Length; i++)
                    {
                        fordel += input[i];
                        if (input[i] == '(') str++;
                        else if (input[i] == ')') str--;
                        if (str < 0) throw new Exception("Error");
                        else if (str == 0)
                        {
                            break;
                        }
                    }
                    fordel = search + fordel;
                    input = input.Replace(fordel, "0");
                }
            }
        }

        void SearchOne(ref string input)
        {
            input = input.Replace("*((1))", "");
            input = input.Replace("((1))*", "");
            input = input.Replace("*(1)", "");
            input = input.Replace("(1)*", "");
            input = input.Replace("*1", "");
            input = input.Replace("1*", "");
        }

        void SearchZ(ref string input)
        {
            input = input.Replace("+0+", "+");
            input = input.Replace("+(0)+", "+");
            input = input.Replace("+0-", "-");
            input = input.Replace("+(0)-", "-");
            input = input.Replace("-0+", "+");
            input = input.Replace("-(0)+", "+");
            input = input.Replace("(0)+", "");
            input = input.Replace("0+", "");
            input = input.Replace("+(0)", "");
            input = input.Replace("+0", "");
            input = input.Replace("-0", "");
            input = input.Replace("-(0)", "");
            input = input.Replace("0-", "-");
            input = input.Replace("(0)-", "-");
        }

        void LastStep(ref string input)
        {
            if (input.Length == 3 && input[0] == '(' && input[2] == ')') input = input[1].ToString();
            else if (input.Length == 5 && input[0] == '(' && input[1] == '(' && input[3] == ')' && input[4] == ')') input = input[2].ToString();
        }

        void CheckToValidInput(string IN) //
        {
            string str = IN;
            CheckSymbols(str);
            CheckErrors(str);
            CheckMinus(str);
            CheckZnaks(str);
            ConcateSTR(str);

        }

        void CheckSymbols(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                bool t = false;
                for (int j = 0; j < SomeDif.variables.Length; j++)
                {
                    if (str[i] == SomeDif.variables[j])
                    {
                        t = true;
                        break;
                    }
                }
                for (int j = 0; j < SomeDif.nums.Length; j++)
                {
                    if (t) break;
                    if (str[i] == SomeDif.nums[j])
                    {
                        t = true;
                        break;
                    }
                }
                for (int j = 0; j < SomeDif.znaks.Length; j++)
                {
                    if (t) break;
                    if (str[i] == SomeDif.znaks[j])
                    {
                        t = true;
                        break;
                    }
                }
                if (!t) throw new Exception("Проверьте входящую строку");
            }
        }

        void CheckMinus(string str)
        {
            for (int i = 3; i < SomeDif.znaks.Length; i++)
            {
                if (str[0] == SomeDif.znaks[i]) throw new Exception("Проверьте входящую строку");
            }
        }

        void CheckZnaks(string str)
        {
            for (int i = 1; i < str.Length - 1; i++)
            {
                for (int j = 2; j < SomeDif.znaks.Length; j++)
                {
                    if (str[i] == SomeDif.znaks[j])
                    {
                        for (int k = 2; k < SomeDif.znaks.Length; k++)
                        {
                            if (str[i - 1] == SomeDif.znaks[k]) throw new Exception("Проверьте входящую строку");
                            if (str[i + 1] == SomeDif.znaks[k]) throw new Exception("Проверьте входящую строку");
                        }
                    }
                }
            }
        }

        void ConcateSTR(string str)
        {
            string T = string.Empty;
            for (int i=0;i<str.Length;i++)
            {
                bool t = false;
                for (int j=0;j<SomeDif.variables.Length;j++)
                {
                    if (str[i] == SomeDif.variables[j])
                    {
                        T += str[i];
                        t = true;
                        break;
                    }
                }
                if (!t)
                {
                    if (T.Length >=2)
                    {
                        bool c = true;
                        if (T == "exp")
                        {
                            c = false;
                        }
                        else
                        {
                            for (int j = 0; j < accept.Length; j++)
                            {
                                if (T == accept[j])
                                {
                                    c = false;
                                    break;
                                }
                            }
                        }
                        if (c) throw new Exception("Проверьте входящую строку");
                    }
                    T = string.Empty;
                }
            }
        }
    }
}
