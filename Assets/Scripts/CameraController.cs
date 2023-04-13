using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Programmer: Holly, with help from ChatGPT.

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothing = 0.5f;
    private Vector3 offset;
    private Vector3 location;
    

    void Start()
    {
        location = transform.position;
        offset = location - player.position;
    }

    void FixedUpdate()
    {
        Vector3 target = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);
    }
}
