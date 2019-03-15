using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff_Kursovoj
{
    class SomeDif
    {
        public static string variables = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string znaks = "()-^+/*";

        public static string nums = "0123456789"; 

        protected string Number()
        {
            return "0";
        }

        protected static string X()
        {
            return "1";
        }

        protected static string SinX()
        {
            return "cos(x)";
        }

        protected static string CosX()
        {
            return "-sin(x)";
        }

        protected static string TanX()
        {
            return "(1/((cos(x))^2))";
        }

        protected static string LnX()
        {
            return "(1/x)";
        }

        protected static string SqrtX()
        {
            return "(1/(2*sqrt(x)))";
        }
    }
}