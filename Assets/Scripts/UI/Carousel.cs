using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Carousel : MonoBehaviour
{
    public List<string> carouselSelection;
    public int indexSelection = 0;

    [Space(20)]

    public TextMeshProUGUI label;
    public Button leftButton;
    public Button rightButton;


    private void Awake()
    {
        label.text = carouselSelection[indexSelection];
        
        if(indexSelection == 0)
        {
            if(carouselSelection.Count > 1) {
                leftButton.interactable = false;
                rightButton.interactable = true;
            }
            else {
                leftButton.interactable = false;
                rightButton.interactable = false;
            }
        }
        else if(indexSelection == carouselSelection.Count - 1)
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }
        else
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }
    }

    public void OnLeftButtonClick()
    {
        if(indexSelection > 0)
        {
            indexSelection -= 1;
            label.text = carouselSelection[indexSelection];

            if(indexSelection == 0)
            {
                leftButton.interactable = false;
            }

            rightButton.interactable = true;
        }
    }

    public void OnRightButtonClick()
    {
        if (indexSelection < carouselSelection.Count - 1)
        {
            indexSelection += 1;
            label.text = carouselSelection[indexSelection];

            if (indexSelection == carouselSelection.Count - 1)
            {
                rightButton.interactable = false;
            }

            leftButton.interactable = true;
        }
    }

}
