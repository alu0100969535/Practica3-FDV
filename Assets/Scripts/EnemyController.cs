using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float targetDistance;


    private bool shouldMove = false;
    private Vector3 movingDirection;

    private Rigidbody rigidbody;

    void Start() {
        if(target == null) {
            Debug.LogError("EnemyController needs a target to pursue");
        }
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        FollowTarget();
    }

    /*private void FixedUpdate() {
        if(shouldMove) {
            rigidbody.AddForce(movingDirection * speed * Time.fixedDeltaTime);
            shouldMove = false;
        }
    }*/

    void FollowTarget() {
        var direction = target.position - gameObject.transform.position;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotationSpeed);

        if (direction.magnitude > targetDistance) {
            shouldMove = true;
            movingDirection = direction.normalized;
            Move(movingDirection);
        }
    }

    void Move(Vector3 direction) {
        var position = rigidbody.position;
        var movement = direction * speed * Time.deltaTime;

        rigidbody.position = position + movement;
    }
}
