using System;
using System.Collections;
using UnityEngine;
using TMPro;

[Serializable]
public struct PlayerInfo
{
    public bool follower1;
    public bool follower2;
    public int bulletType;
    public int hearts;
    public int points;
}

public class PlayerController : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public float speed = 10.0f;

    public static int MaxPlayerLifes = 3;

    [SerializeField]
    private GameObject follower1;
    [SerializeField]
    private GameObject follower2;

    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private TMP_Text pointsText;

    [SerializeField]
    private GameObject bulletPrefab;

    private Vector3 mousePosition;
    private Vector2 position = new Vector2(0.0f, 0.0f);

    void Start()
    {
        follower1.SetActive(playerInfo.follower1);
        follower2.SetActive(playerInfo.follower2);

        playerInfo.hearts = MaxPlayerLifes;

        StartCoroutine(LifePointsCounterRoutine());
    }

    void Update()
    {
        float oldPositionX = transform.position.x;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.6f, 1.6f), Mathf.Clamp(transform.position.y, -1.0f, 9.0f), 0.0f);


        if (transform.position.x - oldPositionX < 0)
        {
            playerAnimator?.SetInteger("turning", -1);
        }
        else if (transform.position.x - oldPositionX > 0)
        {
            playerAnimator?.SetInteger("turning", 1);
        }
        else
        {
            playerAnimator?.SetInteger("turning", 0);
        }

        // Shooting
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().enemyHit.AddListener(OnEnemyHit);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }

    IEnumerator LifePointsCounterRoutine()
    {
        while (playerInfo.hearts > 0)
        {
            AddPoints(1);

            yield return new WaitForSeconds(1.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            playerInfo.hearts--;
        }
    }

    void OnEnemyHit()
    {
        AddPoints(100);
    }

    void AddPoints(int points)
    {
        playerInfo.points += points;

        pointsText.text = "Points: " + playerInfo.points;
    }
}
