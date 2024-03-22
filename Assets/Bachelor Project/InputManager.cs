using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public Text statusText; // Reference to the UI Text element

    private enum InputMode
    {
        Hand,
        Controller
    }

    private InputMode currentInputMode = InputMode.Controller;

    void Update()
    {
        // Check for the 'X' button press on the left controller
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            SwitchInputMode();
        }

        // Update the UI Text
        statusText.text = "Current Input Mode: " + currentInputMode;
    }

    private void SwitchInputMode()
    {
        if (currentInputMode == InputMode.Hand)
        {
            currentInputMode = InputMode.Controller;
            // Additional logic to enable controller input and disable hand tracking
        }
        else
        {
            currentInputMode = InputMode.Hand;
            // Additional logic to enable hand tracking and disable controller input
        }
    }
}
