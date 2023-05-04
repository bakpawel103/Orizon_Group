using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points;
    public bool frozen;

    public PlayerController playerController;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject iceGO;

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

        iceGO.SetActive(frozen);

        if (frozen)
        {
            return;
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

    public void DestroyEnemy()
    {
        animator.SetTrigger("Destroy");

        Destroy(this.gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void Freeze()
    {
        frozen = true;
    }

    public void Unfreeze()
    {
        frozen = false;
    }
}
