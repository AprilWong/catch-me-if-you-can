using UnityEngine;
using System.Collections;

public class objectDiscover : MonoBehaviour {

	public float glazeSeconds = 0.5f;

	private CardboardHead head;
	private float timer;
	public string instruction;
	public string instruction_deep;
	string text;
	public bool is_trigger;
	public bool discovered;
	GameObject Text;


	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController> ().Head;
		timer = 0;
		Text = GameObject.Find ("Text");
		text = instruction;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);

		if (isLookedAt) {
			timer += Time.deltaTime;

			if(Input.GetMouseButtonDown(0)){
				discovered = true;
				text = instruction_deep;
			}

			if(timer>=glazeSeconds){
				Text.GetComponent<instructionText>().ChangeText(text);
			}
		}
		else{
			text = instruction;
			timer = 0;
		}
	
	}
}
