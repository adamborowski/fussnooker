using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageController : MonoBehaviour {

	Text text;
	TimeDurationLock locker;
	float defaultDuration = 2f;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		locker = new TimeDurationLock (defaultDuration, TimeDurationLock.LockMode.RESET);
	}
	
	// Update is called once per frame
	void Update () {
		if (locker.isLocked ()) {
			text.enabled = true;
		} else {
			text.enabled = false;
		}
	}

	public void setText(string text, float seconds){
		this.text.text = text;
		locker.setLock (seconds);
	}

	public void setText(string text){
		setText (text, defaultDuration);
	}
}
