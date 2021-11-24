using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gate : MonoBehaviour {

    private float targety = -20;
    private float speed = 0.001f;


    public void Open() {

        Vector3 target = new Vector3(transform.position.x, targety, transform.position.z);

        StartCoroutine(OpenInternal(target, () => {
            gameObject.SetActive(false);
        }));

    }

    private IEnumerator OpenInternal(Vector3 target, Action onFinish) {

        float t = 0;

        while(transform.position != target) {
            t += speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target, t);
            yield return null;
        }

        onFinish();
    }
}
