using System;
using UnityEngine;

public class InstructionPanel : MonoBehaviour
{
    // Reference to the instructions information panel
    public GameObject instructionPanel;

    private void Start()
    {
        // Hide the instruction panel when the game starts
        instructionPanel.SetActive(false);
    }

    private void Update()
    {
        // Check for input to show/hide the instruction panel
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInstructionPanel();
        }
    }

    private void ToggleInstructionPanel()
    {
        // Toggle the instruction panel on/off
        instructionPanel.SetActive(!instructionPanel.activeSelf);

        // Pause/unpause the game when the instruction panel is active
        Time.timeScale = instructionPanel.activeSelf ? 0f : 1f;
    }
}