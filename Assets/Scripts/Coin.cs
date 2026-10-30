using UnityEngine;

public class Coin : MonoBehaviour
{

    private int coinValue;

    public void setValue(int value)
    {
        coinValue = value;
    }

    public int getValue()
    {
        return coinValue;
    }
}
