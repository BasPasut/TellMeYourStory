using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagAlongUI2 : MonoBehaviour
{
    [Tooltip("Offset x-axis of tagAlong center point")]
    public float OffSetX;

    [Tooltip("Offset y-axis of tagAlong center point")]
    public float OffSetY;

    [Tooltip("Sphere radius.")]
    public float SphereRadius = 1.0f;

    [Tooltip("How fast the object will move to the target position.")]
    public float MoveSpeed = 2.0f;

    [Tooltip("When moving, use unscaled time. This is useful for games that have a pause mechanism or otherwise adjust the game timescale.")]
    public bool UseUnscaledTime = true;

    [Tooltip("Display the sphere in red wireframe for debugging purposes.")]
    public bool DebugDisplaySphere = false;

    [Tooltip("Display a small green cube where the target position is.")]
    public bool DebugDisplayTargetPosition = false;

    public float initialDistanceToCamera;

    public float maxDetectDistance;

    public float snapDeley = 0.3f;

    //Test
    public bool LookAtCamera;
    public Transform displayCamera;
    private bool tagAlong = true;
    private GameObject otherObject;
    public GameObject menu;
    //Test

    private Vector3 targetPosition;
    private Vector3 optimalPosition;

    public Transform OffsetTransform;
    
    void Start()
    {
        //initialDistanceToCamera = Vector3.Distance(this.transform.position, displayCamera.transform.position);
    }

    void Update()
    {
        RaycastHit hit;
        Ray detectWall = new Ray(displayCamera.transform.position, displayCamera.transform.forward*maxDetectDistance);

        bool detected = Physics.Raycast(detectWall, out hit, maxDetectDistance, 1 << LayerMask.NameToLayer("Wall"));

        if (detected)
        {
            TagAlongOnWall(hit);
        }
        else
        {
            Debug.DrawRay(displayCamera.transform.position, displayCamera.transform.forward * maxDetectDistance, Color.red);
            TagAlong();
        }
    }

    public void TagAlong()
    {
        this.transform.LookAt(displayCamera); //Test

        optimalPosition = displayCamera.transform.position + displayCamera.transform.forward * initialDistanceToCamera;

        OffsetTransform.transform.position = optimalPosition;
        OffsetTransform.LookAt(displayCamera);
        //Debug.Log("OP : " + optimalPosition + " OF : " + OffsetTransform.position);
        OffsetTransform.transform.localPosition = new Vector3(OffsetTransform.localPosition.x + OffSetX, OffsetTransform.localPosition.y + OffSetY, OffsetTransform.localPosition.z);

        optimalPosition = OffsetTransform.position;

        Vector3 offsetDir = this.transform.position - optimalPosition;
        if (offsetDir.magnitude > SphereRadius)
        {
            targetPosition = optimalPosition + offsetDir.normalized * SphereRadius;

            float deltaTime = UseUnscaledTime
                ? Time.unscaledDeltaTime
                : Time.deltaTime;

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, MoveSpeed * deltaTime);
        }
    }

    public void TagAlongOnWall(RaycastHit wallHit)
    {
        targetPosition = wallHit.point + wallHit.normal * 0.1f;

        float deltaTime = UseUnscaledTime
            ? Time.unscaledDeltaTime
            : Time.deltaTime;

        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, MoveSpeed * deltaTime);
        Quaternion snapRotation = Quaternion.LookRotation(wallHit.normal, wallHit.transform.up);
        menu.transform.rotation = Quaternion.Slerp(this.transform.rotation, snapRotation, MoveSpeed * deltaTime);
    }

    public void OnDrawGizmos()
    {
        if (Application.isPlaying == false) return;

        Color oldColor = Gizmos.color;

        if (DebugDisplaySphere)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(optimalPosition, SphereRadius);
            
        }

        if (DebugDisplayTargetPosition)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(targetPosition, new Vector3(0.1f, 0.1f, 0.1f));
        }

        Gizmos.color = oldColor;
    }
}
