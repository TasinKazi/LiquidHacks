using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamMove : MonoBehaviour //this updates the movement of the player camera to where the player actually is.
{
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
