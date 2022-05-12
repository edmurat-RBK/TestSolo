// This script is only an exemple to show save system.
// Save system works in 3 layers.
// 1- ISaveable will make components saveable with implementation of CaptureState() and RestoreState()
// 2- SaveableObject is a component you have to put on GameObject with ISaveable componants. Don't forget to give it a GUID (Right click on SaveableObject component and select 'Generate ID')
// 3- SaveManager will read/write files and read/write state of SaveableObjects with values given via ISaveable.

// Call 'SaveManager.Instance.Save()' to make a save.
// Call 'SaveManager.Instance.Load()' to load a save

// If you have any question, ask to Edouard


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To use save system, you will have to import Seance.SaveManagement with 'using' statement.
using Seance.SaveManagement;

namespace Seance.SaveManagement
{
    // SaveExemple is a component that contains some values I want to save.
    // Use interface ISaveable on scripts containing values you want to save, as shown below.
    public class SaveExemple : MonoBehaviour, ISaveable
    {
        // Let's say I want save those 4 variables
        public int hp;
        public int maxHp;
        public int xpLevel;
        public int xpPoint;



        // --------------------

        // Componant code here

        // void Awake()...
        // void Start()...
        // void Update()...
        // void WhatYouWant()...

        // --------------------



        // I made a struct in my class that will contains my 4 values
        // Don't forget to add [Serializable] attribute
        [Serializable]
        public struct SaveData
        {
            public int hp;
            public int maxHp;
            public int xpLevel;
            public int xpPoint;
        }

        // The method CaptureState() is implemented by ISaveable
        // It should return a new SaveData with my 4 value inside
        public object CaptureState()
        {
            return new SaveData
            {
                hp = hp,
                maxHp = maxHp,
                xpLevel = xpLevel,
                xpPoint = xpPoint
            };
        }

        // The method RestoreState() is implemented by ISaveable
        // It should set the 4 values from the given parameter 'state' (in this case, my SaveData object)
        public void RestoreState(object state)
        {
            SaveData data = (SaveData)state;
            
            hp = data.hp;
            maxHp = data.maxHp;
            xpLevel = data.xpLevel;
            xpPoint = data.xpPoint;

        }
    }
}
