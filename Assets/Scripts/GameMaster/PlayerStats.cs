using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 100;

    void Start()
    {
        money = startMoney;
    }
}
