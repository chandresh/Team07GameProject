using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuCanvas;

    [SerializeField]
    private bool isPaused;

    private void Update()
    {
        // use escape for the pause menu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if(isPaused)
            {
                ActivatePause();
            }
            else
            {
                DeactivatePause();
            }
        }
    }

    private void ActivatePause()
    {
        // TODO: will need to stop game audio when it is added
        // and begin pause menu audio

        // stop time in the game world
        Time.timeScale = 0;

        // show the pause menu canvas
        pauseMenuCanvas.SetActive(true);
    }

    // needs to be public do resume button has access
    public void DeactivatePause()
    {
        // TODO: will need to resume game sounds when audio is added

        // restart game time
        Time.timeScale = 1;

        // hide the pause menu canvas
        pauseMenuCanvas.SetActive(false);
    }
}
