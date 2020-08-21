using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 50f;
    public int damage = 20;
    public Rigidbody2D rb;
    public float range = 100f;
    public float knockBack = 50f;

    void Start () {
        Physics.IgnoreLayerCollision (10, 12);
        rb.velocity = transform.right * speed;
        Physics2D.IgnoreLayerCollision (gameObject.layer, gameObject.layer, true);
        speed += Random.Range(-20f,50f);

    }

    void Update () {
        range--;
        if (range <= 0) {
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        Enemy enemy = other.GetComponent<Enemy> ();
        BloodCell bloodCell = other.GetComponent<BloodCell> ();
        if (enemy != null) {
            enemy.takeDamage (damage, transform, knockBack);
        }
        if (bloodCell != null) {
            bloodCell.takeDamage (damage, transform, knockBack);
        }
        Destroy (gameObject);
    }
}