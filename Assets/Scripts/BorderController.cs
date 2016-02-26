using UnityEngine;
using System.Collections;

public class BorderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
		{
			var m = child.GetComponent<Renderer>().material;

			if (child.name == "floor") {
				child.GetComponent<MeshRenderer> ().enabled = false;
			} else {
				Color c = m.color;
				//c.a = 0.2f;
				m.color = c;
			}

		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
