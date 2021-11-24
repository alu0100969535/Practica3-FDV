using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurboButtonController : MonoBehaviour {

    private bool turboMode = false;
    [SerializeField]
    private UnityEngine.UI.Text text;

    [SerializeField]
    private string turboStr;
    [SerializeField]
    private string noTurboStr;

    public delegate void OnTurbo(bool active);
    public OnTurbo OnTurboEvent;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick() {
        turboMode = !turboMode;
        if(turboMode) { 
            text.text = turboStr;
        } else {
            text.text = noTurboStr;
        }

        if(OnTurboEvent != null){
            OnTurboEvent(turboMode);
        }

    }
}
