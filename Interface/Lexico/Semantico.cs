using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Lexico
{
    public class Semantico: Constants
    {
        public void executeAction(int action, Token token)
        {
            Console.WriteLine("Ação #" + action + ", Token: " + token);
        }

    }
}
