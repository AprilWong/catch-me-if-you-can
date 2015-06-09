using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 moveDirection = new Vector3 (h, 0, v);
		moveDirection = transform.TransformDirection (moveDirection);

		controller.Move (moveDirection * Time.deltaTime);


	}
}
