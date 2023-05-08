using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePlatforms : MonoBehaviour
{
    [SerializeField]
    private float moveDistanceX = 2f;

    [SerializeField]
    private float moveDistanceY = 0f;

    [SerializeField]
    private float moveDistanceZ = 0f;

    [SerializeField]
    private float moveDuration = 1f;

    [SerializeField]
    private bool moveLeft = false;

    [SerializeField]
    private bool PlayerFollow = false;

    [SerializeField]
    private Ease easeType = Ease.Linear;

    [SerializeField]
    private LoopType loopType = LoopType.Yoyo;

    private void Start()
    {
        // Set up initial position
        Vector3 initialPosition = transform.position;

        // Calculate destination position based on direction and distances in X, Y, and Z
        float directionMultiplier = moveLeft ? -1f : 1f;
        Vector3 destinationPosition = initialPosition + new Vector3(moveDistanceX * directionMultiplier, moveDistanceY, moveDistanceZ);

        // Use DoTween library to move object from initial position to destination position
        transform.DOMove(destinationPosition, moveDuration)
            .SetEase(easeType)
            .SetLoops(-1, loopType);
    }


    void OnCollisionEnter(Collision col)
    {
        if (PlayerFollow == true) 
        { 
        col.gameObject.transform.SetParent(gameObject.transform, true);
        Debug.Log("Hello World");
        }
    }
    void OnCollisionExit(Collision col)
    {
        col.gameObject.transform.parent = null;
    }
}
