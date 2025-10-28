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
            var token = this.token.getLexeme();
            return "encontrado " + ((token == "$") ?"EOF": token) + " " + base.ToString();
        }
    }
}
