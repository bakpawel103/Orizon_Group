using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private float speed = 6.0f;

    public UnityEvent enemyHit;

    void Update()
    {
        if (transform.position.y > 10.0)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f));
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            enemyHit?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
