using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isGamePaused) 
            {
                // Resume the game if its currently paused
                Resume();
            }
            else 
            {
                // Pause the game if it is not currently paused
                Pause();
            }
        }
    }

    public void Resume() 
    {
        // Hide pause menu
        pauseMenuUI.SetActive(false);
        // Unfreeze the game
        Time.timeScale = 1f;

        isGamePaused = false;
    }

    void Pause() 
    {
        // Toggle pause menu
        pauseMenuUI.SetActive(true);
        // Freze the game
        Time.timeScale = 0f; // 0 freezes the game, you can use the timeScale to make slow motion effects just by using low values

        isGamePaused = true;
    }

    public void LoadMenu() 
    {
        // Unpause the game
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        // Load the scene with the main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartFromCheckPoint() 
    {
        Player player = FindObjectOfType<Player>();
        // Hide the pause menu
        pauseMenuUI.SetActive(false);
        // Unfreeze the game
        Time.timeScale = 1f;
        player.Respawn();
        isGamePaused = false;
    }

    public void QuitGame() 
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    
}
