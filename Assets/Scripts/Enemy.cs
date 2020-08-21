using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public int health = 100;
    Vector2 knockbackDirection;
    AudioSource audioData;
    public HealthBar healthBar;

    void Start () {
        healthBar.setHealth (health);
        healthBar.setMaxHealth (health);
    }

    void FixedUpdate () {
        healthBar.setHealth (health);
        gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed * Time.deltaTime, 0));
    }

    public void takeDamage (int damage, Transform attacker, float knockback) {
        health -= damage;
        knockbackDirection = attacker.position + transform.position;
        gameObject.GetComponent<Rigidbody2D> ().AddForce (knockbackDirection.normalized * knockback);
        if (health <= 0) die ();
    }

    void die () {
        Destroy (gameObject);
        healthBar.die ();
    }

}