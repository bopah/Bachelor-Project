using UnityEngine;

public class AdjustChildPosition : MonoBehaviour
{
    public Transform canvasTransform; // Assign the canvas transform here
    public Transform[] childObjects; // Assign child objects here

    private float lastCanvasPosY;

    void Start()
    {
        // Initialize with the current canvas y-position
        lastCanvasPosY = canvasTransform.position.y;
    }

    void Update()
    {
        float currentCanvasPosY = canvasTransform.position.y;

        // Check if the y-position of the canvas has changed
        if (currentCanvasPosY != lastCanvasPosY)
        {
            float deltaY = currentCanvasPosY - lastCanvasPosY;

            foreach (var child in childObjects)
            {
                // Update child's y-position based on the canvas's y-position change
                Vector3 newPosition = child.position;
                newPosition.y += deltaY;
                child.position = newPosition;
            }

            lastCanvasPosY = currentCanvasPosY; // Update the last y-position
        }
    }
}
