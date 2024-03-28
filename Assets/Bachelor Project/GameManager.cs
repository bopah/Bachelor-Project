using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private List<float> scales = new List<float> { 1.0f, 1.1f, 1.25f, 1.4f, 1.55f, 1.7f, 1.85f, 2.0f, 0.909f, 0.8f, 0.714f, 0.645f, 0.588f, 0.54f, 0.5f};
    
    public GameObject[] buttons; // Assign all buttons in inspector
    private List<float> buttonLeftList = new List<float> { 1.0f, 1.1f, 1.25f, 1.4f, 1.55f, 1.7f, 1.85f, 2.0f, 0.909f, 0.8f, 0.714f, 0.645f, 0.588f, 0.54f, 0.5f };
    private List<float> buttonMidList = new List<float> { 1.0f, 1.1f, 1.25f, 1.4f, 1.55f, 1.7f, 1.85f, 2.0f, 0.909f, 0.8f, 0.714f, 0.645f, 0.588f, 0.54f, 0.5f };
    private List<float> buttonRightList = new List<float> { 1.0f, 1.1f, 1.25f, 1.4f, 1.55f, 1.7f, 1.85f, 2.0f, 0.909f, 0.8f, 0.714f, 0.645f, 0.588f, 0.54f, 0.5f };
    
    private float scaleValue = 1f;
    private int randomScale = 0;
    private string targetButton = "targetMid";

    //public GameObject canvas;
    //public Text canvasText;

    public Transform rightHandAnchor; // position of my real hand
    public HandMovementScaler handMovementScaler;

    public GameObject[] leftHandGameObject;
    public GameObject rightHandGameObject;

    private bool trial = true;
    private int trialNumber = 1;

    public TextMeshProUGUI trialYesNoText; // Assign this in the inspector

    public TextMeshProUGUI trialCanvasText; // Assign this in the inspector
    public TextMeshProUGUI realCanvasText; // Assign this in the inspector

    public GameObjectManager gameObjectManager;

    private bool step1 = true;
    private bool step2 = false;
    private bool step3 = false;

    public CSVWriter csvWriter;


    public TextMeshProUGUI misc; // Assign this in the inspector


    void Update()
    {
        // Place hand inside transparent box
        if (step1 == true) 
        {
            StepOneTrue();
            step1 = false;
        }
        // Press on button
        else if (step2 == true) 
        {
            StepTwoTrue();
            step2 = false;
        }
        // Press yes or no
        else if (step3 == true) 
        {
            StepThreeTrue();
            step3 = false;
        }
    }

    public void StepOneTrue()
    {
        if (trial == true)
        {
            gameObjectManager.ActivateTrialCanvas();
            trialCanvasText.text = $"[This is a trial run ({trialNumber}/9) \n]" +
                                    "Hold your hand in the white/transparent box for 1 second.";
            gameObjectManager.ActivateTransparentCube();
        }
        else
        {
            gameObjectManager.ActivateRealCanvas();
            realCanvasText.text = "Hold your hand in the white/transparent box for 1 second.";
            gameObjectManager.ActivateTransparentCube();
        }
        rightHandGameObject.SetActive(true);
        leftHandGameObject[0].SetActive(false);
        leftHandGameObject[1].SetActive(false);

    }
    public void StepOneFalse()
    {
        step1 = false;
        gameObjectManager.DeactivateTransparentCube();
        step2 = true;
    }

    public void StepTwoTrue()
    {
        // Finding which random button to activate.
        // If the button target list has a count of 15 values, then the button has tried all scale values and we stop activating this button.
        int buttonTarget = Random.Range(0, 3); // 3 is exclusive
        int buttonTargetListLength = 0;
        //float scaleValue = 1f;
        //int randomScale = 0;
        while (true)
        {
            // If all the button target lists are full, then the game is over!
            if (buttonLeftList.Count == 15 && buttonMidList.Count == 15 && buttonRightList.Count == 15)
            {
                // GameOver Screen!
                break;
            }

            // If one of the lists is not full, then loop break.
            if (buttonTarget == 0 && buttonLeftList.Count != 15)
            {
                misc.text = "buttonLeftList: " + buttonLeftList + "\n";
                buttonTargetListLength = buttonLeftList.Count; // Updating the length of the button target list
                misc.text += "buttonTargetListLength: " + buttonLeftList.Count + "\n";
                // Finding an unused scale of target button list
                randomScale = Random.Range(0, buttonTargetListLength);
                misc.text += "randomScale: " + randomScale + "\n";
                scaleValue = buttonLeftList[randomScale];
                misc.text += "scaleValue: " + scaleValue + "\n";
                buttonLeftList.RemoveAt(randomScale); // Removing the scale value from the list.
                misc.text += "buttonLeftList: " + buttonLeftList + "\n";

                targetButton = "targetLeftButton";
                misc.text += "targetButton name: " + targetButton + "\n";
                break;
            }
            else if (buttonTarget == 1 && buttonMidList.Count != 15)
            {
                misc.text = "buttonMIDtList: " + buttonMidList + "\n";
                buttonTargetListLength = buttonMidList.Count; // Updating the length of the button target list
                misc.text += "buttonTargetListLength: " + buttonMidList.Count + "\n";
                // Finding an unused scale of target button list
                randomScale = Random.Range(0, buttonTargetListLength);
                misc.text += "randomScale: " + randomScale + "\n";
                scaleValue = buttonMidList[randomScale];
                misc.text += "scaleValue: " + scaleValue + "\n";
                buttonMidList.RemoveAt(randomScale); // Removing the scale value from the list.
                misc.text += "buttonMidList: " + buttonMidList + "\n";

                targetButton = "targetMidButton";
                misc.text += "targetButton name: " + targetButton + "\n";
                break;
            }
            else if (buttonTarget == 2 && buttonRightList.Count != 15)
            {
                misc.text = "buttonRightList: " + buttonRightList + "\n";
                buttonTargetListLength = buttonRightList.Count; // Updating the length of the button target list
                misc.text += "buttonTargetListLength: " + buttonRightList.Count + "\n";
                // Finding an unused scale of target button list
                randomScale = Random.Range(0, buttonTargetListLength);
                misc.text += "randomScale: " + randomScale + "\n";
                scaleValue = buttonRightList[randomScale];
                misc.text += "scaleValue: " + scaleValue + "\n";
                buttonRightList.RemoveAt(randomScale); // Removing the scale value from the list.
                misc.text += "buttonRightList: " + buttonRightList + "\n";

                targetButton = "targetRightButton";
                misc.text += "targetButton name: " + targetButton + "\n";
                break;
            }
            else
            {
                buttonTarget = Random.Range(0, 3);
                continue;
            }

        }
        
        buttons[buttonTarget].SetActive(true);
        
        handMovementScaler.ActivateScaling(rightHandAnchor.position, scaleValue); // Setting warp origin + activating scaling
        
        if (trial == true)
        {
            trialCanvasText.text = $"[This is a trial run ({trialNumber}/9) \n]" +
                                    "Press the button with your index finger.";
        }
        else
            realCanvasText.text = "Press the button with your index finger.";
    }
    public void StepTwoFalse()
    {
        step2 = false;
        handMovementScaler.DeActivateScaling();
        buttons[0].SetActive(false);
        if (trial == true)
        {
            gameObjectManager.DeactivateTrialCanvas();
        }
        else
            gameObjectManager.DeactivateRealCanvas();

        step3 = true;
        
    }

    public void StepThreeTrue()
    {

        if (trial == true)
        {
            gameObjectManager.ActivateTrialYesNo();
            trialYesNoText.text = $"[This is a trial run ({trialNumber}/9) \n]" +
                                    "Did the movement of the virtual hand exactly correspond to your own movement?";

        }
        else
        {
            gameObjectManager.ActivateRealYesNo();
        }
        rightHandGameObject.SetActive(false);
        leftHandGameObject[0].SetActive(true);
        leftHandGameObject[1].SetActive(true);



    }
    public void StepThreeFalse()
    {
        step3 = false;
        if (trial == true)
        {
            gameObjectManager.DeactivateTrialYesNo();
            trialNumber++;
            if (trialNumber == 10)
            {
                trial = false;
            }
        }
        else
        {
            gameObjectManager.DeactivateRealYesNo();
        }
        step1 = true;
    }

    public void ActivateRecordingYes()
    {
        csvWriter.WriteToCSV(targetButton, scaleValue, true);
    }
    public void ActivateRecordingNo()
    {
        csvWriter.WriteToCSV(targetButton, scaleValue, false);
    }
}
