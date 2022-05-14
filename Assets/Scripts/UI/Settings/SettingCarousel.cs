using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingCarousel : MonoBehaviour
{
    public string settingName;
    public List<string> options;
    public int defaultSelection = 0;
    
    [Space(20)]

    public TextMeshProUGUI textBox;
    public Carousel carousel;

    private void Awake() {
        textBox.text = settingName;
        carousel.carouselSelection = options;
        carousel.indexSelection = defaultSelection;
    }
}
