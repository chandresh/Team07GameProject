using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }    
}
