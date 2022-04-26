using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Speed : MonoBehaviour {
    public Slider slider;
    public ChaseTest chaseTest;
    void Start() {
        var color = transform.GetComponent<SpriteRenderer>().color;
        var colors = slider.colors;
        color.a = 1;
        colors.normalColor = color;
        colors.highlightedColor = color;
        colors.pressedColor = color;
        slider.colors = colors;
        slider.fillRect.GetComponentInParent<Image>().color = color;
    }
    void FixedUpdate() {
        if(chaseTest.firePoint_A == gameObject)
            chaseTest.speed_A = slider.value;
        else
            chaseTest.speed_B = slider.value;

    }
}
