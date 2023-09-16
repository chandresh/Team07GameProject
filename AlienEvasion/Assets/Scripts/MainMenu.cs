using UnityEngine;
using UnityEngine.SceneManagement;

// Load main scene when user clicks on the main menu or presses enter
public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadMainScene();
        }
    }
    void OnMouseDown()
    {
        LoadMainScene();
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
