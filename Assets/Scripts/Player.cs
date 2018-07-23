using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	float speed = 10;
	public Text teksscore;
	public Text winText;

	private Rigidbody rb;
	private int score;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		teksscore.text = "Score : " + score.ToString ();
		winText.text = "";
	}

	void FixedUpdate () {
		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);*/

		Vector3 acc = Input.acceleration;
		rb.AddForce(acc.x * speed, 0, acc.y * speed);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Ambil")) {
			collider.gameObject.SetActive (false);
			score = score + 1;
			SetTeksScore ();
		}
	}

	void SetTeksScore() {
		teksscore.text = "Score: " + score.ToString ();
		if (score == 60) {
			winText.text = "Kamu Menang";
		}
	}
}
