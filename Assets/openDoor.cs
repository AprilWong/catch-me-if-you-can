using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

	public GameObject door;
	public bool unlock_door;
	public bool open_door;
	public float glazeSeconds = 0.5f;
	private CardboardHead head;
	private float timer;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController> ().Head;
		timer = 0;
		unlock_door = true;
		open_door = false;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
		
		if (isLookedAt) {
			//print("AAAA");
			timer += Time.deltaTime;
			if(timer>=glazeSeconds){
				opendoor();
			}
		}
		else{
			timer = 0;
		}
	}

	void opendoor(){
		if (unlock_door & (!open_door)) {
			print ("now open the door!");
			door.GetComponent<Animation>().Play();
			open_door=true;
		}
	}
}
