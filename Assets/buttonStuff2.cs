using Oculus.Interaction;
using System.Collections;
using TMPro;
using UnityEngine;

public class ButtonStuff2 : MonoBehaviour
{
    public TextMeshProUGUI debugText; // Assign this in the inspector
    public InteractableDebugVisual buttonLightAnimation;
    public PokeInteractableVisual buttonPressAnimation;
    public AudioTrigger audioTrigger;

    public GameManager2 gameManager2;
    private bool buttonPressed = false; // So that a player cannot press a button multiple times when pressing all the way down

    public AudioSource correctSound;
    public AudioSource wrongSound;


    void OnTriggerEnter(Collider other)
    {
        if (buttonPressed == false)
        {
            buttonPressAnimation.UpdateButtonAnimation(true);
            buttonLightAnimation._material.color = Color.green;
            audioTrigger.PlayAudio();
            string name = gameObject.name;
            bool correct = gameManager2.RightWrongButton(name);
            if (correct == true)
            {
                correctSound.Play();
            }
            else if (correct == false)
            {
                wrongSound.Play();
            }
            StartCoroutine(DelayedAction());
            buttonPressed = true;
        }

    }

    IEnumerator DelayedAction()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1);

        // Perform the action after the delay
        gameManager2.StepTwoFalse();
        buttonPressAnimation.UpdateButtonAnimation(false);
        buttonLightAnimation._material.color = Color.red;
        buttonPressed = false;
    }
}
