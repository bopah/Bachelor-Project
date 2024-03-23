using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    // References to individual GameObjects. Assign these in the Unity Editor.
    public GameObject trialCanvas;
    public GameObject reaLcanvas;
    public GameObject trialYesNo;
    public GameObject realYesNo;
    public GameObject transparentCube;

    // Functions to activate each GameObject
    public void ActivateTrialCanvas() { trialCanvas.SetActive(true); }
    public void ActivateRealCanvas() { reaLcanvas.SetActive(true); }
    public void ActivateTrialYesNo() { trialYesNo.SetActive(true); }
    public void ActivateRealYesNo() { realYesNo.SetActive(true); }
    public void ActivateTransparentCube() { transparentCube.SetActive(true); }

    // Functions to deactivate each GameObject
    public void DeactivateTrialCanvas() { trialCanvas.SetActive(false); }
    public void DeactivateRealCanvas() { reaLcanvas.SetActive(false); }
    public void DeactivateTrialYesNo() { trialYesNo.SetActive(false); }
    public void DeactivateRealYesNo() { realYesNo.SetActive(false); }
    public void DeactivateTransparentCube() { transparentCube.SetActive(false); }
}
