using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Pickable : MonoBehaviour {


    public delegate void OnPickup();
    public OnPickup onPickupEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        gameObject.SetActive(false);
        if(onPickupEvent != null) {
            onPickupEvent();
        }

    }
}
