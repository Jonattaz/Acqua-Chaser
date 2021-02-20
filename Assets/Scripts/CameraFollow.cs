using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject player;
    private Vector3 offset = new Vector3(-14, 131, -29);


    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    // Causes the camera to follow the player
    private void Follow()
    {
        transform.position = player.transform.position + offset;
    }
}
