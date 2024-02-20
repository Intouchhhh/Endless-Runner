using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform playerTransform; 
    public Vector3 offset; // adjustable offset from the player (in the inspector)

    void LateUpdate()
    {
        if (playerTransform != null)// check if player exists to avoid errors
        {
            transform.position = playerTransform.position + offset;
        }
    }
}
