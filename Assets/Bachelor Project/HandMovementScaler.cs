using Oculus.VoiceSDK.UX;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class HandMovementScaler : MonoBehaviour
{
    public Transform vrHand; // Assign the Transform of OVRHandPrefab in the inspector
    public Transform realHand; // My actual hand

    private float gainFactor;

    private Vector3 warpOrigin;
    private bool buttonActivated = false;

    public TextMeshProUGUI realHandText; // Assign this in the inspector
    public TextMeshProUGUI vrHandText; // Assign this in the inspector
    public TextMeshProUGUI misc; // Assign this in the inspector

    private void Start()
    {
        //ActivateScaling(realHand.position, 2f);
    }
    void Update()
    {

        // Real Hand position / rightHandAnchor
        // Warp origin
        // Gain factor

        if (buttonActivated == true)
        {
            Vector3 unwarped = realHand.position - warpOrigin; // unwarped offset from origin
            Vector3 warped = gainFactor * unwarped; // warped offset from origin
            Vector3 finalWarped = warpOrigin + warped; // final warped position

            vrHand.position = finalWarped;
        }

        //realHandText.text = "Real Hand: " + realHand.position;
        //vrHandText.text = "warpOrigin: " + warpOrigin + "\n";
        //vrHandText.text += "VR hand: " + vrHand.position;


    }

    public void ActivateScaling(Vector3 origin, float scale)
    {
        warpOrigin = origin;
        gainFactor = scale;
        buttonActivated = true;
        //misc.text += "ActivateScaling";
    }

    public void DeActivateScaling()
    {
        buttonActivated = false;
    }
}
