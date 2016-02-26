using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class StatefulAxis
	{
		private float maxValue;

		private float value;
		private float prevValue;
		private float prevPrevValue;

		public StatefulAxis ()
		{
		}

		public void resetMaxValue ()
		{
			maxValue = 0;
		}

		public float getValue ()
		{
			return value;
		}

		public float getMaxValue(){
			return maxValue;
		}

		public void update (float newValue)
		{
			prevPrevValue = prevValue;
			prevValue = value;
			value = newValue;
			maxValue = Mathf.Max (maxValue, newValue);
			if (releaseEnded ()) {//użytkownik puścił przycisk, reset max
				resetMaxValue ();
			}
		}

		public bool pressStarted ()
		{
			return prevValue == 0 && value > 0;
		}

		public bool pressEnded ()
		{
			return prevValue < 1 && value == 1;
		}

		public bool pressCancelled ()
		{
			return prevPrevValue <= prevValue && prevValue > value;
		}

		public bool releaseStarted ()
		{
			return prevValue == 1 && value < 1;
		}

		public bool releaseEnded ()
		{
			return prevValue > 0 && value == 0;
		}

		public bool isInProgress ()
		{
			return value > 0 && value < 1;
		}

		public bool isUp ()
		{
			return value == 0;
		}

		public bool isDown ()
		{
			return value == 1;
		}
	}
}

