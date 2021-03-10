using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rg.ScriptingLanguage
{
    class VariableStack
    {
        record Frame(Dictionary<string, object> Variables, bool Temporary = false);
        readonly List<Frame> stack = new() { new(new()) };

        record DisposableRemoveFrame(VariableStack Stack) : IDisposable
        {
            public void Dispose() => Stack.RemoveFrame();
        }

        public IDisposable AddNewFrame(bool temp = false)
        {
            stack.Add(new(new(), temp));
            return new DisposableRemoveFrame(this);
        }

        public void RemoveFrame() => stack.RemoveAt(stack.Count - 1);

        public object this[string name]
        {
            get
            {
                for (int idx = stack.Count - 1; idx >= 0; --idx)
                    if (stack[idx].Variables.TryGetValue(name, out var val))
                        return val;
                return stack.Last(s => !s.Temporary).Variables[name] = default;
            }
            set
            {
                for (int idx = stack.Count - 1; idx >= 0; --idx)
                    if (stack[idx].Variables.ContainsKey(name))
                        stack[idx].Variables[name] = value;
                stack.Last(s => !s.Temporary).Variables[name] = value;
            }
        }
    }
}
