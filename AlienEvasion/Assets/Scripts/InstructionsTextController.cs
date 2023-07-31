using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsTextController : MonoBehaviour
{
    //public Text instructionText;
    public Image[] instructionImages;
    public float displayDuration = 5f;

    private void Start()
    {
        foreach (var image in instructionImages)
        {
            image.gameObject.SetActive(true);
        }

        // Hide the instructions after a delay (displayDuration)
        Invoke("HideInstructions", displayDuration);
    }

    private void HideInstructions()
    {
        foreach (var image in instructionImages)
        {
            image.gameObject.SetActive(false);
        }
    }
}
