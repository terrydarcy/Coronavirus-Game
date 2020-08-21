using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCell : MonoBehaviour {

    public float speed = 10f;
    public int health = 100;
    Vector2 knockbackDirection;

    void Start () {
    }

    void FixedUpdate () {
        gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed * Time.deltaTime, 0));
    }

    public void takeDamage (int damage, Transform attacker, float knockback) {
        health -= damage;
        knockbackDirection = attacker.position + transform.position;
        //transform.localScale += new Vector3 (-0.1f, -0.1f, 0f);
        gameObject.GetComponent<Rigidbody2D> ().AddForce (knockbackDirection.normalized * knockback);
        if (health <= 0) die ();
    }

    void die () {
        Destroy (gameObject);

    }
}