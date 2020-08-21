using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour, IPointerDownHandler {

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start () { }

    void Update () { }
    
    public void OnPointerDown (PointerEventData eventData) {
        Debug.Log (this.gameObject.name + " Was Clicked.");
    }
    public void setMaxfuel (int fuel) {
        slider.maxValue = fuel;
        slider.value = fuel;

        fill.color = gradient.Evaluate (1f);
    }

    public void setFuel (int fuel) {
        slider.value = fuel;
        fill.color = gradient.Evaluate (slider.normalizedValue);
    }
}