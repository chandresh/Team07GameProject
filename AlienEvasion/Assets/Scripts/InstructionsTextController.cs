using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsTextController : MonoBehaviour
{
    public Text instructionText;
    public float displayDuration = 5f;

    private void Start()
    {
        // Show the instructions at the start of the game
        instructionText.gameObject.SetActive(true);

        // Hide the instructions after a delay (displayDuration)
        Invoke("HideInstructions", displayDuration);
    }

    private void HideInstructions()
    {
        instructionText.gameObject.SetActive(false);
    }
}
