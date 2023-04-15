using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetLocation : MonoBehaviour
{
    // Public Declarations
    public Transform playerReference;
    public Image indicatorReference;
    public List<Transform> targetList;
    public Camera cameraTarget;
    // Private Declarations
    private Vector3 indicatorVector;
    private TMPro.TMP_Text textReference;
    private int targetRange;
    private int targetIndex;
    private bool targetValidated;
    // --
    void Awake()
    {
        // Store Indicator Text Object Reference
        textReference = indicatorReference.GetComponentInChildren<TMPro.TMP_Text>();
    }
    // --
    void Start()
    {
        // Set Default Values
        targetIndex = 0;
        targetRange = 5;
        // Validate Target List Count
        targetValidated = targetList.Count > 0;

    }
    // --
    void LateUpdate()
    {
        // Check Player Status
        if (targetValidated)
        {
            if (LinearDistance(playerReference.position, targetList[targetIndex].position) < targetRange)
            {
                targetIndex = (targetIndex + 1) % targetList.Count;
            }
            // Update Indicator Position
            UpdateTargetSystem(targetIndex);
        }
        else
        {
            indicatorReference.gameObject.SetActive(false);
        }
    }
    // --
    public void UpdateTargetSystem(int index)
    {
        if (targetValidated)
        {
            // Set Indicator Status
            indicatorReference.gameObject.SetActive(RelativePosition(playerReference, targetList[index]));
            // Check Indicator Active Flag
            if (targetList[index].gameObject.activeInHierarchy)
            {


                // Update Distance Text
                textReference.text = LinearDistance(playerReference.position, targetList[index].position) + "m";
                // Update Indicator Rect Transform Position
                indicatorVector = indicatorReference.rectTransform.anchorMin;
                indicatorVector.x = cameraTarget.WorldToViewportPoint(targetList[index].position).x;
                indicatorVector.y = cameraTarget.WorldToViewportPoint(targetList[index].position).y;
                indicatorVector.z = cameraTarget.WorldToViewportPoint(targetList[index].position).z;
                indicatorReference.rectTransform.anchorMin = indicatorVector;
                indicatorReference.rectTransform.anchorMax = indicatorVector;
            }
        }

    }
    // --
    public int LinearDistance(Vector3 playerPosition, Vector3 targetPosition)
    {
        // Zero YAxis
        playerPosition.y = 0;
        targetPosition.y = 0;
        // Return Linear Distance
        return Mathf.RoundToInt(Vector3.Distance(playerPosition, targetPosition));
    }
    // --
    private bool RelativePosition(Transform player, Transform target)
    {
        // Calculate Relavtive Position
        return Vector3.Dot(Vector3.forward, player.InverseTransformPoint(target.position).normalized) > 0;
    }
}
