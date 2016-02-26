using UnityEngine;
using System.Collections;

public class PotController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	public class BlackBlame{
		public BlackBallController.CollisionBlame blame{ get; set; }
		public GameObject	 ball{ get; set; }
	}

	void OnCollisionEnter (Collision col)
	{
//		Debug.LogWarning ("collision occured: " + col.gameObject.name);
		if (col.gameObject.name == "Czarna Kula") {
			// wpada czarna kula, trzeba sprawdzić, kto ostatni dotknął
			var blame = col.transform.GetComponent<BlackBallController>().collisionBlame;

			this.SendMessageUpwards("OnBlackScore", new BlackBlame(){ball=col.gameObject, blame=blame});
		}
		else if (!col.gameObject.name.Contains ("Bila Gracza")) {
			Destroy (col.gameObject);
			this.SendMessageUpwards ("OnScore", col.transform.parent.name == "Kule Gracza A" ? "A" : "B");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
