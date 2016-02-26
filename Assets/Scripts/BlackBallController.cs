using UnityEngine;
using System.Collections;

public class BlackBallController : MonoBehaviour {

	// Use this for initialization

	Vector3 initialPosition;
	void Start () {
	//todo: z kim ostatnio miałem kolizję, 
			//zapamiętam bo jak ta kula wpadnie to trzeba wiedzieć jak to interpretować
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public enum CollisionBlame
	{
		CUE_A, CUE_B, OTHER
	}

	public CollisionBlame collisionBlame;


	public void resetBall(){
		
		transform.position = initialPosition;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.transform.name.StartsWith ("Kula")) {
			// jest to zwykła kula gracza
			collisionBlame = CollisionBlame.OTHER;
		} else if (col.transform.name == "Bila Gracza A") {
			collisionBlame = CollisionBlame.CUE_A;
		} else if (col.transform.name == "Bila Gracza B") {
			collisionBlame = CollisionBlame.CUE_B;
		}

	}
}
