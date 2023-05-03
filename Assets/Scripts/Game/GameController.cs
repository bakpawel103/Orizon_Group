using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Animator topAnimation;
    [SerializeField]
    private Animator middleAnimation;
    [SerializeField]
    private Animator bottomAnimation;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private List<GameObject> lifes;

    [SerializeField]
    private GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);

        topAnimation?.Play("", 0);
        middleAnimation?.Play("", 0);
        bottomAnimation?.Play("", 0);
    }

    void Update()
    {
        var heartsLost = PlayerController.MaxPlayerLifes - playerController.playerInfo.hearts;

        for (int index = 0; index < heartsLost; index++)
        {
            lifes[index].SetActive(false);
        }

        if (playerController.playerInfo.hearts <= 0)
        {
            Time.timeScale = 0.0f;
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        if (playerController.playerInfo.hearts <= 0)
        {
            playerController.playerInfo.hearts = PlayerController.MaxPlayerLifes;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1.0f;
        }
    }
}