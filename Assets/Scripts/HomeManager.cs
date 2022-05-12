using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeManager : Singleton<HomeManager>
{
    private void Awake()
    {
        CreateSingleton(true);
    }
}
