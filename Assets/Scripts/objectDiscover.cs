using UnityEngine;
using System.Collections;

public class objectDiscover : MonoBehaviour {

	public float glazeSeconds = 0.5f;

	private CardboardHead head;
	private float timer;
	public string instruction;
	GameObject Text;


	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController> ().Head;
		timer = 0;
		//instruction = GetComponent<>();
		Text = GameObject.Find ("Text");
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);

		if (isLookedAt) {
			timer += Time.deltaTime;
			if(timer>=glazeSeconds){
				Text.GetComponent<instructionText>().ChangeText(instruction);
			}
		}
		else{
				timer = 0;
		}
	
	}
}
