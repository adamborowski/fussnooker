using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
	Text textField;

	// Use this for initialization
	void Start ()
	{
		textField = infoText.GetComponent<Text> ();
		renderScore ();
	}

	bool winA = false;
	bool winB = false;
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	int scoreA = 0;
	int scoreB = 0;
	int maxScore = 7;


	void OnScore (string player)
	{
		
		if (player == "A") {
			scoreA++;
		} else {
			scoreB++;
		}

		if (player == "A") {
			if (scoreA < maxScore) {
				messageA.GetComponent<MessageController> ().setText ("GOOL!");
			} else {
				messageA.GetComponent<MessageController> ().setText ("WBIJ CZARNĄ");
			}
		}
		if (player == "B") {
			if (scoreB < maxScore) {
				messageB.GetComponent<MessageController> ().setText ("GOOL!");
			} else {
				messageB.GetComponent<MessageController> ().setText ("WBIJ CZARNĄ");
			}
		}
		renderScore ();
	}


	public void OnBlackScore (PotController.BlackBlame blackBlame)
	{
		
		if (scoreA == maxScore && scoreB < maxScore) {
			scoreA++;
			winA = true;
		} else if (scoreA < maxScore && scoreB == maxScore) {
			scoreB++;
			winB = true;
		} else if (scoreA == maxScore && scoreB == maxScore) {
			//
			if (blackBlame.blame == BlackBallController.CollisionBlame.CUE_A) {
				scoreA++;
				winA = true;
			} else if (blackBlame.blame == BlackBallController.CollisionBlame.CUE_B) {
				scoreB++;
				winB = true;
			} else {
				// uderzyło coś poza bilami, a tylko bile zostały - przypadek niemożliwy
				Debug.LogError ("Impossible case");
			}
		} else {
			//nikt jeszcze nie skończył
			if (blackBlame.blame == BlackBallController.CollisionBlame.CUE_A) {
				//gracz A wbił zespośrednio, kara dla niego
				winB = true;
			} else if (blackBlame.blame == BlackBallController.CollisionBlame.CUE_B) {
				//gracz B wbił bezpośrednio, kara dla niego
				winA = true;
			}
		}

		if (winA || winB) {
			Destroy (blackBlame.ball);
		} else {
			blackBlame.ball.GetComponent<BlackBallController> ().resetBall ();
		}

		renderScore ();
		Debug.Log ("black score, blame: " + blackBlame.blame);
	}

	private void renderScore ()
	{
		if (winA || winB) {
			textField.text = scoreA + " : " + scoreB;
			winText.gameObject.SetActive (true);

			winText.FindChild ("Text").GetComponent<Text> ().text = "Czarna wbita\nwygrał gracz " + (winA ? "A" : "B");
		} else {
			winText.gameObject.SetActive (false);
			textField.text = scoreA + " : " + scoreB;
		}
	}

	public Transform infoText;
	public Transform winText;
	public Transform messageA;
	public Transform messageB;
}
