using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Seance.SaveManagement
{
    /// <summary>
    /// Edouard
    /// Singleton & DontDestroyOnLoad
    /// 
    /// Check SaveExemple script for more details about save system
    /// </summary>
    public class SaveManager : Singleton<SaveManager>
    {
        private string savePath;
        public string SavePath
        {
            get
            {
                return savePath;
            }
        }

        public bool debug;


        #region Unity events

        private void Awake()
        {
            CreateSingleton(true);

            savePath = $"{Application.persistentDataPath}/save";

            Log($"Save path : {savePath}");
        }

        #endregion

        #region Public methods

        [ContextMenu("Save")]
        public void Save()
        {
            Dictionary<string, object> state = LoadFile();
            CaptureState(state);
            SaveFile(state);

            Log("State saved");
        }

        [ContextMenu("Load")]
        public void Load()
        {
            Dictionary<string, object> state = LoadFile();
            RestoreState(state);

            Log("State loaded");
        }

        #endregion

        #region Private methods

        // Open save file and write data in it
        private void SaveFile(object state)
        {
            using(FileStream stream = File.Open(SavePath,FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        // Open save file if it exists and read data in it
        // Returns data read as Dictionary<string,object>
        private Dictionary<string,object> LoadFile()
        {
            if(!File.Exists(SavePath))
            {
                return new Dictionary<string, object>();
            }

            using (FileStream stream = File.Open(SavePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Dictionary<string,object>)formatter.Deserialize(stream);
            }
        }

        // Go through all SaveableObject and associate object GUID with its data
        // Take a Dictionary<string,object> as parameter and fill it
        private void CaptureState(Dictionary<string,object> state)
        {
            foreach(SaveableObject saveable in FindObjectsOfType<SaveableObject>())
            {
                state[saveable.Id] = saveable.CaptureState();
            }
        }

        // Go through all SaveableObject and distribute data associated to its GUID
        private void RestoreState(Dictionary<string,object> state)
        {
            foreach(SaveableObject saveable in FindObjectsOfType<SaveableObject>())
            {
                if(state.TryGetValue(saveable.Id,out object value))
                {
                    saveable.RestoreState(value);
                }
            }
        }

        #region Debug methods

        private void Log(string _msg)
        {
            if (!debug) return;
            Debug.Log("[SaveManager]: " + _msg);
        }

        private void LogWarning(string _msg)
        {
            if (!debug) return;
            Debug.LogWarning("[SaveManager]: " + _msg);
        }

        #endregion

        #endregion

    }
}
