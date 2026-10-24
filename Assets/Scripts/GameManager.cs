using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject yellow_Coin;
    [SerializeField] private GameObject green_Coin;
    [SerializeField] private GameObject blue_Coin;

    [SerializeField] private Vector2 xRange = new Vector2(-9f, 9f);
    [SerializeField] private Vector2 yRange = new Vector2(-5f, 5f);

    void Start()
    {
        GenerateCoins();
    }

    public void GenerateCoins()
    {
        for (int i = 0; i < 5; i++)
        {
            int coin = Random.Range(0, 3);
            Vector2 location = new Vector2(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y));

            switch (coin)
            {
                case 0:
                    Instantiate(yellow_Coin, location, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(green_Coin, location, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(blue_Coin, location, Quaternion.identity);
                    break;
            }
        }
    }
}
