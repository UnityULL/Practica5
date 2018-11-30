using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Control the powers, on click it enables the power
public class PowerControl : MonoBehaviour {

    private PlayerPower player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerPower>();
        
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry button = new EventTrigger.Entry();
        // Register point enter event
        button.eventID = EventTriggerType.PointerClick;
        button.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        trigger.triggers.Add(button);
    }

    /** On button click, set power true or false, depending on current boolean state**/
    public void OnPointerClick(PointerEventData data) {
        if (player.HasPower()) {
            player.SetPower(false);
        } else
            player.SetPower(true);

    }
}
