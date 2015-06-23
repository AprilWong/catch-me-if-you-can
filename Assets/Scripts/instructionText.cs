using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class instructionText : MonoBehaviour {

	public Text instruction;
	public string sth;

	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ChangeText(string sth){
		//print ("change!!");
		instruction.text = sth;
	}
}
