using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonStuff : MonoBehaviour
{
    public TextMeshProUGUI debugText; // Assign this in the inspector
    public InteractableDebugVisual buttonLightAnimation;
    public PokeInteractableVisual buttonPressAnimation;
    private void Start()
    {
        debugText.text = "hello \n";
    }
    
    void OnTriggerEnter(Collider other)
    {
        buttonPressAnimation.UpdateButtonAnimation(true);
        buttonLightAnimation._material.color = Color.green;
        
        debugText.text += "Colliding Object name: " + other.name;
    }
}
