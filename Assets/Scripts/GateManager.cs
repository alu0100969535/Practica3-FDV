using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

    [SerializeField] GameObject pickablesParent;
    [SerializeField] List<Gate> gates;

    private int picked = 0;

    // Start is called before the first frame update
    void Start() {
        if(pickablesParent == null) {
            Debug.LogError("GateManager needs a set of pickables.");
            return;
        }
        
        if(gates == null || gates.Count == 0) {
            Debug.LogError("GateManager needs a set of gates to open.");
            return;
        }

        var pickables = pickablesParent.GetComponentsInChildren<Pickable>();
        foreach (var pickable in pickables) {
            pickable.onPickupEvent += onPickupHandler;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void openGate(int index) {
        gates[index].Open();
    }

    void onPickupHandler() {
        openGate(picked);
        picked++;
        Debug.Log(picked);
    }
}
