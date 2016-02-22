using UnityEngine;
using System.Collections;

public class SlotSpinScript : MonoBehaviour {

	public int numberofimages;
	public Sprite[] slotassigner;
	public int speed;

	public GameObject reel1;
	public GameObject reel2;
	public GameObject reel3;

	bool donereel1;
	bool donereel2;
	bool donereel3;

	float mainreelx;
	float mainreely;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		mainreelx = gameObject.transform.position.x;
		mainreely = gameObject.transform.position.y;
		if (reel1.transform.position.y > (mainreely - 14)) {
			reel1.transform.Translate (0, (-speed * Time.deltaTime), 0);
		} else {
			donereel1 = true;
		}
		if (reel2.transform.position.y > (mainreely - 29)) {
			reel2.transform.Translate (0, (-speed * Time.deltaTime), 0);
		} else {
			donereel2 = true;
		}
		if (reel3.transform.position.y > (mainreely - 44)) {
			reel3.transform.Translate (0, (-speed * Time.deltaTime), 0);
		} else {
			donereel3 = true;
		}

		if (donereel1 == true) {
			reel1.transform.position = new Vector2(mainreelx, (mainreely - 14));
		}

		if (donereel2 == true) {
			reel2.transform.position = new Vector2(mainreelx + 1, (mainreely - 29));
		}

		if (donereel3 == true) {
			reel3.transform.position = new Vector2(mainreelx + 2, (mainreely - 44));
		}
	}

	void GenerateSlot () {
		float startreelx = gameObject.transform.position.x;
		float startreely = gameObject.transform.position.y;
		int somerandom = Random.Range (0, 8);
		GameObject newslot = new GameObject();
		newslot.transform.parent = gameObject.transform;
		newslot.AddComponent<SpriteRenderer>().sprite = slotassigner[somerandom];
		newslot.transform.position = new Vector2(startreelx, startreely + 3);
	}

	public void ButtonClicker () {
		donereel1 = false;
		donereel2 = false;
		donereel3 = false;
		foreach(Transform child in reel1.transform) {
			Destroy(child.gameObject);
		}
		foreach(Transform child in reel2.transform) {
			Destroy(child.gameObject);
		}
		foreach(Transform child in reel3.transform) {
			Destroy(child.gameObject);
		}
		float mainreelx = gameObject.transform.position.x;
		float mainreely = gameObject.transform.position.y;
		reel1.transform.position = new Vector2 (mainreelx, mainreely);
		reel2.transform.position = new Vector2 (mainreelx + 1, mainreely);
		reel3.transform.position = new Vector2 (mainreelx + 2, mainreely);
		for (int i = 0; i < 15; i++) {
			float startreelx = reel1.transform.position.x;
			float startreely = reel1.transform.position.y;
			int somerandom = Random.Range (0, 8);
			GameObject newslot = new GameObject();
			newslot.transform.parent = reel1.transform;
			newslot.AddComponent<SpriteRenderer>().sprite = slotassigner[somerandom];
			newslot.transform.position = new Vector2(startreelx, startreely + i);
			
		}
		for (int i = 0; i < 30; i++) {
			float startreelx = reel2.transform.position.x;
			float startreely = reel2.transform.position.y;
			int somerandom = Random.Range (0, 8);
			GameObject newslot = new GameObject();
			newslot.transform.parent = reel2.transform;
			newslot.AddComponent<SpriteRenderer>().sprite = slotassigner[somerandom];
			newslot.transform.position = new Vector2(startreelx + 1, startreely + i);
			
		}
		for (int i = 0; i < 45; i++) {
			float startreelx = reel3.transform.position.x;
			float startreely = reel3.transform.position.y;
			int somerandom = Random.Range (0, 8);
			GameObject newslot = new GameObject();
			newslot.transform.parent = reel3.transform;
			newslot.AddComponent<SpriteRenderer>().sprite = slotassigner[somerandom];
			newslot.transform.position = new Vector2(startreelx + 2, startreely + i);
			
		}
	}
}
