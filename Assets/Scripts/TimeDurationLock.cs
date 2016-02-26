using UnityEngine;
using System.Collections;

public class TimeDurationLock
{

	public TimeDurationLock (float defaultDuration)
	{
		this.defaultDuration = defaultDuration;
	}

	public TimeDurationLock (float defaultDuration, LockMode lockMode)
	{
		this.defaultDuration = defaultDuration;
		this.lockMode = lockMode;
	}


	public enum LockMode
	{
		CUMULATIVE,
		MAXIMUM,
		RESET}

	;

	private float defaultDuration;
	private LockMode lockMode = LockMode.MAXIMUM;
	private float lastUnlockTime = 0;

	public bool isLocked ()
	{
		return Time.time < lastUnlockTime;
	}

	public bool isNotLocked ()
	{
		return !isLocked ();
	}

	public void setLock ()
	{
		setLock (defaultDuration);
	}


	public void setLock (float duration)
	{
		float newUnlockTime = Mathf.Max (lastUnlockTime, Time.time);
		switch (lockMode) {
		case LockMode.CUMULATIVE:
			newUnlockTime += duration;
			break;
		case LockMode.MAXIMUM:
			newUnlockTime = Mathf.Max (newUnlockTime, Time.time + duration);
			break;
		case LockMode.RESET:
			newUnlockTime = Time.time + duration;
			break;
		}
		lastUnlockTime = newUnlockTime;
	}


}
