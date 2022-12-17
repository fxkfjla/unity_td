using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI lives;

    void Update()
    {
        lives.text = "♥" + PlayerStats.lives.ToString();
    }
}