using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsTextController : MonoBehaviour
{
    //public Text instructionText;
    public Image[] instructionImages;
    public float firstImageDuration = 5f;
    private bool isFirstImageShown = false;

    private void Start()
    {
        // Show the first image at the start of the game
        if (instructionImages.Length > 0)
        {
            instructionImages[0].gameObject.SetActive(true);
            Invoke("HideFirstImage", firstImageDuration);
        }
    }

    private void HideFirstImage()
    {
        // Hide the first image after the firstImageDuration
        if (instructionImages.Length > 0)
        {
            instructionImages[0].gameObject.SetActive(false);
            isFirstImageShown = true; // Set the flag to true after hiding the first image
        }
    }

    private void Update()
    {
        // Show the next image indefinitely after the first image has been shown
        if (isFirstImageShown)
        {
            if (instructionImages.Length > 1)
            {
                for (int i = 1; i < instructionImages.Length; i++)
                {
                    instructionImages[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
