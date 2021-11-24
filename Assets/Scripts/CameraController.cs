using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private Transform camera;
    [SerializeField] private float distance;
    [SerializeField] private float rotationSpeed;


    public Transform  CameraTransform {
        get { return camera; }
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        float h = rotationSpeed * Input.GetAxis("Mouse X");

        transform.position = target.position;

        camera.RotateAround(target.position, Vector3.up, Time.deltaTime * h);

    }
}
