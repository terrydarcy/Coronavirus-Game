using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform player;
    private Camera cam;
    public Vector2 offset;
    private GameObject playerObj;
    private CharacterController2D playerscript;
    private bool facingRight = true;
    public float scale;
    float directionOffset;
    public float spread;
    //public ParticleSystem particles;

    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start () {
        cam = Camera.main;
        directionOffset = offset.x;

        playerObj = GameObject.Find ("playerRig");
        playerscript = playerObj.GetComponent<CharacterController2D> ();
    }

    void Update () {
        float clampedScale = Mathf.Clamp (scale, -5f, 5f);

        if (cam.ScreenToWorldPoint (Input.mousePosition).x <= player.position.x) {
            directionOffset = -offset.x;
            transform.localScale = new Vector3 (clampedScale, -clampedScale, 0f);
        } else {
            directionOffset = offset.x;
            transform.localScale = new Vector3 (clampedScale, clampedScale, 0f);
        }

        Vector3 axis = new Vector3 (0, 0, 1);

        Vector2 direction = cam.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis (angle, Vector3.forward);

        transform.rotation = rot;

        transform.position = new Vector2 (player.position.x, player.position.y) + new Vector2 (directionOffset, offset.y);

        if (Input.GetButtonDown ("Fire1")) {
            shoot ();
        }

    }

    void shoot () {
        Quaternion bullet0 = Quaternion.AngleAxis (-spread, Vector3.forward);
        Quaternion bullet1 = Quaternion.AngleAxis (spread, Vector3.forward);
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation * bullet0);
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation * bullet1);
    }

}