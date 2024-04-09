using TMPro;
using UnityEngine;

public class HandBoxTimer : MonoBehaviour
{
    private float timeHandInside = 0f;
    private bool isHandInside = false;
    private float requiredTime = 0.5f; // Time in seconds

    public TextMeshProUGUI debugText; // Assign this in the inspector

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        debugText.text += "ENTER other.name= " + other.name + "\n";
        //if (other.name == "Hand_Index3_CapsuleCollider") // Make sure your hand or controller has the tag "Hand"
        //{
        //    isHandInside = true;
        //    timeHandInside = 0f;
        //}
        isHandInside = true;
        timeHandInside = 0f;
    }

    private void OnTriggerExit(Collider other)
    {
        /*debugText.text += "EXIT other.name= " + other.name + "\n";
        if (other.name == "Hand_Index3_CapsuleCollider")
        {
            isHandInside = false;
        }
        */
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
                //debugText.text += "Hand was inside for required time!";
                isHandInside = false; // Reset or keep it true based on your requirement
                timeHandInside = 0f;
                gameManager.StepOneFalse();
                
            }
        }
    }
}
