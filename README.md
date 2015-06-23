#基于Google Cardboard SDK与Unity5的虚拟现实密室逃脱游戏开发


**王奕**

**3130000059**

##游戏介绍
虚拟现实是当下一大热点。2014年Google I/O发布了Google Cardboard，成本只有两美元的3D眼镜，只需要简单的组装即可将智能手机变成一个虚拟现实的原型设备。Catch me if you can 正是这么一个简单的虚拟现实密室逃脱类游戏，使用 Google cardboard SDK，基于Unity5.0开发。玩家需要在规定的时间内按照剧情顺序找到密室出口。


##游戏规则
玩家需要在规定的时间内按照剧情顺序找到密室出口。玩家从梦境中醒来，发现己身处在一间小木屋里，木屋的门被锁住了，窗户也被封住了，玩家需要根据剧情发展在屋子中找到相应的道具，解锁木屋的门。首先，玩家需要从床头柜中获得带锁的笔记本，锁是五层同心圆，玩家只有三次机会，如果失误的话木屋会爆炸，游戏就会结束。玩家需要打开风扇，风扇会显示同心圆图案。将对应的图案输入笔记本的锁，即可打开笔记本，显示“Catch me if you can”。同时，玩家需要关闭电灯，此时再打开笔记本，就能读到屋子的主人生前的日记，获得线索——主人的生日。在书架上找到一个保险箱，输入主人的生日，即可打开保险箱，找到开门的钥匙。然而，这一切只是一个开始，所有的故事都是未解之谜……
为了增加游戏难度，场景中加入了一些混淆视听的互动装置，比如枕头可以被移开，书架上的书都能被打开等等。
游戏的操作方式也比较简单，玩家通过Cardboard控制视角，通过手柄操作人物位置的移动。通过Cardboard上的物理按键控制与物体的交互。

##游戏实现

1. 玩家的控制与移动

playermovement.cs

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

2. 玩家视线与场景中物体的互动

objectDiscover.cs

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




