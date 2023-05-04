using UnityEngine;

public class FreezeAbility : AAbility
{
    public override float speed { get => 5.0f; }

    private float freezeDuration = 5.0f;

    void Start()
    {

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
        if (collider.gameObject.tag == "Player")
        {
            Invoke();
        }
    }

    public override void Invoke()
    {
        enemiesSpawnController?.freezeEnemies.Invoke(freezeDuration);

        Destroy(this.gameObject);
    }
}
