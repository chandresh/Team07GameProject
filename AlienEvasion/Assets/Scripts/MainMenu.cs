using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnImageClick()
    {
        Debug.Log("Image clicked!");
        SceneManager.LoadScene("MainScene");
    }

}
