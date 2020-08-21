using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour {

    public int pitch;
    public float PitchOffsetAmount = 0.3f;
    public AudioSource audioSource;


    void Start () {
        audioSource = GetComponent<AudioSource> ();
        audioSource.pitch = pitch +  Random.Range(-PitchOffsetAmount, PitchOffsetAmount);
    }

    void Update () {
    }
}