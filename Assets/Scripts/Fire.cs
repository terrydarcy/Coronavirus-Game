using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject jetpack;

    void Start () {
    }

    void Update () {

        if (jetpack.GetComponent<JetpackScript>().thrusting) {
            GetComponent<Renderer> ().enabled = true;
        } else {
            GetComponent<Renderer> ().enabled = false;
        }
    }
}