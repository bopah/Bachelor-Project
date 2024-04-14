using Oculus.Interaction;
using System.Collections;
using TMPro;
using UnityEngine;

public class ButtonStuff : MonoBehaviour
{
    public TextMeshProUGUI debugText; // Assign this in the inspector
    public InteractableDebugVisual buttonLightAnimation;
    public PokeInteractableVisual buttonPressAnimation;
    public AudioTrigger audioTrigger;

    public GameManager gameManager;
    private bool buttonPressed = false; // So that a player cannot press a button multiple times when pressing all the way down

    // Are we using the lowfidelity hand?

    void OnTriggerEnter(Collider other)
    {
        if (buttonPressed == false) // Check if the button has already been pressed
        {
            buttonPressAnimation.UpdateButtonAnimation(true);
            buttonLightAnimation._material.color = Color.green;
            audioTrigger.PlayAudio();
            StartCoroutine(DelayedAction());
            buttonPressed = true;
        }
        
    }

    IEnumerator DelayedAction()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1);

        // Perform the action after the delay
        gameManager.StepTwoFalse();
        buttonPressAnimation.UpdateButtonAnimation(false);
        buttonLightAnimation._material.color = Color.red;
        buttonPressed = false;
    }
}
