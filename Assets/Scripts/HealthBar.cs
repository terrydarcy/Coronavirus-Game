using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IPointerDownHandler {

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Rigidbody2D rigidbody;

    void Start () {

    }

    void Update () { }

    public void OnPointerDown (PointerEventData eventData) {
        Debug.Log (this.gameObject.name + " Was Clicked.");
    }

    public void setPosition (Vector3 position) {
        transform.position = position;
    }
    public void setMaxHealth (int health) {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate (1f);
    }

    public void setHealth (int health) {
        slider.value = health;
        fill.color = gradient.Evaluate (slider.normalizedValue);
    }
    public void die () {
        Destroy (gameObject);
    }
}