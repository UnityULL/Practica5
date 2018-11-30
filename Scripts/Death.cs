using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Death : MonoBehaviour {

    private PlayerPower player;
    private Animator animator;
    private float animationDeathTime;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animationDeathTime = 4.0f; // TODO: replace this time for the correct death time animation, need to find it

        player = GameObject.FindWithTag("Player").GetComponent<PlayerPower>();

        // Get the trigger created in the inspector
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry death = new EventTrigger.Entry();

        // Register point enter event
        death.eventID = EventTriggerType.PointerEnter;
        death.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
        trigger.triggers.Add(death);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P))
            DestroyGameObject();
    }
    public void OnPointerEnter(PointerEventData data) {
        DestroyGameObject();
    }

    public void DestroyGameObject() {
        if (!player.HasPower()) {
            animator.SetBool("death", true);
            Destroy(gameObject, animationDeathTime);
        }
     }
}
