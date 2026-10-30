using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Coin coinScript;

    private int playerScore;
    [SerializeField] int winCondition = 1000;

    private int coinsLeft = 5;

    private string enemyTag = "Enemy";
    private string coinTag = "Coin";

    private void Awake()
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
        Debug.Log("Score: " + playerScore + "/" + winCondition);

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
        if (collision.CompareTag(coinTag))
        {
            Destroy(collision.gameObject);
            AddScore(coinScript.getValue());
            coinsLeft--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("you lose");
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
