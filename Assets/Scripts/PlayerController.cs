using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GUIText countText;
	public GUIText winText;

	private int count;

	void Start(){
		count = 0;
		winText.text = "";
		UpdateCountText();
	}

	void FixedUpdate ()
	{
		var moveHorizontal = Input.GetAxis ("Horizontal");
		var moveVertical = Input.GetAxis ("Vertical");

		var movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	private void UpdateCountText(){
		countText.text = "Count: " + count;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PickUp"){
			other.gameObject.SetActive(false);
			count++;
			UpdateCountText();
		}

		if(count >= 9)
			winText.text = "You win!";
	}
}
