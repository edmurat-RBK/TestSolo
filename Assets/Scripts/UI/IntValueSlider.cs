using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntValueSlider : MonoBehaviour
{
    public int minValue;
    public int maxValue;
    public int value;

    [Space(20)]

    public Slider slider;
    public TMP_InputField inputField;

    private void Awake() {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = value;
        slider.wholeNumbers = true;
        inputField.text = "" + value;
    }

    public void ActionSliderChanged()
    {
        inputField.text = "" + slider.value;
    }

    public void ActionInputChanged()
    {
        slider.value = int.Parse(inputField.text);
    }

}
