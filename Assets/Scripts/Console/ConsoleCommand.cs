using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seance.Console
{

    public class ConsoleBaseCommand
    {
        public string CommandId { get; set; }
        public string CommandDescription { get; set; }
        public string CommandFomat { get; set; }

        public ConsoleBaseCommand(string id, string description, string format)
        {
            CommandId = id;
            CommandDescription = description;
            CommandFomat = format;
        }

    }



    public class ConsoleCommand : ConsoleBaseCommand
    {
        private Action command;

        public ConsoleCommand(string id, string description, string format, Action command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke()
        {
            command.Invoke();
        }
    }



    public class ConsoleCommand<T1> : ConsoleBaseCommand
    {
        private Action<T1> command;

        public ConsoleCommand(string id, string description, string format, Action<T1> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1)
        {
            command.Invoke(value1);
        }
    }



    public class ConsoleCommand<T1, T2> : ConsoleBaseCommand
    {
        private Action<T1, T2> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2)
        {
            command.Invoke(value1, value2);
        }
    }



    public class ConsoleCommand<T1, T2, T3> : ConsoleBaseCommand
    {
        private Action<T1, T2, T3> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2, T3> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2, T3 value3)
        {
            command.Invoke(value1, value2, value3);
        }
    }



    public class ConsoleCommand<T1, T2, T3, T4> : ConsoleBaseCommand
    {
        private Action<T1, T2, T3, T4> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2, T3, T4> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            command.Invoke(value1, value2, value3, value4);
        }
    }



    public class ConsoleCommand<T1, T2, T3, T4, T5> : ConsoleBaseCommand
    {
        private Action<T1, T2, T3, T4, T5> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2, T3, T4, T5> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            command.Invoke(value1, value2, value3, value4, value5);
        }
    }



    public class ConsoleCommand<T1, T2, T3, T4, T5, T6> : ConsoleBaseCommand
    {
        private Action<T1, T2, T3, T4, T5, T6> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2, T3, T4, T5, T6> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
            command.Invoke(value1, value2, value3, value4, value5, value6);
        }
    }



    public class ConsoleCommand<T1, T2, T3, T4, T5, T6, T7> : ConsoleBaseCommand
    {
        private Action<T1, T2, T3, T4, T5, T6, T7> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2, T3, T4, T5, T6, T7> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
        {
            command.Invoke(value1, value2, value3, value4, value5, value6, value7);
        }
    }



    public class ConsoleCommand<T1, T2, T3, T4, T5, T6, T7, T8> : ConsoleBaseCommand
    {
        private Action<T1, T2, T3, T4, T5, T6, T7, T8> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2, T3, T4, T5, T6, T7, T8> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
        {
            command.Invoke(value1, value2, value3, value4, value5, value6, value7, value8);
        }
    }



    public class ConsoleCommand<T1, T2, T3, T4, T5, T6, T7, T8, T9> : ConsoleBaseCommand
    {
        private Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9)
        {
            command.Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9);
        }
    }



    public class ConsoleCommand<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ConsoleBaseCommand
    {
        private Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> command;

        public ConsoleCommand(string id, string description, string format, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10)
        {
            command.Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10);
        }
    }

}