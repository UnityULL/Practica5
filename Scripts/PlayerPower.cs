using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour {
    private bool power;
	// Use this for initialization
	void Start () {
        power = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool HasPower() {
        return power;
    }

    public void SetPower(bool newValue) {
        power = newValue;
    }
}
