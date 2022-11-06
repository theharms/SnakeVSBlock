using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;   
    void Update()
    {
        Vector3 targetposition = transform.position;
        targetposition.z = Player.transform.position.z - 4;
        transform.position = targetposition;
    }
}
