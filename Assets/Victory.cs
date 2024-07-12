using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Image victoryBanner;

    public void ShowVictoryBanner() 
    {
        victoryBanner.GetComponent<Image>().enabled = true;
        
        Invoke(nameof(BackToMenu), 5f);
    }

    // Now after victory, the player is redirected to the main menu, as the game now lacks another levels
    // TODO: With another levels, show the player some victory menu with the option to continue or go to main menu
    void BackToMenu() 
    {
        PauseMenu pauseMenu = FindAnyObjectByType<PauseMenu>();
        pauseMenu.LoadMenu();
    }

}
