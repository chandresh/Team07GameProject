using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsTextController : MonoBehaviour
{
    //public Text instructionText;
    public Image[] instructionImages;
    public float firstImageDuration = 10f;
    private bool isFirstImageShown = false;

    //Keep track of which buttons have been clicked
    private HashSet<KeyCode> clickedButtons = new HashSet<KeyCode>();

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
        if (!isFirstImageShown && (Input.GetKeyDown(KeyCode.I)))
        {
            HideFirstImage();
        }
        // Check if any of the specified keys or mouse buttons are pressed
        if (!isFirstImageShown)
        {
            CheckButtonsClicked();
        }

    }
    private void CheckButtonsClicked()
    {
        // Add all the specified keys and mouse buttons to the HashSet
        if (Input.GetKeyDown(KeyCode.W)) clickedButtons.Add(KeyCode.W);
        if (Input.GetKeyDown(KeyCode.A)) clickedButtons.Add(KeyCode.A);
        if (Input.GetKeyDown(KeyCode.S)) clickedButtons.Add(KeyCode.S);
        if (Input.GetKeyDown(KeyCode.D)) clickedButtons.Add(KeyCode.D);
        if (Input.GetMouseButtonDown(0)) clickedButtons.Add(KeyCode.Mouse0);
        if (Input.GetKeyDown(KeyCode.Escape)) clickedButtons.Add(KeyCode.Escape);
        // if (Input.GetKeyDown(KeyCode.I)) clickedButtons.Add(KeyCode.I);

        // Check if all the specified buttons have been clicked
        if (clickedButtons.Count == 6)
        {
            HideFirstImage();
        }
    }

}
