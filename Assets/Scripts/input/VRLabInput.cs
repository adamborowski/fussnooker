using System;
using XboxCtrlrInput;
using UnityEngine;


namespace AssemblyCSharp
{
	public class 	VRLabInput: AbstractInput
	{
		XboxButton SHOOT_BUTTON = XboxButton.A;
		XboxButton BRAKE_BUTTON = XboxButton.X;
		XboxButton RESET_BUTTON = XboxButton.B;

		private XboxController controller;

		public VRLabInput (XboxController controller)
		{
			this.controller = controller;
		}

		private String GetName(String name){
			int playerNum = (int)controller;
			return playerNum+"_"+name;
		}

		public Vector2 LeftKnob {
			get {
				return new Vector2 (Input.GetAxis (GetName("LeftAxisX")), -Input.GetAxis (GetName("LeftAxisY")));
			}
		}

		public Vector2 RightKnob {
			get {
				return new Vector2 (Input.GetAxis (GetName("RightAxisX")), -Input.GetAxis (GetName("RightAxisY")));
			}
		}

		public bool ShootButtonPressed {
			get {
				return XCI.GetButtonDown (SHOOT_BUTTON, controller);
			}
		}

		public bool ShootButtonReleased {
			get {
				return XCI.GetButtonUp (SHOOT_BUTTON, controller);
			}
		}

		public bool ShootButtonDown {
			get {
				return XCI.GetButton (SHOOT_BUTTON, controller);
			}
		}

		public bool BrakeButtonPressed {
			get {
				return XCI.GetButtonDown (BRAKE_BUTTON, controller);
			}
		}

		public bool BrakeButtonReleased {
			get {
				return XCI.GetButtonUp (BRAKE_BUTTON, controller);
			}
		}

		public bool BrakeButtonDown {
			get {
				return Input.GetButton (GetName ("Brake"));
			}
		}

		public bool ResetButtonPressed {
			get {
				return XCI.GetButtonDown (RESET_BUTTON, controller);
			}
		}

		public bool RightBumperPressed {
			get {
				return XCI.GetButtonDown (XboxButton.RightBumper, controller);
			}
		}

		public bool RightBumperReleased {
			get {
				return XCI.GetButtonUp (XboxButton.RightBumper, controller);
			}
		}

		public bool RightBumperDown {
			get {
				return Input.GetButton (GetName ("RT"));
			}
		}

		public bool LeftBumperPressed {
			get {
				return XCI.GetButtonDown (XboxButton.LeftBumper, controller);
			}
		}

		public bool LeftBumperReleased {
			get {
				return XCI.GetButtonUp (XboxButton.LeftBumper, controller);
			}
		}

		public bool LeftBumperDown {
			get {
				return Input.GetButton (GetName ("LT"));
			}
		}

		public bool DPadLeftButtonPressed {
			get {
				return XCI.GetButtonDown (XboxButton.DPadLeft, controller);
			}
		}

		public bool DPadLeftButtonReleased {
			get {
				return XCI.GetButtonUp (XboxButton.DPadLeft, controller);
			}
		}

		public bool DPadLeftButtonDown {
			get {
				return Input.GetAxis (GetName ("DPadX")) < 0;
			}
		}

		public bool DPadUpButtonPressed {
			get {
				return XCI.GetButtonDown (XboxButton.DPadUp, controller);
			}
		}

		public bool DPadUpButtonReleased {
			get {
				return XCI.GetButtonUp (XboxButton.DPadUp, controller);
			}
		}

		public bool DPadUpButtonDown {
			get {
				return Input.GetAxis (GetName ("DPadY")) < 0;
			}
		}

		public bool DPadRightButtonPressed {
			get {
				return XCI.GetButtonDown (XboxButton.DPadRight, controller);
			}
		}

		public bool DPadRightButtonReleased {
			get {
				return XCI.GetButtonUp (XboxButton.DPadRight, controller);
			}
		}

		public bool DPadRightButtonDown {
			get {
				return Input.GetAxis (GetName ("DPadX")) > 0;
			}
		}

		public bool DPadDownButtonPressed {
			get {
				return XCI.GetButtonDown (XboxButton.DPadDown, controller);
			}
		}

		public bool DPadDownButtonReleased {
			get {
				return XCI.GetButtonUp (XboxButton.DPadDown, controller);
			}
		}

		public bool DPadDownButtonDown {
			get {
				return Input.GetAxis (GetName ("DPadY")) > 0;
			}
		}

		// triggers

		public float LeftTrigger {
			get {
				return Input.GetButton (GetName ("LB"))?1:0;
			}
		}

		private AnalogFakeTrigger r = new AnalogFakeTrigger ();

		public float RightTrigger {
			get {
				r.Update(Input.GetButton(GetName("RB")));
				return r.GetValue ();
			}
		}

		public bool LeftStickDown {

			get {
				return XCI.GetButton (XboxButton.LeftStick, controller);
			}
		}

		public bool LeftStickPressed {

			get {
				return XCI.GetButtonDown (XboxButton.LeftStick, controller);
			}
		}

		public bool LeftStickReleased {

			get {
				return XCI.GetButtonUp (XboxButton.LeftStick, controller);
			}
		}

		public bool RightStickDown {

			get {
				return XCI.GetButton (XboxButton.RightStick, controller);
			}
		}

		public bool RightStickPressed {

			get {
				return XCI.GetButtonDown (XboxButton.RightStick, controller);
			}
		}

		public bool RightStickReleased {

			get {
				return XCI.GetButtonUp (XboxButton.RightStick, controller);
			}
		}

		public bool StartPressed{
			get{
				return Input.GetButtonDown (GetName ("Start"));
			}
		}

		public bool BackPressed{
			get{
				return Input.GetButtonDown (GetName ("Back"));
			}
		}
	}
}

