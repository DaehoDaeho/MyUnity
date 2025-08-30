using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text hpText;
    public GameObject gameOverPanel;

    public int playerHP = 3;

    private int score = 0;
    private bool isGameOver = false;

    private void Start()
    {
        UpdateScoreUI();
        UpdateHpUI();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void AddScore(int amount)
    {
        score = score + amount;
        UpdateScoreUI();
    }

    public void DamagePlayer(int amount)
    {
        if (isGameOver == true)
        {
            return;
        }

        playerHP = playerHP - amount;

        if (playerHP < 0)
        {
            playerHP = 0;
        }

        UpdateHpUI();

        if (playerHP <= 0)
        {
            isGameOver = true;

            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    private void UpdateHpUI()
    {
        if (hpText != null)
        {
            hpText.text = $"HP: {playerHP}";
        }
    }
}
