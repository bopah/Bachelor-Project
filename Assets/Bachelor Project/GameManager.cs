using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<float> scales = new List<float> { 1.0f, 1.1f, 1.25f, 1.4f, 1.55f, 1.7f, 1.85f, 2.0f, 0.909f, 0.8f, 0.714f, 0.645f, 0.588f, 0.54f, 0.5f};
    
    public GameObject[] buttons; // Assign all buttons in inspector
    private List<float> buttonLeftList = new List<float> { };
    private List<float> buttonMidList = new List<float> { };
    private List<float> buttonRightList = new List<float> { };

    public GameObject canvas;
    public Text canvasText;

    private bool trial = true;


    void Start()
    {
        int randomNumber = Random.Range(0, 3); // 3 is exclusive

    }


    void Update()
    {
        
    }
}
