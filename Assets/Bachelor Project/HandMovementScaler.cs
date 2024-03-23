using Oculus.VoiceSDK.UX;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class HandMovementScaler : MonoBehaviour
{
    public Transform handPrefabTransform; // Assign the Transform of OVRHandPrefab in the inspector
    public Transform rightHandAnchor; // My actual hand

    private float gainFactor;

    private Vector3 warpOrigin;
    private bool buttonActivated = false;


    void Update()
    {

        // Real Hand position / rightHandAnchor
        // Warp origin
        // Gain factor

        if (buttonActivated == true)
        {
            Vector3 unwarped = rightHandAnchor.position - warpOrigin; // unwarped offset from origin
            Vector3 warped = gainFactor * unwarped; // warped offset from origin
            Vector3 finalWarped = warpOrigin + warped; // final warped position

            handPrefabTransform.position = finalWarped;
        }
        
    }

    public void ActivateScaling(Vector3 origin, float scale)
    {
        warpOrigin = origin;
        gainFactor = scale;
        buttonActivated = true;
    }

    public void DeActivateScaling()
    {
        buttonActivated = false;
    }
}
