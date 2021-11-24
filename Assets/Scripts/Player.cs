using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private new Rigidbody rigidbody;

    [SerializeField] private float movementMultiplier = 1f;
    [SerializeField] private float jumpMultiplier = 1f;
    [SerializeField] private CameraController cameraController;

    private bool jumped;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        jumped = false;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        // Move with WASD
        float f = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Horizontal");
        bool up = Input.GetButton("Jump");

        Transform camera = cameraController.CameraTransform;
        Vector3 forward = (transform.position - camera.position).normalized;
        Vector3 left = Vector3.Cross(forward, Vector3.up).normalized;

        rigidbody.AddForce(forward * f * Time.fixedDeltaTime * movementMultiplier);
        rigidbody.AddForce(-left * r * Time.fixedDeltaTime * movementMultiplier);

        if(up && !jumped) {
            jumped = true;
            rigidbody.AddForce(Vector3.up * Time.fixedDeltaTime * jumpMultiplier);
        }

        if (!up) jumped = false;
    }
}
