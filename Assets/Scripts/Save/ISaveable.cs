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
    public interface ISaveable
    {
        object CaptureState();

        void RestoreState(object state);
    }
}
