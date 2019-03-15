using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff_Kursovoj
{
    class Differential : SomeDif
    {

        private Dictionary<KeyValuePair<string, string>, KeyValuePair<string, string>> DC = new Dictionary<KeyValuePair<string, string>, KeyValuePair<string, string>>();

        public Differential()
        {

        }

        public void AddOne(string letter, string text, string math, string diff) //Добавление строки в словарь
        {
            DC.Add(new KeyValuePair<string, string> ( letter, text ) , new KeyValuePair<string, string> ( math, diff ));
        }

        public bool CheckLetter(string l) //Поиск буквы в словаре
        {
            bool r = true;
            if (DC.Count != 0)
            {
                foreach (KeyValuePair<string, string> key in DC.Keys)
                {
                    if (l== key.Key)
                    {
                        r = false;
                        break;
                    }
                }
            }
            return r;
        }

        public bool CheckNumber(string l) //Поиск буквы с проверкой на число
        {
            bool r = true;
            if (DC.Count != 0)
            {
                foreach (KeyValuePair<string, string> key in DC.Keys)
                {
                    if (l == key.Key && key.Value == "number")
                    {
                        r = false;
                        break;
                    }
                }
            }
            return r;
        }

        public void Test() //Обход каждой строки словаря
        {
            foreach (KeyValuePair<KeyValuePair<string, string>, KeyValuePair<string, string>> Element in DC.ToArray())
            {
                KeyValuePair<string, string> old = new KeyValuePair<string, string>(Element.Key.Key, Element.Key.Value);
                switch (Element.Key.Value)
                {
                    case "number":
                        {
                            DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());
                            break;
                        }
                    case "sin":
                        {
                            string value = Element.Value.Key;
                            if (value.Length == 1)
                            {
                                if (value == "x")
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, SinX());
                                }
                                else if (!CheckNumber(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());

                                }
                                else if (CheckLetter(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());
                                }
                                else
                                {
                                    if (GetValueValue(value) == "0") DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "0");
                                    else
                                    {
                                        string Y = ReturnToFirst(Element.Key.Key);
                                        Y = "cos" + Y.Substring(3);
                                        DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Y + "*(" + GetValueValue(Element.Value.Key) + ")");
                                    }
                                }
                            }
                            else
                            {
                                string Y = ReturnToFirst(Element.Key.Key);
                                Y = "cos" + Y.Substring(3);
                                string INPTDif = string.Empty;
                                GetDif(Element.Value.Key, ref INPTDif);
                                DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "(" + Y + "*(" + INPTDif + "))");
                            }
                            break;
                        }
                    case "cos":
                        {
                            string value = Element.Value.Key;
                            if (value.Length == 1)
                            {
                                if (value == "x")
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, CosX());
                                }
                                else if (!CheckNumber(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());

                                }
                                else if (CheckLetter(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());
                                }
                                else
                                {
                                    if (GetValueValue(value) == "0") DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "0");
                                    else
                                    {
                                        string Y = ReturnToFirst(Element.Key.Key);
                                        Y = "-sin" + Y.Substring(3);
                                        DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Y + "*(" + GetValueValue(Element.Value.Key) + ")");
                                    }
                                }
                            }
                            else
                            {
                                string Y = ReturnToFirst(Element.Key.Key);
                                Y = "-sin" + Y.Substring(3);
                                string INPTDif = string.Empty;
                                GetDif(Element.Value.Key, ref INPTDif);
                                DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "(" + Y + "*(" + INPTDif + "))");
                            }
                            break;
                        }
                    case "tan":
                        {
                            string value = Element.Value.Key;
                            if (value.Length == 1)
                            {
                                if (value == "x")
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, TanX());
                                }
                                else if (!CheckNumber(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());
                                }
                                else if (CheckLetter(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());
                                }
                                else
                                {
                                    if (GetValueValue(value) == "0") DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "0");
                                    else
                                    {
                                        string Y = ReturnToFirst(Element.Key.Key);
                                        Y = "(1/((cos" + Y.Substring(3) + ")^2)";
                                        DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Y + "*(" + GetValueValue(Element.Value.Key) + ")");
                                    }
                                }
                            }
                            else
                            {
                                string Y = ReturnToFirst(Element.Key.Key);
                                Y = "(1/((cos" + Y.Substring(3) + ")^2)";
                                string INPTDif = string.Empty;
                                GetDif(Element.Value.Key, ref INPTDif);
                                DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "(" + Y + "*(" + INPTDif + "))");
                            }
                            break;
                        }
                    case "ln":
                        {
                            string value = Element.Value.Key;
                            if (value.Length == 1)
                            {
                                if (value == "x")
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, LnX());
                                }
                                else if (!CheckNumber(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());

                                }
                                else if (CheckLetter(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());
                                }
                                else
                                {
                                    if (GetValueValue(value) == "0") DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "0");
                                    else
                                    {
                                        string Y = ReturnToFirst(Element.Key.Key);
                                        Y = "(1/(" + Y.Substring(2) + "))";
                                        DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Y + "*(" + GetValueValue(Element.Value.Key) + ")");
                                    }
                                }
                            }
                            else
                            {
                                if (value.Length == 2 && value[1] == '-')
                                {
                                    throw new Exception("Отрицательное число под знаком логарифма");
                                }
                                else
                                {
                                    string Y = ReturnToFirst(Element.Key.Key);
                                    Y = "(1 / (" + Y.Substring(2) + "))";
                                    string INPTDif = string.Empty;
                                    GetDif(Element.Value.Key, ref INPTDif);
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "(" + Y + "*(" + INPTDif + "))");
                                }
                            }
                            break;
                        }
                    case "sqrt":
                        {
                            string value = Element.Value.Key;
                            if (value.Length == 1)
                            {
                                if (value == "x")
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, SqrtX());
                                }
                                else if (!CheckNumber(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());

                                }
                                else if (CheckLetter(value))
                                {
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());
                                } 
                                else
                                {
                                    if (GetValueValue(value) == "0") DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "0");
                                    else
                                    {
                                        string Y = ReturnToFirst(Element.Key.Key);
                                        Y = " (1 / (2 * sqrt" + Y.Substring(4) + "))";
                                        DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Y + "*(" + GetValueValue(Element.Value.Key) + ")");
                                    }
                                }
                            }
                            else
                            {
                                if (value.Length == 2 && value[1] == '-')
                                {
                                    throw new Exception("Отрицательное число под знаком корня");
                                }
                                else
                                {
                                    string Y = ReturnToFirst(Element.Key.Key);
                                    Y = "(1 / (2 * sqrt" + Y.Substring(4) + "))";
                                    string INPTDif = string.Empty;
                                    GetDif(Element.Value.Key, ref INPTDif);
                                    DC[old] = new KeyValuePair<string, string>(Element.Value.Key, "(" + Y + "*(" + INPTDif + "))");
                                }
                            }
                            break;
                        }
                    default :
                        {
                            DC[old] = new KeyValuePair<string, string>(Element.Value.Key, Number());
                            break;
                        }
                }
            }
        }

        public Dictionary<KeyValuePair<string, string>, KeyValuePair<string, string>> GetDC() //Вернуть словарь на вывод на экран
        {
            return DC;
        }

        public void ClearDC() //Очистить словарь
        {
            DC.Clear();
        }

        public void GetDif(string input, ref string output) //решение польской записи
        {
            if (input.Length == 1)
            {
                CheckSymbol(input, ref output);
            }
            else if (input.Length == 2) throw new Exception("Error");
            else
            {
                Stack<KeyValuePair<string, string>> PLS = new Stack<KeyValuePair<string, string>>();
                for (int i=0;i<input.Length;i++)
                {
                    char ths = input[i];
                    if (ths == '+' || ths == '-' || ths == '*' || ths == '/' || ths == '^')
                    {
                        int second, first;
                        bool t1 = false, t2 = false;
                        if (PLS.Count < 2) throw new Exception("Проверьте входящую строку");
                        KeyValuePair<string, string> two = PLS.Pop();
                        KeyValuePair<string, string> one = PLS.Pop();
                        if (int.TryParse(one.Key, out first)) t1 = true;
                        if (int.TryParse(two.Key, out second)) t2 = true;
                        if (ths == '+')
                        {
                            if (t1&&t2) PLS.Push(new KeyValuePair<string, string>( (second + first).ToString(), "0"));
                            else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "+" + two.Key + ")", "(" + one.Value + "+" + two.Value + ")"));
                        }
                        else if (ths == '-')
                        {
                            if (t1 && t2) PLS.Push(new KeyValuePair<string, string>((first - second).ToString(), "0"));
                            else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "-" + two.Key + ")", "(" + one.Value + "-" + two.Value + ")"));
                        }
                        else if (ths == '*')
                        {
                            if (t1 && t2) PLS.Push(new KeyValuePair<string, string>((second * first).ToString(), "0"));
                            else if (t1 || (one.Key.Length==1 && CheckLetter(one.Key) && one.Key!="x"))
                            {
                                PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "*" + two.Key + ")", "((" + one.Key + ")*(" + two.Value + "))"));
                            }
                            else if (t2 || (two.Key.Length == 1 && CheckLetter(two.Key) && two.Key != "x"))
                            {
                                PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "*" + two.Key + ")", "((" + two.Key + ")*(" + one.Value + "))"));
                            }
                            else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "*" + two.Key + ")", "((" + one.Value + ")*(" +  two.Key + ")+(" + one.Key + ")*("  + two.Value  + "))"));
                        }
                        else if (ths == '/')
                        {
                            if (one.Key == two.Key) PLS.Push(new KeyValuePair<string, string>("1", "0"));
                            else if (t1 && t2)
                            {
                                if (first % second == 0) PLS.Push(new KeyValuePair<string, string>((first / second).ToString(), "0"));
                                else PLS.Push(new KeyValuePair<string, string>("(" + first.ToString() +  "/" +  second.ToString() + ")", "0"));
                            }
                            else if (int.TryParse(two.Key, out second))
                            {
                                if (second == 0) throw new Exception("Деление на ноль");
                                else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "/" + two.Key + ")", "(((" + one.Value + ")*(" + two.Key + ")-(" + one.Key + ")*(" + two.Value + "))" + "/(" + (second*second).ToString() + "))"));
                            }
                            else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "/" + two.Key + ")", "(((" + one.Value + ")*(" + two.Key + ")-(" + one.Key + ")*(" + two.Value + "))" + "/((" + two.Key + ")^2))"));
                        }
                        else
                        {
                            if (int.TryParse(two.Key, out second))
                            {
                                if (one.Key == "x")
                                {
                                    if (second == 1) PLS.Push(new KeyValuePair<string, string>("x", "1"));
                                    else if (second == 0) PLS.Push(new KeyValuePair<string, string>("1", "0"));
                                    else PLS.Push(new KeyValuePair<string, string>("(x^" + second + ")", "(" + (second) + "* (x^" + (second - 1) + "))"));
                                }
                                else if (one.Key == "exp")
                                {
                                    if (second == 1) PLS.Push(new KeyValuePair<string, string>("exp", "0"));
                                    else if (second == 0) PLS.Push(new KeyValuePair<string, string>("1", "0"));
                                    else PLS.Push(new KeyValuePair<string, string>("(exp^" + second + ")", "0"));
                                }
                                else if (one.Key.Length > 1)
                                {
                                    if (second == 1) PLS.Push(new KeyValuePair<string, string>(one.Key, one.Value));
                                    else if (second == 0) PLS.Push(new KeyValuePair<string, string>("1", "0"));
                                    else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "^" + second + ")", "((" + (second) + "* (" + one.Key + "^" + (second - 1) + "))*" + one.Value + ")"));
                                }
                                else if (int.TryParse(one.Key, out first))
                                {
                                    if (second == 1) PLS.Push(new KeyValuePair<string, string>(one.Key, "0"));
                                    else if (second == 0) PLS.Push(new KeyValuePair<string, string>("1", "0"));
                                    else PLS.Push(new KeyValuePair<string, string>((first * second).ToString(), "0"));
                                }
                                else
                                {
                                    if (second == 1) PLS.Push(new KeyValuePair<string, string>(one.Key, "0"));
                                    else if (second == 0) PLS.Push(new KeyValuePair<string, string>("1", "0"));
                                    else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "^" + second + ")", "0"));
                                }
                            }
                            else if (two.Key == "x")
                            {
                                if (one.Key == "exp") PLS.Push(new KeyValuePair<string, string>("(exp^x)", "(exp^x)"));
                                else if (one.Key == "x") PLS.Push(new KeyValuePair<string, string>("(x^x)", "((x^x)*(ln(x)+1))"));
                                else if (one.Key.Length > 1) PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "^x)", "(x*((" + one.Key + ")^((" + two.Key + ")-1))*(" + one.Value + ") + (" + one.Key + "^x)*" + "ln(" + one.Key + "))"));
                                else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "^x)", "((" + one.Key + "^x)*" + "ln(" + one.Key + "))"));
                            }
                            else if (two.Key == "exp")
                            {
                                if (one.Key == "exp") PLS.Push(new KeyValuePair<string, string>("(exp^exp)", "0"));
                                else if (one.Key == "x") PLS.Push(new KeyValuePair<string, string>("(x^exp)", "(exp*(x^(exp-1)))"));
                                else if (one.Key.Length > 1) PLS.Push(new KeyValuePair<string, string>("((" + one.Key + ")^(" + two.Key + "))", "((" + two.Key + ")*((" + one.Key + ")^((" + two.Key + ")-1))*(" + one.Value + ") +" + "((" + one.Key + ")^(" + two.Key + "))" + "*" + "ln(" + one.Key + ")*(" + two.Value + "))"));
                                else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "^x)", "0"));
                            }
                            else if (two.Key.Length > 1)
                            {
                                if (one.Key == "exp") PLS.Push(new KeyValuePair<string, string>("(exp^" + two.Key + ")", "((exp^" + two.Key + ")*(" + two.Value + "))"));
                                else if (one.Key == "x" || one.Key.Length > 1) PLS.Push(new KeyValuePair<string, string>("((" + one.Key + ")^(" + two.Key + "))", "((" + two.Key + ")*((" + one.Key + ")^((" + two.Key + ")-1))*(" + one.Value + ") +" + "((" + one.Key + ")^(" + two.Key + "))" + "*" + "ln(" + one.Key + ")*(" + two.Value + "))"));
                                else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "^(" + two.Key + "))","((" + one.Key + "^(" + two.Key + "))" + "*" + "ln(" + one.Key + ")*(" + two.Value + "))"));
                            }
                            else
                            {
                                if (one.Key == "exp") PLS.Push(new KeyValuePair<string, string>("(exp^" + two.Key + ")", "0"));
                                else if (one.Key == "x") PLS.Push(new KeyValuePair<string, string>("(x^" + two.Key + ")", "(" + two.Key+ "*(x^(" +two.Key + "-1)))"));
                                else if (one.Key.Length > 1) PLS.Push(new KeyValuePair<string, string>("((" + one.Key + ")^" + two.Key + ")", "((" + two.Key + "* ((" + one.Key + ")^(" + two.Key + "-1))*" + one.Value + ")"));
                                else PLS.Push(new KeyValuePair<string, string>("(" + one.Key + "^" + two.Key + ")", "0"));
                            } 
                        }
                    }
                    else if (ths == 'x') PLS.Push(new KeyValuePair<string, string>(ths.ToString(), X()));
                    else if (!CheckLetter(ths.ToString())) PLS.Push(new KeyValuePair<string, string>(ReturnToFirst(ths.ToString()), GetValueValue(ths.ToString())));
                    else if (ChechForExist(ths)) PLS.Push(new KeyValuePair<string, string>(ths.ToString(), Number()));
                    else throw new Exception("Проверьте входящую строку");
                }
                output = PLS.Pop().Value;
            }
        }

        string GetValueValue(string KeyKey) //Получить дифференциал из словаря по первому ключу
        {
            string ValueValue = string.Empty;
            foreach (KeyValuePair<KeyValuePair<string, string>, KeyValuePair<string, string>> Element in DC.ToArray())
            {
                if (Element.Key.Key == KeyKey)
                {
                    ValueValue = Element.Value.Value;
                    break;
                }
            }
            return  ValueValue;
        }

        string GetValueKey(string KeyKey) 
        {
            string ValueKey = string.Empty;
            foreach (KeyValuePair<KeyValuePair<string, string>, KeyValuePair<string, string>> Element in DC.ToArray())
            {
                if (Element.Key.Key == KeyKey)
                {
                    ValueKey = Element.Value.Key;
                    break;
                }
            }
            return ValueKey;
        }

        string GetKeyValue(string KeyKey)
        {
            string KeyValue = string.Empty;
            foreach (KeyValuePair<KeyValuePair<string, string>, KeyValuePair<string, string>> Element in DC.ToArray())
            {
                if (Element.Key.Key == KeyKey)
                {
                    KeyValue = Element.Key.Value;
                    break;
                }
            }
            return KeyValue;
        }

        void CheckSymbol(string input, ref string output) //ПРоверка текущего символа в польской записи 
        {
            if (input == "x") output = X();
            else if (!CheckLetter(input))
            {
                output = GetValueValue(input);
            }
            else output = Number();
        }

        bool ChechForExist(char smbl) //Проверка символа, если его нету в словаре 
        {
            bool rtrn = false;
            for (int i=0;i<variables.Length;i++)
            {
                if (smbl==variables[i])
                {
                    rtrn = true;
                    break;
                }
            }
            return rtrn;
        }

        public string ReturnToFirst(string inpt)
        {
            string output = string.Empty;
            if (GetKeyValue(inpt) == "number") return GetValueKey(inpt);
            else if (CheckLetter(inpt)) output = inpt;
            else if (inpt == "x") output = "x";
            else if (GetKeyValue(inpt) == "exp") return "exp";
            else if (GetValueKey(inpt).Length > 1)
            {
                string T = GetValueKey(inpt);
                Stack<string> G = new Stack<string>();
                for (int i = 0; i < T.Length; i++)
                {
                    if (T[i] == '+' || T[i] == '-' || T[i] == '*' || T[i] == '/' || T[i] == '^')
                    {
                        string two = G.Pop();
                        string one = G.Pop();
                        G.Push(one + T[i] + two);
                    }
                    else G.Push(ReturnToFirst(T[i].ToString()));
                }
                output = G.Pop();
            }
            else
            {
                output = ReturnToFirst(GetValueKey(inpt));
            }
            output = GetKeyValue(inpt) + "(" + output + ")";

            return output;
        }
    }
}