using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 100;

    // Start is called before the first frame update
    void Update() {
        transform.Translate(Vector3.forward * 0.5f);

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other) {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null) {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
