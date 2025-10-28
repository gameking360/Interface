using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Interface.Lexico;

namespace Interface.Lexico
{
    public class Sintatico : Constants
    {
        private Stack<int> stack = new Stack<int>();
        private Token currentToken;
        private Token previousToken;
        private Lexico scanner;
        private Semantico semanticAnalyser;

        private static bool isTerminal(int x)
        {
            return x < FIRST_NON_TERMINAL;
        }

        private static bool isNonTerminal(int x)
        {
            return x >= FIRST_NON_TERMINAL && x < FIRST_SEMANTIC_ACTION;
        }

        private static bool isSemanticAction(int x)
        {
            return x >= FIRST_SEMANTIC_ACTION;
        }

        private bool Step()
        {
            if (currentToken == null)
            {
                int pos = 0;
                if (previousToken != null)
                    pos = previousToken.getPosition() + previousToken.getLexeme().Length;

                currentToken = new Token(DOLLAR, "$", pos);
            }

            int x = stack.Pop();
            int a = currentToken.getId();

            if (x == EPSILON)
            {
                return false;
            }
            else if (isTerminal(x))
            {
                if (x == a)
                {
                    if (stack.Count == 0)
                        return true;
                    else
                    {
                        previousToken = currentToken;
                        currentToken = scanner.nextToken();
                        return false;
                    }
                }
                else
                {
                    throw new SyntaticError(PARSER_ERROR[x], currentToken.getPosition(),currentToken);
                }
            }
            else if (isNonTerminal(x))
            {
                if (PushProduction(x, a))
                    return false;
                else
                    throw new SyntaticError(PARSER_ERROR[x], currentToken.getPosition(),currentToken);
            }
            else // isSemanticAction(x)
            {
                semanticAnalyser.executeAction(x - FIRST_SEMANTIC_ACTION, previousToken);
                return false;
            }
        }

        private bool PushProduction(int topStack, int tokenInput)
        {
            int p = PARSER_TABLE[topStack - FIRST_NON_TERMINAL][tokenInput -1];
            if (p >= 0)
            {
                int[] production = PRODUCTIONS[p];
                // empilha a produção em ordem reversa
                for (int i = production.Length - 1; i >= 0; i--)
                {
                    stack.Push(production[i]);
                }
                return true;
            }
            else
                return false;
        }

        public void Parse(Lexico scanner, Semantico semanticAnalyser)
        {
            this.scanner = scanner;
            this.semanticAnalyser = semanticAnalyser;

            stack.Clear();
            stack.Push(DOLLAR);
            stack.Push(START_SYMBOL);

            currentToken = scanner.nextToken();

            while (!Step())
                ;
        }

    }
}
