using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	
	public float speed = 1f;
	private CardboardHead head;
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController> ().Head;
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();

		float h = - Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 moveDirection;
		Vector3 headDirection = head.Gaze.direction;
		Vector3 zCord = new Vector3 (0, 1, 0);
		Vector3 headvDirection = Vector3.Cross (headDirection, zCord);
		headDirection = transform.TransformDirection (headDirection);
		headvDirection = transform.TransformDirection (headvDirection);
		moveDirection = h * headvDirection + v * headDirection;
		moveDirection = transform.TransformDirection (moveDirection);


		controller.Move (moveDirection * Time.deltaTime);


	}
}
