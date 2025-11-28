using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Interface.Lexico;

namespace Interface.Services
{
    public class CompiladorServices
    {


    

        public string GetClassePorExtenso(int id)
        {

            switch (id)
            {
                case Constants.t_identificador: return "Identificador";

                case Constants.t_cint: return "Constante Inteira"; 
                case Constants.t_cfloat: return "Constante Float";
                case Constants.t_cstring: return "Constante String";
                case Constants.t_pr_if: return "Palavra Reservada";
                case Constants.t_pr_else: return "Palavra Reservada ";
                case Constants.t_pr_add: return "Palavra Reservada";
                case Constants.t_pr_and: return "Palavra Reservada ";
                case Constants.t_pr_or: return "Palavra Reservada";
                case Constants.t_pr_not: return "Palavra Reservada";
                case Constants.t_pr_begin: return "Palavra Reservada";
                case Constants.t_pr_end: return "Palavra Reservada";
                case Constants.t_pr_bool: return "Palavra Reservada";
                case Constants.t_pr_count: return "Palavra Reservada";
                case Constants.t_pr_delete: return "Palavra Reservada";
                case Constants.t_pr_do: return "Palavra Reservada";
                case Constants.t_pr_elementOf: return "Palavra Reservada";
                case Constants.t_pr_false: return "Palavra Reservada";
                case Constants.t_pr_float: return "Palavra Reservada";
                    case Constants.t_pr_int: return "Palavra Reservada";
                    case Constants.t_pr_list: return "Palavra Reservada";
                    case Constants.t_pr_print: return "Palavra Reservada";
                    case Constants.t_pr_read: return "Palavra Reservada";
                    case Constants.t_pr_size: return "Palavra Reservada";
               case Constants.t_pr_string: return "Palavra Reservada";
               case Constants.t_pr_true: return "Palavra Reservada";
               case Constants.t_pr_until: return "Palavra Reservada";
                case Constants.t_TOKEN_29: return "Símbolo especial";
                    case Constants.t_TOKEN_30: return "Símbolo especial";
                    case Constants.t_TOKEN_32: return "Símbolo especial";
                    case Constants.t_TOKEN_31: return "Símbolo especial";
                    case Constants.t_TOKEN_33: return "Símbolo especial";
                    case Constants.t_TOKEN_34: return "Símbolo especial";
                    case Constants.t_TOKEN_35: return "Símbolo especial";
                    case Constants.t_TOKEN_36: return "Símbolo especial";
                    case Constants.t_TOKEN_37: return "Símbolo especial";
                    case Constants.t_TOKEN_38: return "Símbolo especial";
                case Constants.t_TOKEN_39: return "Símbolo especial";
                case Constants.t_TOKEN_40: return "Símbolo especial";
                case Constants.t_TOKEN_41: return "Símbolo especial";
                case Constants.t_TOKEN_42: return "Símbolo especial";


                default: return "Token " + id;
            }
        }


        public static int GetLinha(string texto, int position)
        {
            return 1 + texto.Substring(0, position > 0 ?  position : texto.Length).Count(c => c == '\n');
        }


        public static void CompilarESalvarArquivo() { 
        
            
         
        }
    }
}
