using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Lexico
{
    public class Semantico : Constants
    {
        Stack<string> pilha = new Stack<string>();
        Stack<string> rotulos = new Stack<string>();
        List<string> identificadores = new List<string>();
        private StringBuilder code = new StringBuilder();

        private Dictionary<string, string> tabelaSimbolos = new Dictionary<string, string>();
        private string operadorRelacional;
        private string tipo;


        public void executeAction(int action, Token token)
        {

            switch (action)
            {
                case 100:
                    this.ExecuteInicio();
                    break;
                case 101:
                    this.ExecutaFim();
                    break;
                case 102:
                    this.ExecutaSaida(token);
                    break;
                case 103:
                    this.AdicionarIntAPilha(token);
                    break;
                case 104:
                    this.AdicionarFloatAPilha(token);
                    break;
                case 105:
                    this.AdicionarStringAPilha(token);
                    break;
                case 106:
                case 107:
                case 108:
                case 109:
                    this.Operacao(action);
                    break;
                case 110:

                    this.OperacaoUnario(token);
                    break;
                case 111:
                    this.GuardarOperadorRelacional(token);
                    break;
                case 112:
                    this.OperacaoRelacional(token);
                    break;
                case 113:
                case 114:
                    this.OperacaoLogica(token);
                    break;
                case 115:
                case 116:
                    this.AdicionarBoolAPilha(token);
                    break;
                case 117:
                    this.AcaoNot(token);
                    break;
                case 118:
                    this.AdicionarQuebraLinha(token);
                    break;
                case 119:
                    this.AdicionarVariavel(token);
                    break;
                case 120:
                    this.GuardarTipo(token);
                    break;
                case 121:
                    this.AdicionarIdentificador(token);
                    break;
                case 122:
                    this.DeclaracaoVariavel(token);
                    break;
                case 123:
                    this.InputToken(token);
                    break;
                case 124:
                    this.CarregarPalavra(token);
                    break;
                case 125:
                    this.DesvioFalse(token);
                    break;
                case 126:
                    this.RotuloFim(token);
                    break;
                case 127:
                    this.DesvioElse(token);
                    break;
                case 128:
                    this.NovoRotulo();
                    break;
                case 129:
                    this.PercorrerLoop(token);
                    break;
                case 130:
                    this.CarregarValor(token);
                    break;
                default:

                    break;
            }

        }


        private void ExecuteInicio()
        {
            this.code.AppendLine(@".assembly extern mscorlib {}
                       .assembly _programa{}
                       .module _programa.exe 
                       
                       .class public _unica{ 
                       .method static public void _principal(){
                       .entrypoint");


        }

        private void ExecutaFim()
        {
            this.code.AppendLine(@"ret
                                  }
                                  }");

           
        }

        private void AdicionarIntAPilha(Token token)
        {
            pilha.Push("int64");
            this.code.AppendLine("ldc.i8 " + token.getLexeme());
            this.code.AppendLine("conv.r8");
        }

        private void AdicionarFloatAPilha(Token token)
        {
            pilha.Push("float64");
            this.code.AppendLine("ldc.r8 " + token.getLexeme());

        }

        private void AdicionarStringAPilha(Token token)
        {
            pilha.Push("string");
            this.code.AppendLine("ldstr " + token.getLexeme());
        }

        private void AdicionarBoolAPilha(Token token)
        {
            pilha.Push("bool");
            this.code.AppendLine("ldc.i4 " + (token.getLexeme() == "true" ? "1" : "0"));
        }

        private void OperacaoUnario(Token token)
        {

            var tipo = pilha.Pop();


         
                    if (tipo.Equals("float64"))
                        this.code.AppendLine("ldc.i8 -1.0");

                    else
                        this.code.AppendLine("ldc.i8 -1");

                    this.code.AppendLine("mul");
                    pilha.Push(tipo);
              
            
        }

        private void Operacao(int action)
        {
            var tipo1 = pilha.Pop();
            var tipo2 = pilha.Pop();

            int ix = 3 ^ 2;

            if (tipo1.Equals("float64") || tipo2.Equals("float64") || action == 109)
            {
                pilha.Push("float64");

            }
            else
            {
                pilha.Push("int64");
            }

            switch (action)
            {
                case 106:
                    this.code.AppendLine("add");
                    break;
                case 107:
                    this.code.AppendLine("sub");
                    break;
                case 108:
                    this.code.AppendLine("mul");
                    break;
                case 109:
                    this.code.AppendLine("div");
                    break;
                default:
                    break;
            }

        }
        private void GuardarOperadorRelacional(Token token)
        {
            this.operadorRelacional = token.getLexeme();
        }

        private void OperacaoRelacional(Token token)
        {
            var tipo1 = pilha.Pop();
            var tipo2 = pilha.Pop();
            string operacao = this.operadorRelacional;
            pilha.Push("bool");
            switch (operacao)
            {
                case "==":
                    this.code.AppendLine("ceq");
                    break;
                case "~=":
                    this.code.AppendLine("ceq");
                    this.code.AppendLine("ldc.i4 0");
                    this.code.AppendLine("ceq");
                    break;
                case "<":
                    this.code.AppendLine("clt");
                    break;
                case ">":
                    this.code.AppendLine("cgt");
                    break;
                default:
                    break;
            }
        }

        private void AcaoNot(Token token)
        {
            var tipo = pilha.Pop();
            pilha.Push("bool");
            this.code.AppendLine("ldc.i4 0");
            this.code.AppendLine("xor");

        }

        private void ExecutaSaida(Token token)
        {
            var tipo = this.pilha.Pop();

            if (tipo.Equals("int64")) this.code.AppendLine("conv.i8");

            this.code.AppendLine("call void [mscorlib]System.Console::Write(<tipo>)".Replace("<tipo>", tipo));
        }

        private void AdicionarQuebraLinha(Token token)
        {
            this.code.AppendLine("call void [mscorlib]System.Console::WriteLine()");
        }

        private void OperacaoLogica(Token token)
        {
            var tipo1 = pilha.Pop();
            var tipo2 = pilha.Pop();
            string operacao = token.getLexeme();
            pilha.Push("bool");
            switch (operacao)
            {
                case "and":
                    this.code.AppendLine("and");
                    break;
                case "or":
                    this.code.AppendLine("or");
                    break;
                default:
                    break;
            }
        }

        private void GuardarTipo(Token token)
        {
            this.tipo = token.getLexeme();
        }

        private void AdicionarIdentificador(Token token)
        {
            identificadores.Add(token.getLexeme());
        }

        private void AdicionarVariavel(Token token)
        {
            Func<string, string> mapTipo = (string tipo) =>
            {
                switch (tipo)
                {
                    case "int":
                        return "int64";
                    case "float":
                        return "float64";
                    case "string":
                        return "string";
                    case "bool":
                        return "bool";
                    default:
                        throw new Exception("Erro");
                }
            };
            this.code.Append(".locals init ( ");
            foreach (var id in identificadores)
            {
                var tipoSimbolo = mapTipo(this.tipo);
                this.tabelaSimbolos.Add(id, tipoSimbolo);
                if (id == identificadores.Last())
                    this.code.Append(tipoSimbolo + " " + id + " ");
                else
                    this.code.Append(tipoSimbolo + " " + id + ", ");
            }
            this.code.AppendLine(")");
            identificadores.Clear();
        }


        private void CarregarValor(Token token)
        {
            var id = token.getLexeme();
            var tipo = this.tabelaSimbolos[id];
            this.pilha.Push(tipo);
            this.code.AppendLine("ldloc " + id);
            if (tipo.Equals("int64")) this.code.AppendLine("conv.r8");



        }
        private void DeclaracaoVariavel(Token token)
        {
            var tipo = pilha.Pop();

            if (tipo.Equals("int64")) this.code.AppendLine("conv.i8");
            var id = identificadores.First();
            this.code.AppendLine("stloc " + id);
            identificadores.RemoveAt(0);
        }

        private void InputToken(Token token)
        {
            var id = token.getLexeme();
            if (tabelaSimbolos.ContainsKey(id) && tabelaSimbolos[id].Equals("bool")) throw new SyntaticError(id + " inválido para comando de entrada");

            this.code.AppendLine("call string [mscorlib]System.Console::ReadLine()");
            if (tabelaSimbolos[id].Equals("int64"))
            {
                this.code.AppendLine("call int32 [mscorlib]System.Int32::Parse(string)");
                this.code.AppendLine("conv.i8");
            }
            else if (tabelaSimbolos[id].Equals("float64"))
            {
                this.code.AppendLine("call float64 [mscorlib]System.Double::Parse(string)");
            }
            else if (tabelaSimbolos[id].Equals("bool"))
            {
                this.code.AppendLine("call bool [mscorlib]System.Boolean::Parse(string)");
            }
            this.code.AppendLine("stloc " + id);
        }


        private void CarregarPalavra(Token token)
        {

            var palavra = token.getLexeme();

            this.code.AppendLine("ldstr " + palavra);
            this.code.AppendLine("call void [mscorlib]System.Console::Write(string)");
        }


        private void DesvioFalse(Token token)
        {
            var tipo = this.pilha.Pop();
            if (!tipo.Equals("bool")) throw new SemanticError("expressão incompátivel em comando de seleção",token.getPosition());

            var novoRotulo = "novoRotulo" + InserirRotulo();
            this.code.AppendLine("brfalse " + novoRotulo);
            this.rotulos.Push(novoRotulo);
        }

        private void DesvioElse(Token token)
        {
            var rotuloFim = "fimRotulo" + InserirRotulo();
            var rotuloElse = this.rotulos.Pop();
            this.code.AppendLine("br " + rotuloFim);
            this.code.AppendLine(rotuloElse + ":");
            this.rotulos.Push(rotuloFim);
        }

        private void RotuloFim(Token token)
        {
            var rotuloFim = this.rotulos.Pop();
            this.code.AppendLine(rotuloFim + ":");
        }

        private void NovoRotulo()
        {
            var novoRotulo = "novoRotulo" + InserirRotulo();
            this.code.AppendLine(novoRotulo + ":");
            this.rotulos.Push(novoRotulo);
        }

        private string InserirRotulo()
        {
            if (this.rotulos.Count == 0) return "1";
            else return this.rotulos.Count() + 1 + "";
        }

        private void PercorrerLoop(Token token)
        {
            var tipo = this.pilha.Pop();
            if (!tipo.Equals("bool")) throw new SemanticError("expressão incompátivel em comando de repetição",token.getPosition());

            var rotuloInicio = this.rotulos.Pop();
            this.code.AppendLine("brfalse " + rotuloInicio);
        }

        public string getConteudo()
        {
            return this.code.ToString();
        }
    }
}
