using UnityEngine;
using TMPro;

public class CoinScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject winPanel;
    public int totalCoins = 10;
    int score = 0;

    void Awake()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}/{totalCoins}";
        }

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ������ �ݵ�� Tag=Coin, Collider2D.IsTrigger=On
        if (other.CompareTag("Coin") == true)
        {
            score++;
            other.gameObject.SetActive(false); // ���� ����(ȹ�� ó��)
            if (scoreText != null)
            {
                scoreText.text = $"Score: {score}/{totalCoins}";
            }

            if (score >= totalCoins && winPanel != null)
            {
                winPanel.SetActive(true);
            }
        }
    }
}
