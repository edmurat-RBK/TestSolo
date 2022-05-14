using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingIntSlider : MonoBehaviour
{
    public string settingName;
    public int minValue = 0;
    public int maxValue = 100;
    public int defaultValue = 100;
    
    [Space(20)]

    public TextMeshProUGUI textBox;
    public IntValueSlider valueSlider;

    private void Awake() {
        textBox.text = settingName;
        valueSlider.minValue = minValue;
        valueSlider.maxValue = maxValue;
        valueSlider.value = defaultValue;
    }
}
