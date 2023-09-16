using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsTextController : MonoBehaviour
{
    //public Text instructionText;
    public GameObject[] instructionImages;
    public float firstImageDuration = 5f;
    private bool isFirstImageShown = false;

    //Keep track of which buttons have been clicked
    private HashSet<KeyCode> clickedButtons = new HashSet<KeyCode>();

    private void Start()
    {
        //instructionImages[1].gameObject.SetActive(true);
        //AdjustImageForScreenWidth(instructionImages[1], isTopRight: true);
        // Show the first image at the start of the game
        if (instructionImages.Length > 0)
        {
            instructionImages[0].gameObject.SetActive(true);

            AdjustImageForScreenWidth(instructionImages[0]);

            Invoke("HideFirstImage", firstImageDuration);
        }
    }

private void AdjustImageForScreenWidth(GameObject imageObject, bool isTopRight = false)
{
    RectTransform imageTransform = imageObject.GetComponent<RectTransform>();

    // Get the screen width and height
    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    // Calculate the desired width and height for the image based on screen width
    float desiredWidth = -screenWidth * 0.35f; // You can adjust this value as needed
    float desiredHeight = desiredWidth - Screen.height * 0.1f; // You can adjust this value as needed

    // Set the size of the image
    imageTransform.sizeDelta = new Vector2(desiredWidth, desiredHeight);

    // Set the position of the image based on the specified location
    if (isTopRight)
    {
        float xPos = screenWidth * 0.9f;
        float yPos = screenHeight * 0.92f;
        imageTransform.position = new Vector3(xPos, yPos, imageTransform.position.z);
    }
    else
    {
        float xPos = screenWidth * 0.6f;
        float yPos = screenHeight * 0.85f;
        imageTransform.position = new Vector3(xPos, yPos, imageTransform.position.z);
    }
}


    private void HideFirstImage()
    {
        // Hide the first image after the firstImageDuration
        if (instructionImages.Length > 0)
        {
            instructionImages[0].gameObject.SetActive(false);
            isFirstImageShown = true; // Set the flag to true after hiding the first image

            // Show the second image
            if (instructionImages.Length > 1)
            {
                instructionImages[1].gameObject.SetActive(true);
                AdjustImageForScreenWidth(instructionImages[1], isTopRight: true);
            }
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

        // check if the first image is not active
        if (!instructionImages[0].activeSelf)
        {
            instructionImages[1].gameObject.SetActive(true);
            AdjustImageForScreenWidth(instructionImages[1], isTopRight: true);
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
