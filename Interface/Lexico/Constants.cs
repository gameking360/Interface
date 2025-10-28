using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Lexico
{
    public abstract class Constants : ScannerConstants
    {
        public int EPSILON = 0;
        public int DOLLAR = 1;


        public const int t_identificador = 2;
        public const int t_cint = 3;
        public const int t_cfloat = 4;
        public const int t_cstring = 5;
        public const int t_pr_add = 6;
        public const int t_pr_and = 7;
        public const int t_pr_begin = 8;
        public const int t_pr_bool = 9;
        public const int t_pr_count = 10;
        public const int t_pr_delete = 11;
        public const int t_pr_do = 12;
        public const int t_pr_elementOf = 13;
        public const int t_pr_else = 14;
        public const int t_pr_end = 15;
        public const int t_pr_false = 16;
        public const int t_pr_float = 17;
        public const int t_pr_if = 18;
        public const int t_pr_int = 19;
        public const int t_pr_list = 20;
        public const int t_pr_not = 21;
        public const int t_pr_or = 22;
        public const int t_pr_print = 23;
        public const int t_pr_read = 24;
        public const int t_pr_size = 25;
        public const int t_pr_string = 26;
        public const int t_pr_true = 27;
        public const int t_pr_until = 28;
        public const int t_TOKEN_29 = 29; //"+"
        public const int t_TOKEN_30 = 30; //"-"
        public const int t_TOKEN_31 = 31; //"*"
        public const int t_TOKEN_32 = 32; //"/"
        public const int t_TOKEN_33 = 33; //"=="
        public const int t_TOKEN_34 = 34; //"~="
        public const int t_TOKEN_35 = 35; //"<"
        public const int t_TOKEN_36 = 36; //">"
        public const int t_TOKEN_37 = 37; //"="
        public const int t_TOKEN_38 = 38; //"<-"
        public const int t_TOKEN_39 = 39; //"("
        public const int t_TOKEN_40 = 40; //")"
        public const int t_TOKEN_41 = 41; //";"
        public const int t_TOKEN_42 = 42; //","
    }
}