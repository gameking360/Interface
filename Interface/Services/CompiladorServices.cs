using System;
using System.Collections.Generic;
using System.Linq;
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
                case Constants.t_pr_if: return "Palavra Reservada 'if'";
                case Constants.t_pr_else: return "Palavra Reservada 'else'";
                default: return "Token " + id;
            }
        }

    }
}
