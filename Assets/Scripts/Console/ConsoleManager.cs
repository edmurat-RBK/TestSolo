using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Seance.Console
{
    public enum LogLevel
    {
        TRACE,
        LOG,
        SUCCESS,
        INFO,
        WARN,
        ERROR
    }

    /// <summary>
    /// Edouard
    /// </summary>
    public class ConsoleManager : Singleton<ConsoleManager>
    {
        #region Variables
        public GameObject _consoleObject;
        public GameObject _lineObject;

        private GameObject Console { get; set; }
        private GameObject HistoryBox { get; set; }
        private InputField InputBox { get; set; }
        private GameObject LinePrefab { get; set; }

        private Color TraceColor { get; set; }
        private Color LogColor { get; set; }
        private Color SuccessColor { get; set; }
        private Color InfoColor { get; set; }
        private Color WarnColor { get; set; }
        private Color ErrorColor { get; set; }

        public bool ShowConsole { get; set; }
        private int ScrollIndex { get; set; }
        private List<string> CommandHistory { get; set; }
        private List<GameObject> LineObjectList { get; set; }
        
        public List<object> commandList;
        #endregion

        public static ConsoleCommand HELLO;
        public static ConsoleCommand HELP;
        public static ConsoleCommand<string,float,float,float> CAMERA;
        // Declare new command here...
        /*
        public static ConsoleCommand<T1,T2...> COMMAND;
        */

        #region Inputs

        public void OnOpenConsole(InputValue value)
        {
            if(!ShowConsole)
            {
                ShowConsole = true;
                Console.SetActive(true);
                InputBox.ActivateInputField();
            }
        }

        public void OnCloseConsole(InputValue value)
        {
            if(ShowConsole)
            {
                ShowConsole = false;
                Console.SetActive(false);
            }
        }

        public void OnSendCommand(InputValue value)
        {
            if(ShowConsole && !InputBox.text.Equals(""))
            {
                HandleInput();
                CommandHistory.Add(InputBox.text);
                ScrollIndex = CommandHistory.Count;
                InputBox.text = "";
                InputBox.ActivateInputField();
            }
            else if(ShowConsole && InputBox.text.Equals(""))
            {
                InputBox.ActivateInputField();
            }
        }

        public void OnScrollCommand(InputValue value)
        {
            ScrollIndex = Mathf.Clamp(ScrollIndex + (int)value.Get<float>(), 0, CommandHistory.Count - 1);
            InputBox.text = CommandHistory[ScrollIndex];
            InputBox.MoveTextEnd(true);
        }

        #endregion

        private void Awake()
        {
            CreateSingleton(true);

            TraceColor = new Color(0.5f, 0.5f, 0.5f);
            LogColor = new Color(0.5f, 0.5f, 1f);
            SuccessColor = new Color(0f, 0.5f, 0f);
            InfoColor = new Color(1f, 1f, 1f);
            WarnColor = new Color(1f, 0.75f, 0f);
            ErrorColor = new Color(1f, 0f, 0f);

            CommandHistory = new List<string>() { "" };
            ScrollIndex = 0;
            LineObjectList = new List<GameObject>();

            HELLO = new ConsoleCommand("hello", "Say 'Hello !'", "hello", () =>
            {
                CommandHello();
            });
            HELP = new ConsoleCommand("help", "Show command list in console", "help", () =>
            {
                CommandHelp();
            });
            CAMERA = new ConsoleCommand<string, float, float, float>("camera", "Modify camera position or rotation", "camera <pos|rot> <x> <y> <z>", (a,x,y,z) =>
            {
                CommandCamera(a,x,y,z);
            });
            // Set new command actions here...
            /*
            COMMAND = new ConsoleCommand<T1,T2...>("command", "Here is a short description", "command <syntax>", (t1,t2...) =>
            {
                CommandMethod(t1,t2...);
            });
            */

            commandList = new List<object>
            {
                HELLO,
                HELP,
                CAMERA
                // Add new command to this list
            };
        }

        private void Start()
        {
            Console = _consoleObject.transform.GetChild(0).gameObject;
            HistoryBox = Console.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            InputBox = Console.transform.GetChild(1).GetComponent<InputField>();
            LinePrefab = _lineObject;

            Console.SetActive(false);
        }

        public void Print(LogLevel level, string message)
        {
            var _inst = Instantiate(LinePrefab, HistoryBox.transform);
            _inst.GetComponent<Text>().text = message;
            switch(level)
            {
                case LogLevel.TRACE: _inst.GetComponent<Text>().color = TraceColor; break;
                case LogLevel.LOG: _inst.GetComponent<Text>().color = LogColor; break;
                case LogLevel.INFO: _inst.GetComponent<Text>().color = InfoColor; break;
                case LogLevel.SUCCESS: _inst.GetComponent<Text>().color = SuccessColor; break;
                case LogLevel.WARN: _inst.GetComponent<Text>().color = WarnColor; break;
                case LogLevel.ERROR: _inst.GetComponent<Text>().color = ErrorColor; break;
            }
            LineObjectList.Add(_inst);
        }

        private void HandleInput()
        {
            string[] args = InputBox.text.Split(' ');
            for(int i=0; i<commandList.Count; i++)
            {
                ConsoleBaseCommand commandBase = commandList[i] as ConsoleBaseCommand;
                if(args[0].Equals(commandBase.CommandId))
                {
                    if(commandList[i] as ConsoleCommand != null)
                    {
                        (commandList[i] as ConsoleCommand).Invoke();
                    }
                    else if(commandList[i] as ConsoleCommand<string,float,float,float> != null)
                    {
                        try
                        {
                            (commandList[i] as ConsoleCommand<string, float, float, float>).Invoke(args[1], float.Parse(args[2], CultureInfo.InvariantCulture), float.Parse(args[3], CultureInfo.InvariantCulture), float.Parse(args[4], CultureInfo.InvariantCulture));
                        }
                        catch
                        {
                            Print(LogLevel.ERROR, "An error has occured while executing the command");
                        }
                    }
                    // Add new command condition if dont exist yet, shitty part...
                    /*
                    else if(commandList[i] as ConsoleCommand<T1,T2...> != null)
                    {
                        try
                        {
                            (commandList[i] as ConsoleCommand<T1,T2...>).Invoke(T1.Parse(args[1]), T2.Parse(args[1])...);
                        }
                        catch
                        {
                            Print(LogLevel.ERROR, "An error has occured while executing the command");
                        }
                    }
                    */
                }
            }
        }

        #region Commands methods

        private void CommandHello()
        {
            Print(LogLevel.INFO, "Hello !");
        }

        private void CommandHelp()
        {
            string strOutput = "---------- HELP ----------\n";
            foreach(ConsoleBaseCommand cmd in commandList)
            {
                strOutput +=
                    $"{cmd.CommandId} :\n" +
                    $"Format : {cmd.CommandFomat}\n" +
                    $"{cmd.CommandDescription}\n\n";
            }
            Print(LogLevel.LOG, strOutput);
        }

        private void CommandCamera(string a, float x, float y, float z)
        {
            GameObject goCamera = GameObject.FindGameObjectWithTag("MainCamera");
            Vector3 initPosition = goCamera.transform.position;
            Vector3 initRotation = goCamera.transform.eulerAngles;
            string strOutput = "";

            if (a.Equals("pos"))
            {
                goCamera.transform.position = new Vector3(x, y, z);
                strOutput = $"Move camera to position ({x}, {y}, {z}).\nLast position: ({initPosition.x}, {initPosition.y}, {initPosition.z})";
                Print(LogLevel.TRACE, strOutput);
            }
            else if(a.Equals("rot"))
            {
                goCamera.transform.eulerAngles = new Vector3(x, y, z);
                strOutput = $"Rotate camera to angle ({x}, {y}, {z}).\nLast rotation: ({initRotation.x}, {initRotation.y}, {initRotation.z})";
                Print(LogLevel.TRACE, strOutput);
            }
            else
            {
                strOutput = $"Argument 1 ({a}) caused an error during command interpretation.\nUse 'pos' or 'rot' instead";
                Print(LogLevel.ERROR, strOutput);
            }
        }

        // Create new command method here...
        /*
        private void CommandMethod(T1 arg1, T2 arg1...) {
            // Put command behaviour here...
        }
        */

        #endregion
    }

}