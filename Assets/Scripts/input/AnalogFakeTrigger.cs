using System;

namespace AssemblyCSharp
{
	public class AnalogFakeTrigger
	{
		private float upIncr;
		public AnalogFakeTrigger (float upIncr=0.05f)
		{
			this.upIncr = upIncr;
		}

		private float value=0;

		public void Update(bool pressed){
			if (pressed) {
				value += upIncr;
			} else {
				value = 0;
			}
			if (value > 1) {
				value = 1;
			}
		}

		public float GetValue(){
			return value;
		}
	}
}

