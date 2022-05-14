using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingHeader : MonoBehaviour
{
    public string headerName;
    
    [Space(20)]

    public TextMeshProUGUI textBox;

    private void Awake() {
        textBox.text = headerName;
    }
}
