using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackScript : MonoBehaviour {

    public string nickname = "Awful Jetpack";
    public float thrustSpeed = 20f;
    public int fuel = 200;
    public FuelBar fuelBar;
    public Rigidbody2D rb;
    int time = 0;
    public bool thrusting = false;
    public ParticleSystem particles;

    void Start () {
        fuelBar.setFuel (fuel);
        fuelBar.setMaxfuel (fuel);
    }

    void Update () {
        fuelBar.setFuel (fuel);
        time++;
        if (Input.GetButton ("Vertical")) {
            if (time % 8 < 4) {
                thrust ();
            }
        } else {
            thrusting = false;
            particles.Stop ();

            // GameObject.Find("Character").GetComponent<Movement>().thrustingUp = true;
        }

    }

    public void thrust () {
        if (fuel > 0) fuel--;
        if (fuel > 0) {
            particles.Play ();
            rb.AddForce (transform.up * thrustSpeed);
            thrusting = true;
            //  GameObject.Find("Character").GetComponent<Movement>().thrustingUp = true;
        }
        //Debug.Log(fuel);
    }
}