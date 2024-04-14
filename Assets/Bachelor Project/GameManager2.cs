using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
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

    List<string[]> leftButtonTargetAnswerTrial = new List<string[]>
    {
        new string[] { "7x - 21 = 0", "x=3", "x=2", "x=4" },
        new string[] { "8x + 5 = 37", "x=4", "x=5", "x=6" },
        new string[] { "3x + 8*3 = 0", "x=-8", "x=8", "x=9" }
    };

    List<string[]> midButtonTargetAnswerTrial = new List<string[]>
    {
        new string[] { "40% of 40", "x=20", "x=16", "x=12" },
        new string[] { "4*7 + 8", "x=40", "x=36", "x=30" },
        new string[] { "28/7 + 5", "x=11", "x=9", "x=5" }
    };

    List<string[]> rightButtonTargetAnswerTrial = new List<string[]>
    {
        new string[] { "12 - 4x = 8", "x=2", "x=4", "x=1" },
        new string[] { "15% of 40", "x=8", "x=4", "x=6" },
        new string[] { "3*3*3", "x=18", "x=36", "x=27" }
    };

    List<string[]> leftButtonTargetAnswerReal = new List<string[]>
    {
        new string[] { "15x = 15*3 - 15", "x=2", "x=3", "x=4" },
        new string[] { "9x - 3 = 6x + 15", "x=6", "x=8", "x=7" },
        new string[] { "42/6 + 8 - 3", "x=12", "x=15", "x=9" },
        new string[] { "10x = 20 + 10*2", "x=4", "x=2", "x=8" },
        new string[] { "4x + 7 = 19 + 8", "x=5", "x=6", "x=4" },
        new string[] { "25% of 60", "x=15", "x=18", "x=12" },
        new string[] { "12x + 4 = 4*12 + 16", "x=5", "x=6", "x=7" },
        new string[] { "36/9 + 10*3", "x=34", "x=32", "x=38" },
        new string[] { "3x + 9 = 15 + 6", "x=4", "x=6", "x=8" },
        new string[] { "30% of 70", "x=21", "x=25", "x=18" },
        new string[] { "5x + 8 = 3x + 20", "x=6", "x=4", "x=8" }
    };

    List<string[]> midButtonTargetAnswerReal = new List<string[]>
    {
        new string[] { "6x - 18 = 6", "x=6", "x=4", "x=5" },
        new string[] { "7x + 4 = 32", "x=5", "x=4", "x=6" },
        new string[] { "4x + 6*2 = 16", "x=0", "x=1", "x=2" },
        new string[] { "20% of 55", "x=13", "x=11", "x=15" },
        new string[] { "5*6 + 7", "x=42", "x=37", "x=35" },
        new string[] { "35/7 + 6", "x=15", "x=11", "x=13" },
        new string[] { "14 - 3x = 11", "x=3", "x=1", "x=2" },
        new string[] { "15% of 80", "x=18", "x=12", "x=15" },
        new string[] { "1*2*3*4", "x=18", "x=24", "x=36" },
        new string[] { "14x = 14*2 - 14", "x=3", "x=1", "x=2" },
        new string[] { "8x - 4 = 5x + 20", "x=7", "x=8", "x=9" }
    };

    List<string[]> rightButtonTargetAnswerReal = new List<string[]>
    {
        new string[] { "48/6 + 9 - 4", "x=15", "x=10", "x=13" },
        new string[] { "12x = 24 + 12*3", "x=8", "x=6", "x=5" },
        new string[] { "5x + 34 = 17x + 10", "x=1", "x=3", "x=2" },
        new string[] { "60% of 70", "x=45", "x=40", "x=42" },
        new string[] { "11x + 9 = 3*11 + 9", "x=2", "x=4", "x=3" },
        new string[] { "42/7 + 12*2", "x=24", "x=36", "x=30" },
        new string[] { "2x + 7 = 14 + 5", "x=7", "x=8", "x=6" },
        new string[] { "35% of 60", "x=18", "x=24", "x=21" },
        new string[] { "4x + 9 = 2x + 19", "x=14", "x=10", "x=5" },
        new string[] { "1*3*5*2", "x=50", "x=35", "x=30" },
        new string[] { "40x/8 + 4*4 = 31", "x=7", "x=5", "x=3" }
    };

    public TextMeshProUGUI leftButtonTargetMathEquationText; // Assign this in the inspector
    public TextMeshProUGUI midButtonTargetMathEquationText; // Assign this in the inspector
    public TextMeshProUGUI rightButtonTargetMathEquationText; // Assign this in the inspector

    private int randomMathEquation = 0;
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
    private int leftButtonTrial = 0;
    private int midButtonTrial = 0;
    private int rightButtonTrial = 0;
    private string trialScaleLevel = "the slowest scale.";

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

        /*
        if (trial == true)
        {
            trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                    "Press the button with the correct answer. \n" +
                                    $"{leftButtonTargetAnswerTrial[0][0]}";
        }
        else
            realCanvasText.text = "Press the button with the correct answer.";
        */

        // Finding which random button to activate.
        // If the button target list has a count of 0, then the button has tried all scale values and we stop activating this button.
        // But when its a trial, then each button must activate 3 times each before trial ends
        buttonTarget = Random.Range(0, 3); // 3 is exclusive
        int buttonTargetListLength = 0;
        string[] randomMathEquationValue;

        // Infinite loop until we hit a valid button target (list is not empty)
        while (true)
        {
            if (trial == true)
            {

                if (buttonTarget == 0 && leftButtonTrial != 3)
                {

                    misc.text = "leftTrial.count, midTrial.count, rightTrial.count: " + leftButtonTrial + "," + midButtonTrial + "," + rightButtonTrial + "\n";

                    if (leftButtonTrial == 0)
                    {
                        scaleValue = 0.75f;
                        trialScaleLevel = "the slowest scale.";


                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{leftButtonTargetAnswerTrial[0][0]} \n"+
                                               $"This is {trialScaleLevel}"; 
                        leftButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[0][1];
                        midButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[0][2];
                        rightButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[0][3];
                    }
                    else if (leftButtonTrial == 1)
                    {
                        scaleValue = 1f;
                        trialScaleLevel = "not scaled.";

                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{leftButtonTargetAnswerTrial[1][0]} \n"+
                                               $"This is {trialScaleLevel}";
                        leftButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[1][1];
                        midButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[1][2];
                        rightButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[1][3];
                    }
                    else if (leftButtonTrial == 2)
                    {
                        scaleValue = 1.25f;
                        trialScaleLevel = "the fasted scale.";

                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{leftButtonTargetAnswerTrial[2][0]} \n"+
                                               $"This is {trialScaleLevel}";
                        leftButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[2][1];
                        midButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[2][2];
                        rightButtonTargetMathEquationText.text = leftButtonTargetAnswerTrial[2][3];
                    }

                    misc.text += "scaleValue: " + scaleValue + "\n";


                    targetButton = "targetLeftButton";
                    misc.text += "targetButton name: " + targetButton + "\n";
                    leftButtonTrial++;
                    break;
                }
                else if (buttonTarget == 1 && midButtonTrial != 3)
                {
                    misc.text = "leftTrial.count, midTrial.count, rightTrial.count: " + leftButtonTrial + "," + midButtonTrial + "," + rightButtonTrial + "\n";

                    if (midButtonTrial == 0)
                    {
                        scaleValue = 0.75f;
                        trialScaleLevel = "the slowest scale.";

                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{midButtonTargetAnswerTrial[0][0]} \n"+
                                               $"This is {trialScaleLevel}";
                        leftButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[0][1];
                        midButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[0][2];
                        rightButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[0][3];
                    }
                    else if (midButtonTrial == 1)
                    {
                        scaleValue = 1f;
                        trialScaleLevel = "not scaled.";

                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{midButtonTargetAnswerTrial[1][0]} \n"+
                                               $"This is {trialScaleLevel}";
                        leftButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[1][1];
                        midButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[1][2];
                        rightButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[1][3];
                    }
                    else if (midButtonTrial == 2)
                    {
                        scaleValue = 1.25f;
                        trialScaleLevel = "the fasted scale.";

                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{midButtonTargetAnswerTrial[2][0]} \n"+
                                               $"This is {trialScaleLevel}";
                        leftButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[2][1];
                        midButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[2][2];
                        rightButtonTargetMathEquationText.text = midButtonTargetAnswerTrial[2][3];
                    }

                    misc.text += "scaleValue: " + scaleValue + "\n";


                    targetButton = "targetMidButton";
                    misc.text += "targetButton name: " + targetButton + "\n";
                    midButtonTrial++;
                    break;
                }
                else if (buttonTarget == 2 && rightButtonTrial != 3)
                {
                    misc.text = "leftTrial.count, midTrial.count, rightTrial.count: " + leftButtonTrial + "," + midButtonTrial + "," + rightButtonTrial + "\n";

                    if (rightButtonTrial == 0)
                    {
                        scaleValue = 0.75f;
                        trialScaleLevel = "the slowest scale.";

                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{rightButtonTargetAnswerTrial[0][0]} \n"+
                                               $"This is {trialScaleLevel}";
                        leftButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[0][1];
                        midButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[0][2];
                        rightButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[0][3];
                    }
                    else if (rightButtonTrial == 1)
                    {
                        scaleValue = 1f;
                        trialScaleLevel = "not scaled.";

                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{rightButtonTargetAnswerTrial[1][0]} \n"+
                                               $"This is {trialScaleLevel}";
                        leftButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[1][1];
                        midButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[1][2];
                        rightButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[1][3];
                    }
                    else if (rightButtonTrial == 2)
                    {
                        scaleValue = 1.25f;
                        trialScaleLevel = "the fasted scale.";

                        trialCanvasText.text = $"[This is a trial run ({trialNumber}/9)] \n" +
                                                "Press the button with the correct answer: \n" +
                                               $"{rightButtonTargetAnswerTrial[2][0]} \n" +
                                               $"This is {trialScaleLevel}";
                        leftButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[2][1];
                        midButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[2][2];
                        rightButtonTargetMathEquationText.text = rightButtonTargetAnswerTrial[2][3];
                    }

                    misc.text += "scaleValue: " + scaleValue + "\n";


                    targetButton = "targetRightButton";
                    misc.text += "targetButton name: " + targetButton + "\n";
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
                    misc.text = "left.count, mid.count, right.count: " + buttonLeftList.Count + "," + buttonMidList.Count + "," + buttonRightList.Count + "\n";
                    buttonTargetListLength = buttonLeftList.Count; // Updating the length of the button target list
                    misc.text += "buttonTargetListLength: " + buttonLeftList.Count + "\n";
                    // Finding an unused scale of target button list
                    randomScale = Random.Range(0, buttonTargetListLength);
                    misc.text += "randomScale: " + randomScale + "\n";
                    scaleValue = buttonLeftList[randomScale];
                    misc.text += "scaleValue: " + scaleValue + "\n";

                    randomMathEquation = Random.Range(0, buttonTargetListLength);
                    randomMathEquationValue = leftButtonTargetAnswerReal[randomMathEquation];

                    realCanvasText.text = "Press the button with the correct answer: \n" +
                                         $"{randomMathEquationValue[0]}";
                    leftButtonTargetMathEquationText.text = randomMathEquationValue[1];
                    midButtonTargetMathEquationText.text = randomMathEquationValue[2];
                    rightButtonTargetMathEquationText.text = randomMathEquationValue[3];

                    buttonLeftList.RemoveAt(randomScale); // Removing the scale value from the list.
                    leftButtonTargetAnswerReal.RemoveAt(randomMathEquation);
                    misc.text += "buttonLeftList count, leftButtonTargetAnswerReal count: " + buttonLeftList.Count + "," + leftButtonTargetAnswerReal.Count + "\n";

                    targetButton = "targetLeftButton";
                    misc.text += "targetButton name: " + targetButton + "\n";
                    break;
                }
                else if (buttonTarget == 1 && buttonMidList.Count != 0)
                {
                    misc.text = "left.count, mid.count, right.count: " + buttonLeftList.Count + "," + buttonMidList.Count + "," + buttonRightList.Count + "\n";
                    buttonTargetListLength = buttonMidList.Count; // Updating the length of the button target list
                    misc.text += "buttonTargetListLength: " + buttonMidList.Count + "\n";
                    // Finding an unused scale of target button list
                    randomScale = Random.Range(0, buttonTargetListLength);
                    misc.text += "randomScale: " + randomScale + "\n";
                    scaleValue = buttonMidList[randomScale];
                    misc.text += "scaleValue: " + scaleValue + "\n";

                    randomMathEquation = Random.Range(0, buttonTargetListLength);
                    randomMathEquationValue = midButtonTargetAnswerReal[randomMathEquation];

                    realCanvasText.text = "Press the button with the correct answer: \n" +
                                         $"{randomMathEquationValue[0]}";
                    leftButtonTargetMathEquationText.text = randomMathEquationValue[1];
                    midButtonTargetMathEquationText.text = randomMathEquationValue[2];
                    rightButtonTargetMathEquationText.text = randomMathEquationValue[3];

                    buttonMidList.RemoveAt(randomScale); // Removing the scale value from the list.
                    midButtonTargetAnswerReal.RemoveAt(randomMathEquation);
                    misc.text += "buttonMidList count: " + buttonMidList.Count + "\n";

                    targetButton = "targetMidButton";
                    misc.text += "targetButton name: " + targetButton + "\n";
                    break;
                }
                else if (buttonTarget == 2 && buttonRightList.Count != 0)
                {
                    misc.text = "left.count, mid.count, right.count: " + buttonLeftList.Count + "," + buttonMidList.Count + "," + buttonRightList.Count + "\n";
                    buttonTargetListLength = buttonRightList.Count; // Updating the length of the button target list
                    misc.text += "buttonTargetListLength: " + buttonRightList.Count + "\n";
                    // Finding an unused scale of target button list
                    randomScale = Random.Range(0, buttonTargetListLength);
                    misc.text += "randomScale: " + randomScale + "\n";
                    scaleValue = buttonRightList[randomScale];
                    misc.text += "scaleValue: " + scaleValue + "\n";

                    randomMathEquation = Random.Range(0, buttonTargetListLength);
                    randomMathEquationValue = rightButtonTargetAnswerReal[randomMathEquation];

                    realCanvasText.text = "Press the button with the correct answer: \n" +
                                         $"{randomMathEquationValue[0]}";
                    leftButtonTargetMathEquationText.text = randomMathEquationValue[1];
                    midButtonTargetMathEquationText.text = randomMathEquationValue[2];
                    rightButtonTargetMathEquationText.text = randomMathEquationValue[3];

                    buttonRightList.RemoveAt(randomScale); // Removing the scale value from the list.
                    rightButtonTargetAnswerReal.RemoveAt(randomMathEquation);
                    misc.text += "buttonRightList count: " + buttonRightList.Count + "\n";

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
        }
        // Showing the buttons
        foreach (var button in buttons)
        {
            button.SetActive(true);
        }
        handMovementScaler.ActivateScaling(rightHandAnchor.position, scaleValue); // Setting warp origin + activating scaling
    }
    public void StepTwoFalse()
    {
        step2 = false;
        handMovementScaler.DeActivateScaling();
        // Not showing the buttons
        foreach (var button in buttons)
        {
            button.SetActive(false);
        }

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

    public bool RightWrongButton(string buttonTargetName)
    {
        misc.text += "targetButton and buttonTargetName: " + targetButton + "," + buttonTargetName + "," + (targetButton == buttonTargetName);
        if (targetButton == buttonTargetName)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
