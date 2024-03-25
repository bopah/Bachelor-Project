using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<float> scales = new List<float> { 1.0f, 1.1f, 1.25f, 1.4f, 1.55f, 1.7f, 1.85f, 2.0f, 0.909f, 0.8f, 0.714f, 0.645f, 0.588f, 0.54f, 0.5f};
    
    public GameObject[] buttons; // Assign all buttons in inspector
    private List<float> buttonLeftList = new List<float> { };
    private List<float> buttonMidList = new List<float> { };
    private List<float> buttonRightList = new List<float> { };

    //public GameObject canvas;
    //public Text canvasText;

    public Transform rightHandAnchor; // position of my real hand
    public HandMovementScaler handMovementScaler;

    private bool trial = true;
    private int trialNumber = 1;

    public TextMeshProUGUI trialYesNoText; // Assign this in the inspector

    public TextMeshProUGUI trialCanvasText; // Assign this in the inspector
    public TextMeshProUGUI realCanvasText; // Assign this in the inspector

    public GameObjectManager gameObjectManager;

    private bool step1 = true;
    private bool step2 = false;
    private bool step3 = false;




    void Start()
    {
        //int randomNumber = Random.Range(0, 3); // 3 is exclusive

    }


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

    }
    public void StepOneFalse()
    {
        step1 = false;
        gameObjectManager.DeactivateTransparentCube();
        step2 = true;
    }

    public void StepTwoTrue()
    {
        //int randomNumber = Random.Range(0, 3); // 3 is exclusive
        buttons[0].SetActive(true);
        handMovementScaler.ActivateScaling(rightHandAnchor.position, 3f); // Setting warp origin + activating scaling
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
}
