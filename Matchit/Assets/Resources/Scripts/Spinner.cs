using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Spinner : MonoBehaviour {
	
	public int numberofimages;
	public Sprite[] slotassigner;
	public int speed;

	public Button thebutton;
	public Image thebuttonimage;

	public Sprite activespinimage;
	public Sprite inactivespinimage;
	
	public GameObject reel1;
	public GameObject reel2;
	public GameObject reel3;
	
	bool donereel1;
	bool donereel2;
	bool donereel3;
	
	float mainreelx;
	float mainreely;

	bool buttonclicked;

	public GameObject gridgenerator;

	public GameObject coindestroyscore;

	public AudioSource spinsound;
	public AudioSource slotset;
	public AudioClip spinningsound1;
	public AudioClip spinningsound2;
	public AudioClip spinningsound3;
	public AudioClip slotsetsound;

	private bool slotsetsound1;
	private bool slotsetsound2;
	private bool slotsetsound3;

	public bool pressedmatchcount;

	public bool canselect;

	public bool freespin;
	public GameObject freespins;



	// Use this for initialization
	void Start () {
		buttonclicked = false;
		pressedmatchcount = false;
		canselect =  false;
		freespin = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (buttonclicked == true) {
			canselect = false;
			thebutton.interactable = false;
			thebuttonimage.overrideSprite = inactivespinimage; 
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
				if(!slotset.isPlaying && slotsetsound1 == false)
				{
					slotsetsound1 = true;
					slotset.PlayOneShot(slotsetsound);
				}
				reel1.transform.position = new Vector2 (mainreelx, (mainreely - 14));
				foreach(Transform child in reel1.transform) {
					Destroy(child.gameObject);
				}
				GridGen.grid[Selector.selectedyindex1,Selector.selectedxindex1].gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
		
			if (donereel2 == true) {
				if(!slotset.isPlaying && slotsetsound2 == false)
				{
					slotsetsound2 = true;
					slotset.PlayOneShot(slotsetsound);
				}
				reel2.transform.position = new Vector2 (mainreelx, (mainreely - 29));
				foreach(Transform child in reel2.transform) {
					Destroy(child.gameObject);
				}
				GridGen.grid[Selector.selectedyindex2,Selector.selectedxindex2].gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
		
			if (donereel3 == true) {
				if(!slotset.isPlaying && slotsetsound3 == false)
				{
					slotsetsound3 = true;
					slotset.PlayOneShot(slotsetsound);
				}
				reel3.transform.position = new Vector2 (mainreelx, (mainreely - 44));
				foreach(Transform child in reel3.transform) {
					Destroy(child.gameObject);
				}
				GridGen.grid[Selector.selectedyindex3,Selector.selectedxindex3].gameObject.GetComponent<SpriteRenderer>().enabled = true;
				StartCoroutine(gridgenerator.GetComponent<GridGen>().MatchCheck());
				spinsound.Stop();
				buttonclicked = false;
				canselect = true;
			}

		}
	}
	
	void GenerateSlot () {
		float startreelx = gameObject.transform.position.x;
		float startreely = gameObject.transform.position.y;
		int somerandom = Random.Range (0, 12);
		GameObject newslot = new GameObject();
		newslot.transform.parent = gameObject.transform;
		newslot.AddComponent<SpriteRenderer>().sprite = slotassigner[somerandom];
		newslot.transform.position = new Vector2(startreelx, startreely + 3);
	}
	
	public void ButtonClicker () {
		buttonclicked = true;
		pressedmatchcount = true;
		slotsetsound1 = false;
		slotsetsound2 = false;
		slotsetsound3 = false;



		int randspinsound = Random.Range (0,3);

		if (randspinsound == 0) {
			spinsound.PlayOneShot (spinningsound1);
		}
		if (randspinsound == 1) {
			spinsound.PlayOneShot (spinningsound2);
		}
		if (randspinsound == 2) {
			spinsound.PlayOneShot (spinningsound3);
		}

		if (!freespin) {
			coindestroyscore.GetComponent<ScoreTracker> ().credtracker -= coindestroyscore.GetComponent<ScoreTracker> ().bettracker;
		}

		if (freespin && freespins.GetComponent<FreeSpinBonus>().boardmarkeron != 0) {
			freespins.GetComponent<FreeSpinBonus>().boardmarkeron--;
			if (freespins.GetComponent<FreeSpinBonus>().boardmarkeron == 0) {
				freespin = false;
			}
		}

		donereel1 = false;
		donereel2 = false;
		donereel3 = false;
		GridGen.grid[Selector.selectedyindex1,Selector.selectedxindex1].gameObject.GetComponent<SpriteRenderer>().enabled = false;
		GridGen.grid[Selector.selectedyindex2,Selector.selectedxindex2].gameObject.GetComponent<SpriteRenderer>().enabled = false;
		GridGen.grid[Selector.selectedyindex3,Selector.selectedxindex3].gameObject.GetComponent<SpriteRenderer>().enabled = false;
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
		reel1.transform.position = new Vector2 (mainreelx - 1, mainreely);
		reel2.transform.position = new Vector2 (mainreelx - 1, mainreely);
		reel3.transform.position = new Vector2 (mainreelx - 1, mainreely);

		for (int i = 0; i < 15; i++) {
			float startreelx = reel1.transform.position.x;
			float startreely = reel1.transform.position.y;
			int somerandom = Random.Range (0, 12);
			GameObject newslot = new GameObject();
			newslot.transform.parent = reel1.transform;
			newslot.AddComponent<SpriteRenderer>().sprite = slotassigner[somerandom];
			newslot.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Masker");
			newslot.AddComponent<SlotTracker>();
			if(somerandom == 0) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 1) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 2) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 3) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 4) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 5) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 6) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 7) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 8) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 9) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 10) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 11) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			newslot.transform.position = new Vector2(startreelx, startreely + i);

			if(i == 0){
				newslot.GetComponent<SlotTracker>().firstsymbol = GridGen.grid[Selector.selectedyindex1,Selector.selectedxindex1].gameObject.GetComponent<SlotTracker>().firstsymbol;
				newslot.GetComponent<SlotTracker>().bonussymbol = GridGen.grid[Selector.selectedyindex1,Selector.selectedxindex1].gameObject.GetComponent<SlotTracker>().bonussymbol;
				newslot.GetComponent<SpriteRenderer>().sprite = GridGen.grid[Selector.selectedyindex1,Selector.selectedxindex1].gameObject.GetComponent<SpriteRenderer>().sprite;
			}

			if(i == 14){
				GridGen.grid[Selector.selectedyindex1,Selector.selectedxindex1].gameObject.GetComponent<SlotTracker>().firstsymbol = newslot.GetComponent<SlotTracker>().firstsymbol;
				GridGen.grid[Selector.selectedyindex1,Selector.selectedxindex1].gameObject.GetComponent<SlotTracker>().bonussymbol = newslot.GetComponent<SlotTracker>().bonussymbol;
				GridGen.grid[Selector.selectedyindex1,Selector.selectedxindex1].gameObject.GetComponent<SpriteRenderer>().sprite = newslot.GetComponent<SpriteRenderer>().sprite;
			}
			
		}
		for (int i = 0; i < 30; i++) {
			float startreelx = reel2.transform.position.x;
			float startreely = reel2.transform.position.y;
			int somerandom = Random.Range (0, 12);
			GameObject newslot = new GameObject();
			newslot.transform.parent = reel2.transform;
			newslot.AddComponent<SpriteRenderer>().sprite = slotassigner[somerandom];
			newslot.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Masker");
			newslot.AddComponent<SlotTracker>();
			if(somerandom == 0) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 1) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 2) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 3) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 4) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 5) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 6) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 7) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 8) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 9) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 10) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 11) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			newslot.transform.position = new Vector2(startreelx + 1, startreely + i);

			if(i == 0){
				newslot.GetComponent<SlotTracker>().firstsymbol = GridGen.grid[Selector.selectedyindex2,Selector.selectedxindex2].gameObject.GetComponent<SlotTracker>().firstsymbol;
				newslot.GetComponent<SlotTracker>().bonussymbol = GridGen.grid[Selector.selectedyindex2,Selector.selectedxindex2].gameObject.GetComponent<SlotTracker>().bonussymbol;
				newslot.GetComponent<SpriteRenderer>().sprite = GridGen.grid[Selector.selectedyindex2,Selector.selectedxindex2].gameObject.GetComponent<SpriteRenderer>().sprite;
			}

			if(i == 29){
				GridGen.grid[Selector.selectedyindex2,Selector.selectedxindex2].gameObject.GetComponent<SlotTracker>().firstsymbol = newslot.GetComponent<SlotTracker>().firstsymbol;
				GridGen.grid[Selector.selectedyindex2,Selector.selectedxindex2].gameObject.GetComponent<SlotTracker>().bonussymbol = newslot.GetComponent<SlotTracker>().bonussymbol;
				GridGen.grid[Selector.selectedyindex2,Selector.selectedxindex2].gameObject.GetComponent<SpriteRenderer>().sprite = newslot.GetComponent<SpriteRenderer>().sprite;
			}
			
		}
		for (int i = 0; i < 45; i++) {
			float startreelx = reel3.transform.position.x;
			float startreely = reel3.transform.position.y;
			int somerandom = Random.Range (0, 12);
			GameObject newslot = new GameObject();
			newslot.transform.parent = reel3.transform;
			newslot.AddComponent<SpriteRenderer>().sprite = slotassigner[somerandom];
			newslot.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Masker");
			newslot.AddComponent<SlotTracker>();
			if(somerandom == 0) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 1) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 2) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "seven";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 3) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 4) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 5) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bar";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 6) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 7) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 8) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "bell";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			if(somerandom == 9) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "spin";
			}
			if(somerandom == 10) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "treasure";
			}
			if(somerandom == 11) {
				newslot.GetComponent<SlotTracker>().firstsymbol = "gem";
				newslot.GetComponent<SlotTracker>().bonussymbol = "dice";
			}
			newslot.transform.position = new Vector2(startreelx + 2, startreely + i);

			if(i == 0){
				newslot.GetComponent<SlotTracker>().firstsymbol = GridGen.grid[Selector.selectedyindex3,Selector.selectedxindex3].gameObject.GetComponent<SlotTracker>().firstsymbol;
				newslot.GetComponent<SlotTracker>().bonussymbol = GridGen.grid[Selector.selectedyindex3,Selector.selectedxindex3].gameObject.GetComponent<SlotTracker>().bonussymbol;
				newslot.GetComponent<SpriteRenderer>().sprite = GridGen.grid[Selector.selectedyindex3,Selector.selectedxindex3].gameObject.GetComponent<SpriteRenderer>().sprite;
			}

			if(i == 44){
				GridGen.grid[Selector.selectedyindex3,Selector.selectedxindex3].gameObject.GetComponent<SlotTracker>().firstsymbol = newslot.GetComponent<SlotTracker>().firstsymbol;
				GridGen.grid[Selector.selectedyindex3,Selector.selectedxindex3].gameObject.GetComponent<SlotTracker>().bonussymbol = newslot.GetComponent<SlotTracker>().bonussymbol;
				GridGen.grid[Selector.selectedyindex3,Selector.selectedxindex3].gameObject.GetComponent<SpriteRenderer>().sprite = newslot.GetComponent<SpriteRenderer>().sprite;
			}
			
		}
	}
}