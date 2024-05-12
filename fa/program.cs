using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;

    public void AddTransition(char symbol, State state)
        {
            Transitions[symbol] = state;
        }
  }


  public class FA1
  {
     public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public static State d = new State()
        {
            Name = "d",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State e = new State()
        {
            Name = "e",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = a;

        public FA1()
        {
            InitialState.AddTransition('0',b);
            InitialState.AddTransition('1',e);
            b.AddTransition('0',d);
            b.AddTransition('1',c);
            c.AddTransition('0',d);
            c.AddTransition('1',c);
            d.AddTransition('0', d);
            d.AddTransition('1', d);
            e.AddTransition('0', c);
            e.AddTransition('1', e);
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
  }

  public class FA2
  {
    private State initialState;
    public static State a = new State()
            {
               Name = "a",
               IsAcceptState = false,
               Transitions = new Dictionary<char, State>()
            };
            public static State b = new State()
            {
                Name = "b",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            public static State c = new State()
            {
                Name = "c",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };
            public static State d = new State()
            {
                Name = "d",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };

            State InitialState = a;
            public FA2()
            {
                InitialState.AddTransition('0', d);
                InitialState.AddTransition('1', b);
                b.AddTransition('0', c);
                b.AddTransition('1', initialState);
                c.AddTransition('0', b);
                c.AddTransition('1', d);
                d.AddTransition('0', a);
                d.AddTransition('1', c);
            }

    public bool? Run(IEnumerable<char> s)
            {
                State current = InitialState;
                foreach (var c in s)
                {
                    current = current.Transitions[c];
                    if (current == null)
                        return null;
                }
                return current.IsAcceptState;
            }
    
  }
  
  public class FA3
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
