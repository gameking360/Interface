using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Lexico
{
    public class SyntaticError : AnalysisError
    {
        private Token token;
        public SyntaticError(String msg, int position, Token token) : base(msg, position)
        {
           this.token = token;
        }

        public SyntaticError(String msg) : base(msg)
        {
            
        }

        public override string ToString()
        {
            Func<string,string> verToken = (string x) =>
            {
              if(x.Equals("$"))
                    return "EOF";
                else
                {
                    if(x.Length >= 2)
                    {
                        if (x[0].ToString() == "\"" && x[x.Length - 1].ToString() == "\"")
                            return "constante_string"; 

                    }
                    return x;
                }
                  

            };

            var token = this.token.getLexeme();
            return "encontrado " + (verToken(token)) + " " + base.ToString();
        }
    }
}
