using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBloodCells : MonoBehaviour {

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public float spawnRate = 200f;
    public float spawnerHeight = 0f;

    float time = 0;

    void Start () {

    }

    void Update () {
        time++;

        //  Debug.Log (time % spawnRate );

        if (time % spawnRate >= (spawnRate - 1)) {
            //            Debug.Log (transform.position.x+ "," + transform.position.y+ "," + transform.position.z);
            float yPos = Random.Range (-spawnerHeight, spawnerHeight);
            var newprefab1 = Instantiate (prefab1, new Vector3 (transform.position.x + Random.Range (-3, 3), transform.position.y + yPos + Random.Range (-3, 3), 1), Quaternion.identity);
            var newprefab2 = Instantiate (prefab2, new Vector3 (transform.position.x + Random.Range (-3, 3), transform.position.y + yPos + Random.Range (-3, 3), 1), Quaternion.identity);
            var newprefab3 = Instantiate (prefab3, new Vector3 (transform.position.x + Random.Range (-3, 3), transform.position.y + yPos + Random.Range (-3, 3), 1), Quaternion.identity);
            newprefab1.transform.parent = gameObject.transform;
            newprefab2.transform.parent = gameObject.transform;
            newprefab3.transform.parent = gameObject.transform;

        }
    }
}