using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Carousel : MonoBehaviour
{
    public List<string> carouselSelection;
    public bool isActive = true;
    public int defaultIndexSelection = 0;

    public Color backgroundActiveColor;
    public Color backgroundInactiveColor;

    public TextMeshProUGUI label;
    public Button leftButton;
    public Button rightButton;
    
    private int selectionIndex = 0;

    private void Awake()
    {
        label.text = carouselSelection[selectionIndex];
        if(selectionIndex == 0)
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
        else if(selectionIndex == carouselSelection.Count - 1)
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
        if(selectionIndex > 0)
        {
            selectionIndex -= 1;
            label.text = carouselSelection[selectionIndex];

            if(selectionIndex == 0)
            {
                leftButton.interactable = false;
            }

            rightButton.interactable = true;
        }
    }

    public void OnRightButtonClick()
    {
        if (selectionIndex < carouselSelection.Count - 1)
        {
            selectionIndex += 1;
            label.text = carouselSelection[selectionIndex];

            if (selectionIndex == carouselSelection.Count - 1)
            {
                rightButton.interactable = false;
            }

            leftButton.interactable = true;
        }
    }

}
