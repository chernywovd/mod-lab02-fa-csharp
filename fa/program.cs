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
     // Игорь Чернышов. Создание объектов состояний
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
        // Начальное состояние
        State InitialState = a;

        public FA1()
        {
            // Создание переходов между состояниями
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

        // Запуск автомата на заданной строке и возврат результата
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                // Переход в следующее состояние по текущему символу
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
           
            return current.IsAcceptState;
        }
  }


  public class FA2
{
    // Состояния автомата
    public static State a = new State()
    {
        // Название состояния
        Name = "a",
        
        IsAcceptState = false,
        // Переходы из состояния
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

    // Начальное состояние автомата
    State InitialState = a;

    // Конструктор класса
    public FA2()
    {
        // Добавление переходов из начального состояния
        InitialState.AddTransition('0', d);
        InitialState.AddTransition('1', b);
        // Добавление переходов из состояния b
        b.AddTransition('0', c);
        b.AddTransition('1', InitialState);
        // Добавление переходов из состояния c
        c.AddTransition('0', b);
        c.AddTransition('1', d);
        // Добавление переходов из состояния d
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
    //Определяем состояние "a" как новое состояние.
    public static State a = new State()
    {
        //Устанавливаем имя состояния как "a".
        Name = "a",
        //Устанавливаем свойство IsAcceptState как false
        IsAcceptState = false,
        //Инициализируем словарь переходов пустым словарем.
        Transitions = new Dictionary<char, State>()
    };
    
    //Определяем состояние "b" как новое состояние.
    public static State b = new State()
    {
        //Устанавливаем имя состояния как "b".
        Name = "b",
        //Устанавливаем свойство IsAcceptState как false
        IsAcceptState = false,
        //Инициализируем словарь переходов пустым словарем.
        Transitions = new Dictionary<char, State>()
    };
    
    //Определяем состояние "c" как новое состояние.
    public static State c = new State()
    {
        //Устанавливаем имя состояния как "c".
        Name = "c",
        //Устанавливаем свойство IsAcceptState как true
        IsAcceptState = true,
        //Инициализируем словарь переходов пустым словарем.
        Transitions = new Dictionary<char, State>()
    };
    
    //Определяем начальное состояние как "a".
    State InitialState = a;
    
    //Конструктор класса FA3.
    public FA3()
    {
        //Добавляем переход из начального состояния "a" в начальное состояние "a" по символу '0'.
        InitialState.AddTransition('0', InitialState);
        //Добавляем переход из начального состояния "a" в состояние "b" по символу '1'.
        InitialState.AddTransition('1', b);
        //Добавляем переход из состояния "b" в начальное состояние "a" по символу '0'.
        b.AddTransition('0', InitialState);
        //Добавляем переход из состояния "b" в состояние "c" по символу '1'.
        b.AddTransition('1', c);
        //Добавляем переход из состояния "c" в состояние "c" по символу '0'.
        c.AddTransition('0', c);
        //Добавляем переход из состояния "c" в состояние "c" по символу '1'.
        c.AddTransition('1', c);
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
