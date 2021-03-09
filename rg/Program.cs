using Loyc;
using Loyc.Syntax;
using rg.ScriptingLanguage;
using System;
using System.Collections.Generic;

namespace rg
{
    class Program
    {
        static readonly Dictionary<Symbol, Func<double, double, double>> ops = new()
        {
            [CodeSymbols.Add] = (x, y) => x + y,
            [CodeSymbols.Sub] = (x, y) => x - y,
            [CodeSymbols.Mul] = (x, y) => x * y,
            [CodeSymbols.Div] = (x, y) => x / y,
        };

        static void Main()
        {
            Dictionary<string, double> vars = new();
            double visit(LNode node)
            {
                if (node.IsLiteral) return (double)node.Value;
                if (node.IsId) return vars[node.Name.Name];
                if (node.IsCall)
                    if (node.Calls(CodeSymbols.Assign, 2))
                        return vars[node.Args[0].Name.Name] = visit(node.Args[1]);
                    else if (node.ArgCount == 2)
                        return ops[node.Name](visit(node.Args[0]), visit(node.Args[1]));
                throw new NotImplementedException();
            }

            Console.WriteLine(visit(MyParser.New("a = (1 + 2 / 4) * 2 + 1").Start()));
            Console.WriteLine(visit(MyParser.New("a / 3").Start()));
            Console.WriteLine(visit(MyParser.New("a = a - 1").Start()));
            Console.WriteLine(visit(MyParser.New("a / 3").Start()));
        }
    }
}
