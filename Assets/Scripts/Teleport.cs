using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    [SerializeField]
    private Transform teleportTo;

    private Vector3 actualPosition;

    void Awake() {
       if(teleportTo == null) {
            Debug.LogError("Must specify a pivot to teleport to.");
        }

        actualPosition = teleportTo.position;
        actualPosition.y += 5;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Preparing to tp @" + actualPosition);
    }

    private void OnTriggerStay(Collider other) {
        other.gameObject.GetComponent<Rigidbody>().position = actualPosition;  
    }

}
