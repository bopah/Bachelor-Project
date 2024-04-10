using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private List<float> scales = new List<float> { 1.0f, 1.1f, 1.25f, 1.4f, 1.55f, 1.7f, 1.85f, 2.0f, 0.909f, 0.8f, 0.714f, 0.645f, 0.588f, 0.54f, 0.5f};
    //private List<float> scales = new List<float> { 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.0f, 1.14f, 1.28f, 1.42f, 1.56f, 1.7f};

    public GameObject[] buttons; // Assign all buttons in inspector
    //private List<float> buttonLeftList = new List<float> { 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.0f, 1.14f, 1.28f, 1.42f, 1.56f, 1.7f };
    //private List<float> buttonMidList = new List<float> { 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.0f, 1.14f, 1.28f, 1.42f, 1.56f, 1.7f };
    //private List<float> buttonRightList = new List<float> { 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.0f, 1.14f, 1.28f, 1.42f, 1.56f, 1.7f };
    private List<float> buttonLeftList = new List<float> { 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.0f, 1.05f, 1.10f, 1.15f, 1.20f, 1.25f };
    private List<float> buttonMidList = new List<float> { 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.0f, 1.05f, 1.10f, 1.15f, 1.20f, 1.25f };
    private List<float> buttonRightList = new List<float> { 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.0f, 1.05f, 1.10f, 1.15f, 1.20f, 1.25f };

    private float scaleValue = 1f;
    private int randomScale = 0;
    private string targetButton = "targetMid";
    private int buttonTarget = 0;

    //public GameObject canvas;
    //public Text canvasText;

    public Transform rightHandAnchor; // position of my real hand
    public HandMovementScaler handMovementScaler;

    public GameObject[] leftHandGameObject;
    public GameObject rightHandGameObject;

    private bool trial = true;
    private int trialNumber = 1;
    private string trialScaleLevel = "the slowest scale.";
    private int leftButtonTrial = 0;
    private int midButtonTrial = 0;
    private int rightButtonTrial = 0;

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
            trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                    "Hold your hand in the white/transparent box.";
                                    
            gameObjectManager.ActivateTransparentCube();
        }
        else
        {
            gameObjectManager.ActivateRealCanvas();
            realCanvasText.text = "Hold your hand in the white/transparent box.";
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
        // If the button target list has a count of 0, then the button has tried all scale values and we stop activating this button.
        // But when its a trial, then each button must activate 3 times each before trial ends
        buttonTarget = Random.Range(0, 3); // 3 is exclusive
        int buttonTargetListLength = 0;
        
        // Infinite loop until we hit a valid button target (list is not empty)
        while (true)
        {
            if (trial == true)
            {

                if (buttonTarget == 0 && leftButtonTrial != 3)
                {

                    //misc.text = "leftTrial.count, midTrial.count, rightTrial.count: " + leftButtonTrial + "," + midButtonTrial + "," + rightButtonTrial + "\n";
                    
                    if (leftButtonTrial == 0)
                    {
                        scaleValue = 0.75f;
                        trialScaleLevel = "the slowest scale.";
                    }
                    else if (leftButtonTrial == 1)
                    {
                        scaleValue = 1f;
                        trialScaleLevel = "not scaled.";
                    }
                    else if (leftButtonTrial == 2)
                    {
                        scaleValue = 1.25f;
                        trialScaleLevel = "the fasted scale.";
                    }
                      
                    //misc.text += "scaleValue: " + scaleValue + "\n";
                    
                    
                    targetButton = "Trial-targetLeftButton";
                    //misc.text += "targetButton name: " + targetButton + "\n";
                    leftButtonTrial++;
                    break;
                }
                else if (buttonTarget == 1 && midButtonTrial != 3)
                {
                    //misc.text = "leftTrial.count, midTrial.count, rightTrial.count: " + leftButtonTrial + "," + midButtonTrial + "," + rightButtonTrial + "\n";

                    if (midButtonTrial == 0)
                    {
                        scaleValue = 0.75f;
                        trialScaleLevel = "the slowest scale.";
                    }
                    else if (midButtonTrial == 1)
                    {
                        scaleValue = 1f;
                        trialScaleLevel = "not scaled.";
                    }
                    else if (midButtonTrial == 2)
                    {
                        scaleValue = 1.25f;
                        trialScaleLevel = "the fasted scale.";
                    }

                    //misc.text += "scaleValue: " + scaleValue + "\n";


                    targetButton = "Trial-targetMidButton";
                    misc.text += "targetButton name: " + targetButton + "\n";
                    midButtonTrial++;
                    break;
                }
                else if (buttonTarget == 2 && rightButtonTrial != 3)
                {
                    //misc.text = "leftTrial.count, midTrial.count, rightTrial.count: " + leftButtonTrial + "," + midButtonTrial + "," + rightButtonTrial + "\n";

                    if (rightButtonTrial == 0)
                    {
                        scaleValue = 0.75f;
                        trialScaleLevel = "the slowest scale.";
                    }
                    else if (rightButtonTrial == 1)
                    {
                        scaleValue = 1f;
                        trialScaleLevel = "not scaled.";
                    }
                    else if (rightButtonTrial == 2)
                    {
                        scaleValue = 1.25f;
                        trialScaleLevel = "the fasted scale.";
                    }

                    //misc.text += "scaleValue: " + scaleValue + "\n";


                    targetButton = "Trial-targetRightButton";
                    //misc.text += "targetButton name: " + targetButton + "\n";
                    rightButtonTrial++;
                    break;
                }
                else
                {
                    buttonTarget = Random.Range(0, 3);
                    continue;
                }
            }
            // Not trial anymore
            else
            {

                // If one of the lists is not empty, then loop break.
                if (buttonTarget == 0 && buttonLeftList.Count != 0)
                {
                    //misc.text = "left.count, mid.count, right.count: " + buttonLeftList.Count + "," + buttonMidList.Count + "," + buttonRightList.Count + "\n";
                    buttonTargetListLength = buttonLeftList.Count; // Updating the length of the button target list
                    //misc.text += "buttonTargetListLength: " + buttonLeftList.Count + "\n";
                    // Finding an unused scale of target button list
                    randomScale = Random.Range(0, buttonTargetListLength);
                    //misc.text += "randomScale: " + randomScale + "\n";
                    scaleValue = buttonLeftList[randomScale];
                    //misc.text += "scaleValue: " + scaleValue + "\n";
                    buttonLeftList.RemoveAt(randomScale); // Removing the scale value from the list.
                    //misc.text += "buttonLeftList count: " + buttonLeftList.Count + "\n";

                    targetButton = "targetLeftButton";
                    //misc.text += "targetButton name: " + targetButton + "\n";
                    break;
                }
                else if (buttonTarget == 1 && buttonMidList.Count != 0)
                {
                    //misc.text = "left.count, mid.count, right.count: " + buttonLeftList.Count + "," + buttonMidList.Count + "," + buttonRightList.Count + "\n";
                    buttonTargetListLength = buttonMidList.Count; // Updating the length of the button target list
                    //misc.text += "buttonTargetListLength: " + buttonMidList.Count + "\n";
                    // Finding an unused scale of target button list
                    randomScale = Random.Range(0, buttonTargetListLength);
                    //misc.text += "randomScale: " + randomScale + "\n";
                    scaleValue = buttonMidList[randomScale];
                    //misc.text += "scaleValue: " + scaleValue + "\n";
                    buttonMidList.RemoveAt(randomScale); // Removing the scale value from the list.
                    //misc.text += "buttonMidList count: " + buttonMidList.Count + "\n";

                    targetButton = "targetMidButton";
                    //misc.text += "targetButton name: " + targetButton + "\n";
                    break;
                }
                else if (buttonTarget == 2 && buttonRightList.Count != 0)
                {
                    //misc.text = "left.count, mid.count, right.count: " + buttonLeftList.Count + "," + buttonMidList.Count + "," + buttonRightList.Count + "\n";
                    buttonTargetListLength = buttonRightList.Count; // Updating the length of the button target list
                    //misc.text += "buttonTargetListLength: " + buttonRightList.Count + "\n";
                    // Finding an unused scale of target button list
                    randomScale = Random.Range(0, buttonTargetListLength);
                    //misc.text += "randomScale: " + randomScale + "\n";
                    scaleValue = buttonRightList[randomScale];
                    //misc.text += "scaleValue: " + scaleValue + "\n";
                    buttonRightList.RemoveAt(randomScale); // Removing the scale value from the list.
                    //misc.text += "buttonRightList count: " + buttonRightList.Count + "\n";

                    targetButton = "targetRightButton";
                    //misc.text += "targetButton name: " + targetButton + "\n";
                    break;
                }
                else
                {
                    buttonTarget = Random.Range(0, 3);
                    continue;
                }
            }
        }
       
        buttons[buttonTarget].SetActive(true);
        
        handMovementScaler.ActivateScaling(rightHandAnchor.position, scaleValue); // Setting warp origin + activating scaling
        
        if (trial == true)
        {
            trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                    "Press the button with your index finger. \n" +
                                    $"This is {trialScaleLevel}";
        }
        else
            realCanvasText.text = "Press the button with your index finger.";
    }
    public void StepTwoFalse()
    {
        step2 = false;
        handMovementScaler.DeActivateScaling();
        buttons[buttonTarget].SetActive(false);
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
            trialYesNoText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                    "Did the virtual hand move faster or slower than your real hand?";

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
        // If all the button target lists are empty, then the game is over!
        if (buttonLeftList.Count == 0 && buttonMidList.Count == 0 && buttonRightList.Count == 0)
        {
            // GameOver Screen!
            GameOver();
        }
    }

    public void ActivateRecordingYes()
    {
        csvWriter.WriteToCSV(targetButton, scaleValue, true);
    }
    public void ActivateRecordingNo()
    {
        csvWriter.WriteToCSV(targetButton, scaleValue, false);
    }

    private void GameOver()
    {
        step1 = false;
        realCanvasText.text = "The experiment is over. Thank you very much!";
        gameObjectManager.ActivateRealCanvas();
    }
}
