using TMPro;
using UnityEngine;

public class IndexFingerBonePosition : MonoBehaviour
{
    public OVRSkeleton skeleton; // Assign this in the inspector
    private Transform indexBoneTransform = null;

    void Start()
    {
        // Find and cache the index finger bone transform
        foreach (var bone in skeleton.Bones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_Index3)
            {
                indexBoneTransform = bone.Transform;
                break;
            }
        }
    }

    void Update()
    {
        if (indexBoneTransform != null)
        {
            // Update the GameObject's position to match the index finger bone position
            transform.position = indexBoneTransform.position;
        }
    }
    
}
