using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    //float restartDelay = 2f;
    public void GameOver() 
    {
        if (!gameHasEnded) 
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");

            // Restart the game from check point
            //Invoke("RestartGame", restartDelay);

        }

    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
