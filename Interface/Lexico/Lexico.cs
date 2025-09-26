using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Interface.Lexico;
using static System.Windows.Forms.AxHost;

namespace Interface.Lexico
{
    public class Lexico : Constants
    {
        private int position;
        private string input;

        public Lexico()
        {
            new Lexico("");
        }

        public Lexico(string input)
        {
            setInput(input);
        }

        public void setInput(string input)
        {
            this.input = input;
            setPosition(0);
        }

        public void setPosition(int pos)
        {
            position = pos;
        }

        public Token nextToken()
        {
            if (!hasInput())
                return null;

            // Ignorar comentários de linha
            if (input.Length - position >= 2 && input[position] == '/' && input[position + 1] == '/')
            {
                int idx = input.IndexOf('\n', position);
                if (idx == -1)
                {
                    position = input.Length;
                }
                else
                {
                    position = idx + 1;
                }
                return nextToken();
            }
            // Ignorar comentários de bloco com { }
            if (input.Length - position >= 1 && input[position] == '{')
            {
                int idx = input.IndexOf('}', position + 1);
                if (idx == -1)
                {
                    // Se não encontrar o fechamento, ignora até o final
                    position = input.Length;
                }
                else
                {
                    position = idx + 1;
                }
                return nextToken();
            }
            // Ignorar bloco de comentário aberto anteriormente
            int blocoInicio = input.IndexOf('{', position);
            int blocoFim = input.IndexOf('}', position);
            if (blocoInicio != -1 && blocoInicio < blocoFim && position >= blocoInicio && position < blocoFim)
            {
                position = blocoFim + 1;
                return nextToken();
            }

            int start = position;
            int state = 0;
            int lastState = 0;
            int endState = -1;
            int end = -1;

            while (hasInput())
            {
                lastState = state;
                state = nextState(nextChar(), state);

                if (state < 0)
                    break;
                else
                {
                    if (tokenForState(state) >= 0)
                    {
                        endState = state;
                        end = position;
                    }
                }
            }
            if (endState < 0 || (endState != state && tokenForState(lastState) == -2))
                throw new LexicalError(SCANNER_ERROR[lastState], start);

            position = end;

            int token = tokenForState(endState);

            if (token == 0)
                return nextToken();
            else
            {
                // Protege contra índices inválidos
                if (start < 0 || end > input.Length || end < start)
                    return null;
                string lexeme = input.Substring(start, end - start);
                token = lookupToken(token, lexeme);
                return new Token(token, lexeme, start);
            }
        }

        private int nextState(char? c, int state)
        {
            int start = SCANNER_TABLE_INDEXES[state];
            int end = SCANNER_TABLE_INDEXES[state + 1] - 1;

            while (start <= end)
            {
                int half = (start + end) / 2;

                if (SCANNER_TABLE[half, 0] == c)
                    return SCANNER_TABLE[half, 1];
                else if (SCANNER_TABLE[half, 0] < c)
                    start = half + 1;
                else  //(SCANNER_TABLE[half][0] > c)
                    end = half - 1;
            }

            return -1;
        }

        private int tokenForState(int state)
        {
            if (state < 0 || state >= TOKEN_STATE.Length)
                return -1;

            return TOKEN_STATE[state];
        }

        public int lookupToken(int floor, string key)
        {
            int start = SPECIAL_CASES_INDEXES[floor];
            int end = SPECIAL_CASES_INDEXES[floor + 1] - 1;

            while (start <= end)
            {
                int half = (start + end) / 2;
                int comp = SPECIAL_CASES_KEYS[half].CompareTo(key);

                if (comp == 0)
                    return SPECIAL_CASES_VALUES[half];
                else if (comp < 0)
                    start = half + 1;
                else  //(comp > 0)
                    end = half - 1;
            }

            return floor;
        }

        private bool hasInput()
        {
            return position < input.Length;
        }

        private char? nextChar()
        {
            if (hasInput())
                return input[position++];
            else
                return null;
        }
    }
}
