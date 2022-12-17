using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    bool gameEnded = false;

    void Update()
    {
        if(gameEnded == false && PlayerStats.lives <= 0)
        {
            gameEnded = true;
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(0);
    }
}
