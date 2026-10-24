using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private int playerScore;
    [SerializeField] int winCondition = 1000;

    private int coinsLeft = 5;

    private string enemyTag = "Enemy";
    private string yellowCoinTag = "Yellow_Coin";
    private string greenCoinTag = "Green_Coin";
    private string blueCoinTag = "Blue_Coin";

    private int yellowCoinScore = 50;
    private int greenCoinScore = 20;
    private int blueCoinScore = 10;

    private void Start()
    {
        playerScore = 0;
    }

    private void Update()
    {
        if (coinsLeft <= 0)
        {
            gameManager.GenerateCoins();
            coinsLeft = 5;
        }
    }

    public void AddScore(int score)
    {
        playerScore += score;
        Debug.Log("Score: " + playerScore);

        if (playerScore >= winCondition)
        {
            Win();
        }
    }

    private void Win()
    {
        Debug.Log("you won");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(yellowCoinTag))
        {
            Destroy(collision.gameObject);
            AddScore(yellowCoinScore);
            coinsLeft--;
        }
        else if (collision.CompareTag(greenCoinTag))
        {
            Destroy(collision.gameObject);
            AddScore(greenCoinScore);
            coinsLeft--;
        }
        else if (collision.CompareTag(blueCoinTag))
        {
            Destroy(collision.gameObject);
            AddScore(blueCoinScore);
            coinsLeft--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("you lose");
            this.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
