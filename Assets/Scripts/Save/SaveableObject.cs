using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seance.SaveManagement
{
    /// <summary>
    /// Edouard
    /// 
    /// Check SaveExemple script for more details about save system
    /// </summary>
    public class SaveableObject : MonoBehaviour
    {
        [SerializeField] private string id = string.Empty;
        public string Id
        {
            get
            {
                return id;
            }
        }

        #region Unity events

        private void Awake()
        {
            if(id.Equals(string.Empty))
            {
                Debug.LogError($"[SaveableObject]: {gameObject.name} don't have GUID. Please assign one in Inspector (right-click on component, then 'Generate ID')");
            }
        }

        #endregion

        #region Public methods

        public object CaptureState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();

            foreach(ISaveable saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }

            return state;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> stateDict = (Dictionary<string, object>)state;

            foreach(ISaveable saveable in GetComponents<ISaveable>())
            {
                string typeName = saveable.GetType().ToString();
                if(stateDict.TryGetValue(typeName, out object value)) {
                    saveable.RestoreState(value);
                }
            }
        }

        #endregion

        #region Private methods

        [ContextMenu("Generate ID")]
        private void GenerateId()
        {
            id = Guid.NewGuid().ToString();
        }

        #endregion
    }
}
