using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueSlider : MonoBehaviour
{
    public Slider slider;
    public TMP_InputField inputField;

    public void ActionSliderChanged()
    {
        inputField.text = "" + slider.value;
    }

    public void ActionInputChanged()
    {
        slider.value = int.Parse(inputField.text);
    }

}
