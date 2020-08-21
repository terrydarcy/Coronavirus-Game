using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackSwitcher : MonoBehaviour {

    public int selectedJetpack = 0;

    void Start(){
        selectJetpack();
    }

    void Update() {
                if (Input.GetKey ("t")) {
                    selectedJetpack = 0;
                    selectJetpack();
                } else 
                if (Input.GetKey ("g")) {
                    selectedJetpack = 1;
                    selectJetpack();
                }


    }

    void thrustCurrentlySelectedJetpack() {
         int i = 0;
        foreach(Transform jetpack in transform) {
            if(i == selectedJetpack) ;
            else jetpack.gameObject.GetComponent<JetpackScript>().thrust();;
            i++;
        }
    }
    
    void selectJetpack() {
        int i = 0;
        foreach(Transform jetpack in transform) {
            if(i == selectedJetpack) jetpack.gameObject.SetActive(true);
            else jetpack.gameObject.SetActive(false);
            i++;
        }
    }
}
