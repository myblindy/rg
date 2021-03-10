using Loyc;
using Loyc.Syntax;
using rg.ScriptingLanguage;
using System;
using System.Linq;
using System.Collections.Generic;
using Loyc.Collections;

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
            VariableStack vars = new();
            object visit(LNode node)
            {
                if (node.Name == CodeSymbols.Braces)
                {
                    object ret = default;
                    node.Args.ForEach(n => ret = visit(n));
                    return ret;
                }
                if (node.IsLiteral) return (double)node.Value;
                if (node.IsId) return vars[node.Name.Name];
                if (node.IsCall)
                    if (node.Calls(ExtraCodeSymbols.PrintSymbol))
                    {
                        node.Args.ForEach(w => writeln(visit(w)));

                        // TODO void
                        return null;
                    }
                    else if (node.Calls(CodeSymbols.ForEach, 3))
                    {
                        using (vars.AddNewFrame(temp: true))
                            foreach (var element in (List<object>)visit(node.Args[1]))
                            {
                                vars[node.Args[0].Name.Name] = element;
                                visit(node.Args[2]);
                            }

                        // TODO void
                        return null;
                    }
                    else if (node.Calls(CodeSymbols.Assign, 2))
                        if (node.Args[0].Name == CodeSymbols.IndexBracks)
                            return ((List<object>)visit(node.Args[0].Args[0].Args[0]))[(int)(double)visit(node.Args[0].Args[0].Args[1])] = visit(node.Args[1]);
                        else
                            return vars[node.Args[0].Name.Name] = visit(node.Args[1]);
                    else if (node.Name == CodeSymbols.AltList)
                        return node.Args.Select(n => visit(n)).ToList();
                    else if (node.Name == CodeSymbols.IndexBracks)
                        return ((List<object>)visit(node.Args[0].Args[0]))[(int)(double)visit(node.Args[0].Args[1])];
                    else if (node.ArgCount == 2)
                        return ops[node.Name]((double)visit(node.Args[0]), (double)visit(node.Args[1]));
                throw new NotImplementedException();
            }

            static void write(object obj)
            {
                if (obj is double d)
                    Console.Write(d);
                else if (obj is List<object> lst)
                {
                    Console.Write("[");
                    bool first = true;
                    foreach (var item in lst)
                    {
                        if (first) first = false; else Console.Write(", ");
                        write(item);
                    }
                    Console.Write("]");
                }
                else if (obj is null)
                    Console.Write("<NULL>");
                else
                    throw new NotImplementedException();
            }
            void writeln(object obj) { write(obj); Console.WriteLine(); }

            writeln(visit(MyParser.New("arf=10;marf=20;arf;").Start()));
            writeln(visit(MyParser.New("x=[10];").Start()));
            writeln(visit(MyParser.New("z=[3];").Start()));
            writeln(visit(MyParser.New("x=[10, 30];").Start()));
            writeln(visit(MyParser.New("for(e: x) { print(e); v = e; } v;").Start()));
            writeln(visit(MyParser.New("x;").Start()));
            writeln(visit(MyParser.New("y=[x, 510, 520, 530];").Start()));
            writeln(visit(MyParser.New("x[0];").Start()));
            writeln(visit(MyParser.New("x[1];").Start()));
            writeln(visit(MyParser.New("y[0];").Start()));
            writeln(visit(MyParser.New("y[1];").Start()));
            writeln(visit(MyParser.New("y[2];").Start()));
            writeln(visit(MyParser.New("y[0][0];").Start()));
            writeln(visit(MyParser.New("y[0][z[2*0.5-1]-2];").Start()));
            writeln(visit(MyParser.New("a = (1 + 2 / 4) * 2 + 1;").Start()));
            writeln(visit(MyParser.New("a / 3;").Start()));
            writeln(visit(MyParser.New("a = a - 1;").Start()));
            writeln(visit(MyParser.New("a / 3;").Start()));
            writeln(visit(MyParser.New("y[2] = 999;").Start()));
            writeln(visit(MyParser.New("y[0][1] = 888;").Start()));
            writeln(visit(MyParser.New("y[0][0] = [];").Start()));
            writeln(visit(MyParser.New("y;").Start()));
        }
    }
}
