using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class HandMovementScaler : MonoBehaviour
{
    public Transform handPrefabTransform; // Assign the Transform of OVRHandPrefab in the inspector
    public Transform rightHandAnchor; // My actual hand
    private Vector3 lastHandPosition;
    
    Vector3 handOffset = new Vector3 (0, 0, 0f);
    int counter = 1;
    public float movementThreshold = 0.5f; // Threshold for movement
    
    public Text debugText; // Reference to your text component

    private void Start()
    {
        lastHandPosition = handPrefabTransform.position;
    }
    void Update()
    {

        Vector3 currentHandPosition = handPrefabTransform.position;
        //Vector3 movementDelta = currentHandPosition - lastHandPosition;
        //Vector3 scale = movementDelta * 2f; // 2f is the test scale value, so when moving in real life, then virtual hand moves 2x faster.

        //handPrefabTransform.position = rightHandAnchor.position * 2f;
        handPrefabTransform.position = new Vector3(rightHandAnchor.position.x, rightHandAnchor.position.y, rightHandAnchor.position.z * 2f);

        //lastHandPosition = handPrefabTransform.position;

        if (counter == 1)
        {
            debugText.text = "currentHandPosition:   " + handPrefabTransform.position + "\n";
            debugText.text += "righthandanchor.position:   " + rightHandAnchor.position + "\n";
            //counter++;
        }
    }
}
