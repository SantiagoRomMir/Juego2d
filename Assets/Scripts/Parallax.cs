using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    public float effectParallax;
    private Transform camera;
    private Vector3 lastPositionCamera;
    void Start()
    {
        camera = Camera.main.transform;
        lastPositionCamera = camera.position;
    }
    void LateUpdate()
    {
        Vector3 distance = camera.position - lastPositionCamera;
        transform.position += new Vector3(effectParallax * distance.x, distance.y, 0);
        lastPositionCamera = camera.position;
    }
}
