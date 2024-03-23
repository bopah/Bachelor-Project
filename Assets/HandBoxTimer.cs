using TMPro;
using UnityEngine;

public class HandBoxTimer : MonoBehaviour
{
    private float timeHandInside = 0f;
    private bool isHandInside = false;
    public float requiredTime = 0.5f; // Time in seconds

    public TextMeshProUGUI debugText; // Assign this in the inspector

    private void OnTriggerEnter(Collider other)
    {
        //debugText.text += "Collider other.name: " + other.name;
        if (other.name == "Hand_Middle2_CapsuleCollider") // Make sure your hand or controller has the tag "Hand"
        {
            debugText.text += "Hand is inside!";
            isHandInside = true;
            timeHandInside = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            debugText.text += "Hand is NOT inside!";
            isHandInside = false;
        }
    }

    private void Update()
    {
        if (isHandInside)
        {
            timeHandInside += Time.deltaTime;

            if (timeHandInside >= requiredTime)
            {
                // Trigger your event here
                //Debug.Log("Hand was inside for required time!");
                debugText.text += "Hand was inside for required time!";
                isHandInside = false; // Reset or keep it true based on your requirement
            }
        }
    }
}
