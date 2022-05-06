using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerPosition;
    private Vector3 cameraPosition;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = transform.position;
        cameraPosition.x = playerPosition.position.x;
        transform.position=cameraPosition;
    }
}
