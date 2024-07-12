using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    float restartDelay = 3f;
    public static bool loadGameFromMenu = false;

    public void Start()
    {
        if (loadGameFromMenu) 
        {
            LoadGame();
            loadGameFromMenu = false;
        }
    }

    //Player player;
    public void GameOver() 
    {
        if (!gameHasEnded) 
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");

            // Restart the game
            Invoke("RestartGame", restartDelay);
        }
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveGame(Player player) 
    {
        player = FindAnyObjectByType<Player>();
        SaveSystem.SavePlayer(player);
    }

    public void LoadGame() 
    {
        Debug.Log("Loading a saved game...");
        Player player = FindAnyObjectByType<Player>();
        PlayerData data = SaveSystem.LoadPlayer(); // Load the player saved data

        // Assign the player saved data to players variables
        // Player basic attribudes
        player.maxHealth = data.health;
        player.level = data.level;
        player.coinCount = data.coins;
        player.shurikenCount = data.shurikens;
        Debug.Log("Saved coins: " + player.coinCount + "Saved shurikens: " + player.shurikenCount);

        // Player position
        Vector3 playerPos = new Vector3(data.position[0], data.position[1], data.position[2]);
        player.transform.position = playerPos;

        // Player last checkpoint position
        Vector2 lastCheckPos = new Vector2(data.checkPointPosition[0], data.checkPointPosition[1]);
        player.SetCheckPointPos(lastCheckPos);
        player.UpdateShurikenUI();
        player.UpdateCoinUI();
    }
}
