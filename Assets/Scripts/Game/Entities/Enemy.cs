using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points;

    [SerializeField]
    private Animator animator;

    private float speed;

    void Start()
    {
        speed = Random.Range(1.0f, 6.0f);
    }

    void Update()
    {
        if (transform.position.y < -3.0)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(new Vector3(0.0f, speed * Time.deltaTime * -1.0f, 0.0f));
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Bullet" || collider.gameObject.tag == "Player")
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        animator.SetTrigger("Destroy");

        Destroy(this.gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
