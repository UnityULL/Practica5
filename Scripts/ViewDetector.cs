using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ViewDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Get the trigger created in the inspector
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry {

            eventID = EventTriggerType.PointerEnter
        };

        entry.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerEnter(PointerEventData data) {
        GameController.Shake();
    }
}
