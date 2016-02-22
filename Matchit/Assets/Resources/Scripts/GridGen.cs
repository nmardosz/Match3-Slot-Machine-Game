using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;

public class GridGen : MonoBehaviour {

	public int levelnumber;

	public Sprite[] slots;
	public float gridstartx;
	public float gridstarty;
	public static float gridstartxother;
	public static float gridstartyother;
	public int sizex;
	public int sizey;
	public static int sizexother;
	public static int sizeyother;

	public Button thebutton;
	public Image thebuttonimage;

	public Sprite activespinimage;
	public Sprite inactivespinimage;
	
	public static GameObject[,] grid;
	private bool checkgamestartmatches;
	private bool startnomatches;
	
	private bool compressing;
	private int counter;

	public int ismatches;
	public int compressed;
	public int isfilled;
	public int hasempties;
	public GameObject blast1;
	public GameObject blast2;
	public GameObject blast3;

	public GameObject coindestroyer;

	public GameObject coindrop;

	public GameObject scorepoper;

	public AudioSource matchburst;
	public AudioClip matchburstclip1;
	public AudioClip matchburstclip2;
	public AudioClip matchburstclip3;
	public AudioClip matchburstclip4;
	public AudioClip matchburstclip5;
	
	public AudioSource itemdrop;
	public AudioSource largedrop;
	public AudioClip dropdownsound;
	public AudioClip largerdrop;
	public AudioClip compdropsound;
	bool playonce;
	bool compplayonce;

	public GameObject reels;

	public int matchcascade;
	public int destroyedcount;

	bool playonevoice;

	public AudioSource voiceover;
	public AudioClip fantastic;
	public AudioClip amazing;
	public AudioClip excellent;
	public AudioClip marvelous;
	public AudioClip targetachieved;
	public AudioClip multiplierspin;
	public AudioClip scorebonus;
	public AudioClip freespinbonus;
	public AudioClip spinagain;
	public AudioClip chooseagain;
	public AudioClip rollagain;




	public GameObject wintextplacer;
	public GameObject fantastictext;
	public GameObject amazingtext;
	public GameObject excellenttext;
	public GameObject marveloustext;

	bool matchgrouper;

	public GameObject spinwheel;
	public GameObject spinwheelbackground;
	public GameObject theactualspinwheel;
	public GameObject wheelselector;

	public GameObject treasurehunt;
	public GameObject dicegame;

	public bool bonusplay;
	public string bonustype;
	int bonustypecounterspin;
	int bonustypecountertreasure;
	int bonustypecounterdice;

	int bonuscountrepeatspin;
	int bonuscountrepeattreasure;
	int bonuscountrepeatdice;

	public GameObject objectivebox;

	public GameObject levelcompletebanner;
	public GameObject levelfailedbanner;

	public GameObject successscreen;

	public GameObject bronze;
	public GameObject silver;
	public GameObject gold;

	public AudioSource successaudio;
	public AudioClip successcoinstamp;

	public AudioSource successmusic;

	GameObject[] coindropcount;

	// Use this for initialization
	void Start () {

		GameObject destroymlmusic = (GameObject)GameObject.Find ("MLmusic");
		Destroy (destroymlmusic);
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	
		thebuttonimage.overrideSprite = inactivespinimage; 
		thebutton.interactable = false;

		gridstartx = gameObject.GetComponent<Transform> ().position.x - 3.5f;
		gridstarty = gameObject.GetComponent<Transform> ().position.y + 3.5f;


		bonusplay = false;
		sizexother = sizex;
		sizeyother = sizey;
		
		grid = new GameObject[sizey,sizex];
		startnomatches = false;

		
		compressing = false;
		
		for (int i = 0; i < sizey; i++) {
			for (int j = 0; j < sizex; j++) {
				int somerandom = Random.Range (0, 12);
				//0 is sevenspin
				//1 is seventreasure
				//2 is bananaspin
				//3 is bananatreasure
				//4 is watermelonspin
				//5 is watermelon treasure
				GameObject newslot = new GameObject();
				newslot.AddComponent<SpriteRenderer>().sprite = slots[somerandom];
				newslot.AddComponent<Selector>();
				newslot.AddComponent<SlotTracker>();
				newslot.GetComponent<SlotTracker>().myindexyis = i;
				newslot.GetComponent<SlotTracker>().myindexxis = j;
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
				newslot.AddComponent<SlotValue>();
				newslot.AddComponent<BoxCollider2D>();
				newslot.GetComponent<BoxCollider2D>().isTrigger = true;
				newslot.transform.position = new Vector3(gridstartx + j, gridstarty - i, 1);
				newslot.name = "slot_" + i.ToString () + "_" + j.ToString ();
				newslot.GetComponent<SpriteRenderer>().enabled = false;
				newslot.transform.parent = gameObject.transform;
				grid[i,j] = newslot;
			}
		}
		print ("Start matching initial board");
		StartCoroutine(MatchCheck());

		objectivebox.gameObject.GetComponent<Transform> ().position = new Vector3 (0f, 15f, 0f);
		successscreen.gameObject.GetComponent<Transform> ().position = new Vector3 (13f, 0f, -7f);
		levelcompletebanner.gameObject.GetComponent<Transform> ().position = new Vector3 (0f, 15f, -6.56f);
		levelfailedbanner.gameObject.GetComponent<Transform> ().position = new Vector3 (0f, -15f, -6.56f);
		successscreen.SetActive (false);
		levelcompletebanner.SetActive (false);
		levelfailedbanner.SetActive (false);


		bronze.gameObject.GetComponent<Transform> ().localScale = new Vector3 (1.25f, 1.25f, 1f);
		silver.gameObject.GetComponent<Transform> ().localScale = new Vector3 (1.25f, 1.25f, 1f);
		gold.gameObject.GetComponent<Transform> ().localScale = new Vector3 (1.25f, 1.25f, 1f);

		bronze.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		silver.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gold.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void Awake () {
	}
	
	public IEnumerator MatchCheck() {
		
		print ("Matching");
		//List<GameObject> matches = new List<GameObject>();
		int outofindex = sizex;
		int outofindexy = sizey;
		//Compressor ();
		thebutton.interactable = false;
		thebuttonimage.overrideSprite = inactivespinimage;

		if (reels.GetComponent<Spinner> ().pressedmatchcount == true && startnomatches == true) {
			//if we get here from the spin button this is the 1st iteration
			//We are counding cascades and total destroyed
			reels.GetComponent<Spinner> ().pressedmatchcount = false;
			matchcascade = 0;
			destroyedcount = 0;
			playonevoice = false;
		}
		
		//check horizontally
		//remember i is the y index
		List<GameObject> hormatch = new List<GameObject> ();
		List<List<GameObject>> bonusmatches = new List<List<GameObject>> ();
		for (int i = 0; i < sizey; i++) {
			for (int j = 0; j < sizex-2; j++) {
				matchgrouper = false;
				//check 1 to the right
				if(!hormatch.Contains(grid[i,j].gameObject)) {

					if(j+1 < outofindex && grid[i,j].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[i,j+1].gameObject.GetComponent<SlotTracker>().firstsymbol) {
					//check 2 to the right
						if(j+2 < outofindex && grid[i,j].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[i,j+2].gameObject.GetComponent<SlotTracker>().firstsymbol) {
						//if we get here at least 3 were matched so add the 3 to the list
						hormatch.Add(grid[i,j].gameObject);
						hormatch.Add(grid[i,j+1].gameObject);
						hormatch.Add(grid[i,j+2].gameObject);
						grid[i,j].gameObject.GetComponent<SlotValue>().myscoreisvalue += 20;
						grid[i,j+1].gameObject.GetComponent<SlotValue>().myscoreisvalue += 20;
						grid[i,j+2].gameObject.GetComponent<SlotValue>().myscoreisvalue += 20;

							//now check them for bonuses
							if(grid[i,j].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+1].gameObject.GetComponent<SlotTracker>().bonussymbol && grid[i,j+1].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+2].gameObject.GetComponent<SlotTracker>().bonussymbol) {
								//we have a bonus match of the first 3
								grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
								grid[i,j+1].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
								grid[i,j+2].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
								matchgrouper = true;
							}


						
						
							if(j+3 < outofindex && grid[i,j].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[i,j+3].gameObject.GetComponent<SlotTracker>().firstsymbol) {
							//if we get here 4 were matched so add the 4th to the list
							hormatch.Add(grid[i,j+3].gameObject);
							grid[i,j].gameObject.GetComponent<SlotValue>().myscoreisvalue += 10;
							grid[i,j+1].gameObject.GetComponent<SlotValue>().myscoreisvalue += 10;
							grid[i,j+2].gameObject.GetComponent<SlotValue>().myscoreisvalue += 10;
							grid[i,j+3].gameObject.GetComponent<SlotValue>().myscoreisvalue += 30;
								if(grid[i,j+3].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+2].gameObject.GetComponent<SlotTracker>().bonussymbol && grid[i,j+2].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+1].gameObject.GetComponent<SlotTracker>().bonussymbol && matchgrouper == false) {
									//we have a bonus match of 3 from the back 3 of the 4
									//do something here.
									grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
									grid[i,j+1].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
									grid[i,j+2].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
									grid[i,j+3].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
									matchgrouper = true;
								}

								if(matchgrouper == true && grid[i,j+3].gameObject.GetComponent<SlotTracker>().horbonusgroup == "none") {
									grid[i,j+3].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
								}
							
							
								if(j+4 < outofindex && grid[i,j].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[i,j+4].gameObject.GetComponent<SlotTracker>().firstsymbol) {
								//if we get here 5 were matched so add the 5th to the list
								hormatch.Add(grid[i,j+4].gameObject);
								grid[i,j].gameObject.GetComponent<SlotValue>().myscoreisvalue += 18;
								grid[i,j+1].gameObject.GetComponent<SlotValue>().myscoreisvalue += 18;
								grid[i,j+2].gameObject.GetComponent<SlotValue>().myscoreisvalue += 18;
								grid[i,j+3].gameObject.GetComponent<SlotValue>().myscoreisvalue += 18;
								grid[i,j+4].gameObject.GetComponent<SlotValue>().myscoreisvalue += 48;
									if(grid[i,j+4].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+3].gameObject.GetComponent<SlotTracker>().bonussymbol && grid[i,j+3].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+2].gameObject.GetComponent<SlotTracker>().bonussymbol && matchgrouper == false) {
										//we have a bonus match of 3 from the back 3 of the 5
										//do something here.
										matchgrouper = true;
										grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
										grid[i,j+1].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
										grid[i,j+2].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
										grid[i,j+3].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
										grid[i,j+4].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
									}

									if(matchgrouper == true && grid[i,j+4].gameObject.GetComponent<SlotTracker>().horbonusgroup == "none") {
										grid[i,j+4].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
									}
								
								
									if(j+5 < outofindex && grid[i,j].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[i,j+5].gameObject.GetComponent<SlotTracker>().firstsymbol) {
									//if we get here 6 were matched so add the 6th to the list
									hormatch.Add(grid[i,j+5].gameObject);
									grid[i,j].gameObject.GetComponent<SlotValue>().myscoreisvalue += 32;
									grid[i,j+1].gameObject.GetComponent<SlotValue>().myscoreisvalue += 32;
									grid[i,j+2].gameObject.GetComponent<SlotValue>().myscoreisvalue += 32;
									grid[i,j+3].gameObject.GetComponent<SlotValue>().myscoreisvalue += 32;
									grid[i,j+4].gameObject.GetComponent<SlotValue>().myscoreisvalue += 32;
									grid[i,j+5].gameObject.GetComponent<SlotValue>().myscoreisvalue += 80;
										if(grid[i,j+5].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+4].gameObject.GetComponent<SlotTracker>().bonussymbol && grid[i,j+4].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+3].gameObject.GetComponent<SlotTracker>().bonussymbol && matchgrouper == false) {
											//we have a bonus match of 3 from the back 3 of the 6
											//do something here.
											matchgrouper = true;
											grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
											grid[i,j+1].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
											grid[i,j+2].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
											grid[i,j+3].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
											grid[i,j+4].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
											grid[i,j+5].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
										}

										if(matchgrouper == true && grid[i,j+5].gameObject.GetComponent<SlotTracker>().horbonusgroup == "none") {
											grid[i,j+5].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
										}
									
									
										if(j+6 < outofindex && grid[i,j].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[i,j+6].gameObject.GetComponent<SlotTracker>().firstsymbol) {
										//if we get here 7 were matched so add the 7th to the list
										//its not possible to match anymore than 7 horizontally
										hormatch.Add(grid[i,j+6].gameObject);
										grid[i,j].gameObject.GetComponent<SlotValue>().myscoreisvalue += 60;
										grid[i,j+1].gameObject.GetComponent<SlotValue>().myscoreisvalue += 60;
										grid[i,j+2].gameObject.GetComponent<SlotValue>().myscoreisvalue += 60;
										grid[i,j+3].gameObject.GetComponent<SlotValue>().myscoreisvalue += 60;
										grid[i,j+4].gameObject.GetComponent<SlotValue>().myscoreisvalue += 60;
										grid[i,j+5].gameObject.GetComponent<SlotValue>().myscoreisvalue += 60;
										grid[i,j+6].gameObject.GetComponent<SlotValue>().myscoreisvalue += 140;
											if(grid[i,j+6].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+5].gameObject.GetComponent<SlotTracker>().bonussymbol && grid[i,j+5].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[i,j+4].gameObject.GetComponent<SlotTracker>().bonussymbol && matchgrouper == false) {
												//we have a bonus match of 3 from the back 3 of the 7
												//do something here.
												matchgrouper = true;
												grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
												grid[i,j+1].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
												grid[i,j+2].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
												grid[i,j+3].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
												grid[i,j+4].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
												grid[i,j+5].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
												grid[i,j+6].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
											}
											if(matchgrouper == true && grid[i,j+6].gameObject.GetComponent<SlotTracker>().horbonusgroup == "none") {
												grid[i,j+6].gameObject.GetComponent<SlotTracker>().horbonusgroup = i.ToString () + j.ToString ();
											}

									}

								}

							}

						}

					}
				}
				}
			}
		}
		
		//check vertically
		List<GameObject> vermatch = new List<GameObject> ();
		for (int i = 0; i < sizex; i++) {
			for (int j = 0; j < sizey-2; j++) {
				matchgrouper = false;
				//check 1 to the bottom
				if(!vermatch.Contains(grid[j,i].gameObject)) {

					if(j+1 < outofindexy && grid[j,i].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[j+1,i].gameObject.GetComponent<SlotTracker>().firstsymbol) {
					//check 2 to the bottom
						if(j+2 < outofindexy && grid[j,i].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[j+2,i].gameObject.GetComponent<SlotTracker>().firstsymbol) {
						//if we get here at least 3 were matched vertically so add those 3 to the list
						vermatch.Add(grid[j,i].gameObject);
						vermatch.Add(grid[j+1,i].gameObject);
						vermatch.Add(grid[j+2,i].gameObject);
						grid[j,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 20;
						grid[j+1,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 20;
						grid[j+2,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 20;

							//now check them for bonuses vertically
							if(grid[j,i].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[j+1,i].gameObject.GetComponent<SlotTracker>().bonussymbol && grid[j+1,i].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[j+2,i].gameObject.GetComponent<SlotTracker>().bonussymbol) {
								//we have a bonus match of the first 3
								grid[j,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
								grid[j+1,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
								grid[j+2,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
								matchgrouper = true;
							}



							if(j+3 < outofindexy && grid[j,i].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[j+3,i].gameObject.GetComponent<SlotTracker>().firstsymbol) {
							//if we get here 4 were matched vertically so add the 4th to the list
							vermatch.Add(grid[j+3,i].gameObject);
							grid[j,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 10;
							grid[j+1,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 10;
							grid[j+2,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 10;
							grid[j+3,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 30;

								if(grid[j+3,i].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[j+2,i].gameObject.GetComponent<SlotTracker>().bonussymbol && grid[j+2,i].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[j+1,i].gameObject.GetComponent<SlotTracker>().bonussymbol && matchgrouper == false) {
									//we have a bonus match of 3 from the bottom 3 of the 4
									//do something here.
									grid[j,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
									grid[j+1,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
									grid[j+2,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
									grid[j+3,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
									matchgrouper = true;
								}
								
								if(matchgrouper == true && grid[j+3,i].gameObject.GetComponent<SlotTracker>().verbonusgroup == "none") {
									grid[j+3,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
								}

							

								if(j+4 < outofindexy && grid[j,i].gameObject.GetComponent<SlotTracker>().firstsymbol == grid[j+4,i].gameObject.GetComponent<SlotTracker>().firstsymbol) {
								//if we get here 5 were matched vertically so add the 5th to the list
								//its not possible to match anymore than 5 vertically
								vermatch.Add(grid[j+4,i].gameObject);
								grid[j,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 18;
								grid[j+1,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 18;
								grid[j+2,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 18;
								grid[j+3,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 18;
								grid[j+4,i].gameObject.GetComponent<SlotValue>().myscoreisvalue += 48;

									if(grid[j+4,i].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[j+3,i].gameObject.GetComponent<SlotTracker>().bonussymbol && grid[j+3,i].gameObject.GetComponent<SlotTracker>().bonussymbol == grid[j+2,i].gameObject.GetComponent<SlotTracker>().bonussymbol && matchgrouper == false) {
										//we have a bonus match of 3 from the back 3 of the 5
										//do something here.
										matchgrouper = true;
										grid[j,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
										grid[j+1,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
										grid[j+2,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
										grid[j+3,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
										grid[j+4,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
									}
									
									if(matchgrouper == true && grid[j+4,i].gameObject.GetComponent<SlotTracker>().verbonusgroup == "none") {
										grid[j+4,i].gameObject.GetComponent<SlotTracker>().verbonusgroup = i.ToString () + j.ToString ();
									}

							}

						}

					}
				}
				}
			}
		}

		if ((hormatch.Count > 0 || vermatch.Count > 0) && startnomatches == true && reels.GetComponent<Spinner> ().pressedmatchcount == false) {
			//iterate to increase the cascade count
			matchcascade++;
			foreach(GameObject horobj in hormatch) {
					destroyedcount++;
			}
			foreach(GameObject verobj in vermatch) {
				if(!hormatch.Contains(verobj)) {
					destroyedcount++;
				}
			}

		}


			//This is the selector disabler and match sequence adder for horizontal
			Sequence matchSequence = DOTween.Sequence ();
			if (hormatch.Count > 0) {
			thebutton.interactable = false;
			thebuttonimage.overrideSprite = inactivespinimage;
				GameObject selector = (GameObject)GameObject.Find ("selector(Clone)");
				if (selector != null) {
					selector.GetComponent<SpriteRenderer> ().enabled = false;
				}
				for (int i = 0; i < hormatch.Count; i++) {
					if (hormatch [i].gameObject != null) {
						matchSequence.Join (hormatch [i].transform.DOScale (1.5f, 0.3f));
					}
				}
			}
			//This is the selector disabler and match sequence adder for vertical
			if (vermatch.Count > 0) {
			thebutton.interactable = false;
			thebuttonimage.overrideSprite = inactivespinimage; 
				GameObject selector = (GameObject)GameObject.Find ("selector(Clone)");
				if (selector != null) {
					selector.GetComponent<SpriteRenderer> ().enabled = false;
				}
				for (int i = 0; i < vermatch.Count; i++) {
					if (vermatch [i].gameObject != null) {
						matchSequence.Join (vermatch [i].transform.DOScale (1.5f, 0.3f));
					}
				}
			}

		/////////////////Start of bonus play code
		List<string> counthorbonusmatch = new List<string> ();
		List<string> countverbonusmatch = new List<string> ();
		bonuscountrepeatspin = 0;
		bonuscountrepeattreasure = 0;
		bonuscountrepeatdice = 0;
		if (startnomatches == true) {
			matchSequence.Play ();
			yield return matchSequence.WaitForCompletion ();
			//lets build the lists of horizontal bonus matches
			for (int i = 0; i < sizey; i++) {
				for (int j = 0; j < sizex; j++) {
					if(grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup != "none") {
						if(!counthorbonusmatch.Contains(grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup)) {
							counthorbonusmatch.Add (grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup);
						}
						//print ("We have a match: Paused for 30 seconds");
						//yield return new WaitForSeconds(30);
					}
					
				}
			}

			for (int i = 0; i < sizey; i++) {
				for (int j = 0; j < sizex; j++) {
					if(grid[i,j].gameObject.GetComponent<SlotTracker>().verbonusgroup != "none") {
						if(!countverbonusmatch.Contains(grid[i,j].gameObject.GetComponent<SlotTracker>().verbonusgroup)) {
							countverbonusmatch.Add (grid[i,j].gameObject.GetComponent<SlotTracker>().verbonusgroup);
						}
						//print ("We have a match: Paused for 30 seconds");
						//yield return new WaitForSeconds(30);
					}
					
				}
			}

			//this is where we play the bonus games for horizonatal bonus matches
			//play the bonus audio

			if(counthorbonusmatch.Count > 0) {
			
			for (int bonuscount = 0; bonuscount < counthorbonusmatch.Count; bonuscount++) {
					List<GameObject> bonusplaywithhor = new List<GameObject> ();
					bonustypecounterspin = 0;
					bonustypecountertreasure = 0;
					bonustypecounterdice = 0;
					for (int i = 0; i < sizey; i++) {
						for (int j = 0; j < sizex; j++) {
							if(grid[i,j].gameObject.GetComponent<SlotTracker>().horbonusgroup == counthorbonusmatch[bonuscount]) {
								if(grid[i,j].gameObject.GetComponent<SlotTracker>().bonussymbol == "spin") {
									bonustypecounterspin++;
								}
								if(grid[i,j].gameObject.GetComponent<SlotTracker>().bonussymbol == "treasure") {
									bonustypecountertreasure++;
								}
								if(grid[i,j].gameObject.GetComponent<SlotTracker>().bonussymbol == "dice") {
									bonustypecounterdice++;
								}
								if(bonustypecounterspin >= 3) {
									bonustype = "spin";
								}
								if(bonustypecountertreasure >= 3) {
									bonustype = "treasure";
								}
								if(bonustypecounterdice >= 3) {
									bonustype = "dice";
								}
								bonusplaywithhor.Add (grid[i,j].gameObject); 
							}
						}
					}

					//We actually play the game one time now that the list is built for the matches here

					if(bonustype == "spin") {
						print ("we should get here for spin horizontal");
						bonusplay = true;
						if(bonuscountrepeatspin == 0) {
							voiceover.PlayOneShot(multiplierspin);
						}
						if(bonuscountrepeatspin > 0) {
							voiceover.PlayOneShot(spinagain);
						}
						spinwheelbackground.GetComponent<SpriteRenderer>().enabled = true;
						theactualspinwheel.GetComponent<SpriteRenderer>().enabled = true;
						wheelselector.GetComponent<SpriteRenderer>().enabled = true;
						spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().swipetospinarrowactive = true;
						spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().readytorepeat = true;


						while( spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().donespin == false )
						{
							yield return new WaitForSeconds(.01f);
						}
						spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().donespin = false;
						spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().readytorepeat = false;
						bonusplay = false;
						foreach(GameObject theobj in bonusplaywithhor) {
							theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue = theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue *= spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().valuelandedon;
						}
						spinwheelbackground.GetComponent<SpriteRenderer>().enabled = false;
						theactualspinwheel.GetComponent<SpriteRenderer>().enabled = false;
						wheelselector.GetComponent<SpriteRenderer>().enabled = false;
						bonuscountrepeatspin++;
					}

					if(bonustype == "treasure") {
						print ("we should get here for treasure horizontal");
						bonusplay = true;
						if(bonuscountrepeattreasure == 0) {
							voiceover.PlayOneShot(scorebonus);
						}
						if(bonuscountrepeattreasure > 0) {
							voiceover.PlayOneShot(chooseagain);
						}
						StartCoroutine(treasurehunt.GetComponent<CreditBonus>().SetBoxValues());
						treasurehunt.GetComponent<CreditBonus>().wearereadytoplayagain = false;
						
						while( treasurehunt.GetComponent<CreditBonus>().wearereadytoplayagain == false )
						{
							yield return new WaitForSeconds(.01f);
						}
						yield return new WaitForSeconds(3);
						StartCoroutine(treasurehunt.GetComponent<CreditBonus>().ClearTreasureHunt());
						treasurehunt.GetComponent<CreditBonus>().wearereadytoplayagain = false;
						if(coindestroyer.GetComponent<ScoreTracker>().won < coindestroyer.GetComponent<ScoreTracker>().targetscore) {
							float scalehowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().targetscore) * coindestroyer.GetComponent<ScoreTracker>().targpercscale;
							float tranhowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().targetscore) * (coindestroyer.GetComponent<ScoreTracker>().hundpercxpos - coindestroyer.GetComponent<ScoreTracker>().startxpos);
							coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
							coindestroyer.GetComponent<ScoreTracker>().progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
							coindestroyer.GetComponent<ScoreTracker>().won += treasurehunt.GetComponent<CreditBonus>().clickedonesvalue;
						}
						if(coindestroyer.GetComponent<ScoreTracker>().won >= coindestroyer.GetComponent<ScoreTracker>().targetscore && coindestroyer.GetComponent<ScoreTracker>().won <= coindestroyer.GetComponent<ScoreTracker>().secondscore) {
							float scalehowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().secondscore) * coindestroyer.GetComponent<ScoreTracker>().secondpercscale;
							float tranhowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().secondscore) * (coindestroyer.GetComponent<ScoreTracker>().secondachievementpos - coindestroyer.GetComponent<ScoreTracker>().startxpos);
							coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
							coindestroyer.GetComponent<ScoreTracker>().progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
							coindestroyer.GetComponent<ScoreTracker>().won += treasurehunt.GetComponent<CreditBonus>().clickedonesvalue;
						}
						if(coindestroyer.GetComponent<ScoreTracker>().won > coindestroyer.GetComponent<ScoreTracker>().secondscore) {
							if(coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale.x < coindestroyer.GetComponent<ScoreTracker>().thirdpercscale) {
								float scalehowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().thirdscore) * coindestroyer.GetComponent<ScoreTracker>().thirdpercscale;
								float tranhowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().thirdscore) * (coindestroyer.GetComponent<ScoreTracker>().thirdachievementpos - coindestroyer.GetComponent<ScoreTracker>().startxpos);
								coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
								coindestroyer.GetComponent<ScoreTracker>().progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
							}
							coindestroyer.GetComponent<ScoreTracker>().won += treasurehunt.GetComponent<CreditBonus>().clickedonesvalue;
						}
						bonusplay = false;
						//foreach(GameObject theobj in bonusplaywithhor) {
						//	theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue = theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue *= spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().valuelandedon;
						//}
						bonuscountrepeattreasure++;


					}

					if(bonustype == "dice") {
						print ("we should get here for dice horizontal");
						bonusplay = true;
						if(bonuscountrepeatdice == 0) {
							voiceover.PlayOneShot(freespinbonus);
						}
						if(bonuscountrepeatdice > 0) {
							voiceover.PlayOneShot(rollagain);
						}
						StartCoroutine(dicegame.GetComponent<FreeSpinBonus>().EnableDiceGame());
						dicegame.GetComponent<FreeSpinBonus>().readytoplaydicegame = true;

						while( dicegame.GetComponent<FreeSpinBonus>().readytoplaydicegame == true )
						{
							yield return new WaitForSeconds(.01f);
						}
						yield return new WaitForSeconds(1);
						StartCoroutine(dicegame.GetComponent<FreeSpinBonus>().DisableDiceGame());
						//float scalehowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().targetscore) * coindestroyer.GetComponent<ScoreTracker>().targpercscale;
						//float tranhowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().targetscore) * (coindestroyer.GetComponent<ScoreTracker>().hundpercxpos - coindestroyer.GetComponent<ScoreTracker>().startxpos);
						//coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
						//coindestroyer.GetComponent<ScoreTracker>().progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
						//coindestroyer.GetComponent<ScoreTracker>().won += treasurehunt.GetComponent<CreditBonus>().clickedonesvalue;
						bonusplay = false;
						//foreach(GameObject theobj in bonusplaywithhor) {
						//	theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue = theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue *= spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().valuelandedon;
						//}
						bonuscountrepeatdice++;
						
						
					}

				}
			}

			if(countverbonusmatch.Count > 0) {
				for (int bonuscount = 0; bonuscount < countverbonusmatch.Count; bonuscount++) {
					List<GameObject> bonusplaywithver = new List<GameObject> ();
					bonustypecounterspin = 0;
					bonustypecountertreasure = 0;
					bonustypecounterdice = 0;
					for (int i = 0; i < sizey; i++) {
						for (int j = 0; j < sizex; j++) {
							if(grid[i,j].gameObject.GetComponent<SlotTracker>().verbonusgroup == countverbonusmatch[bonuscount]) {
								if(grid[i,j].gameObject.GetComponent<SlotTracker>().bonussymbol == "spin") {
									bonustypecounterspin++;
								}
								if(grid[i,j].gameObject.GetComponent<SlotTracker>().bonussymbol == "treasure") {
									bonustypecountertreasure++;
								}
								if(grid[i,j].gameObject.GetComponent<SlotTracker>().bonussymbol == "dice") {
									bonustypecounterdice++;
								}
								if(bonustypecounterspin >= 3) {
									bonustype = "spin";
								}
								if(bonustypecountertreasure >= 3) {
									bonustype = "treasure";
								}
								if(bonustypecounterdice >= 3) {
									bonustype = "dice";
								}
								bonusplaywithver.Add (grid[i,j].gameObject); 
							}
						}
					}
					
					//We actually play the game one time now that the list is built for the matches here

					if(bonustype == "spin") {
						print ("we should get here for spin vertical");
						bonusplay = true;
						if(bonuscountrepeatspin == 0) {
							voiceover.PlayOneShot(multiplierspin);
						}
						if(bonuscountrepeatspin > 0) {
							voiceover.PlayOneShot(spinagain);
						}
						spinwheelbackground.GetComponent<SpriteRenderer>().enabled = true;
						theactualspinwheel.GetComponent<SpriteRenderer>().enabled = true;
						wheelselector.GetComponent<SpriteRenderer>().enabled = true;
						spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().swipetospinarrowactive = true;
						spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().readytorepeat = true;

						while( spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().donespin == false )
						{
							yield return new WaitForSeconds(.01f);
						}
						spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().donespin = false;
						spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().readytorepeat = false;
						bonusplay = false;
						foreach(GameObject theobj in bonusplaywithver) {
							theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue = theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue *= spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().valuelandedon;
						}
						spinwheelbackground.GetComponent<SpriteRenderer>().enabled = false;
						theactualspinwheel.GetComponent<SpriteRenderer>().enabled = false;
						wheelselector.GetComponent<SpriteRenderer>().enabled = false;
						bonuscountrepeatspin++;

					}

					if(bonustype == "treasure") {
						print ("we should get here for treasure vertical");
						bonusplay = true;
						if(bonuscountrepeattreasure == 0) {
							voiceover.PlayOneShot(scorebonus);
						}
						if(bonuscountrepeattreasure > 0) {
							voiceover.PlayOneShot(chooseagain);
						}
						StartCoroutine(treasurehunt.GetComponent<CreditBonus>().SetBoxValues());
						
						while( treasurehunt.GetComponent<CreditBonus>().wearereadytoplayagain == false )
						{
							yield return new WaitForSeconds(.01f);
						}
						yield return new WaitForSeconds(3);
						StartCoroutine(treasurehunt.GetComponent<CreditBonus>().ClearTreasureHunt());
						treasurehunt.GetComponent<CreditBonus>().wearereadytoplayagain = false;
						if(coindestroyer.GetComponent<ScoreTracker>().won < coindestroyer.GetComponent<ScoreTracker>().targetscore) {
							float scalehowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().targetscore) * coindestroyer.GetComponent<ScoreTracker>().targpercscale;
							float tranhowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().targetscore) * (coindestroyer.GetComponent<ScoreTracker>().hundpercxpos - coindestroyer.GetComponent<ScoreTracker>().startxpos);
							coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
							coindestroyer.GetComponent<ScoreTracker>().progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
							coindestroyer.GetComponent<ScoreTracker>().won += treasurehunt.GetComponent<CreditBonus>().clickedonesvalue;
						}
						if(coindestroyer.GetComponent<ScoreTracker>().won >= coindestroyer.GetComponent<ScoreTracker>().targetscore && coindestroyer.GetComponent<ScoreTracker>().won <= coindestroyer.GetComponent<ScoreTracker>().secondscore) {
							float scalehowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().secondscore) * coindestroyer.GetComponent<ScoreTracker>().secondpercscale;
							float tranhowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().secondscore) * (coindestroyer.GetComponent<ScoreTracker>().secondachievementpos - coindestroyer.GetComponent<ScoreTracker>().startxpos);
							coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
							coindestroyer.GetComponent<ScoreTracker>().progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
							coindestroyer.GetComponent<ScoreTracker>().won += treasurehunt.GetComponent<CreditBonus>().clickedonesvalue;
						}
						if(coindestroyer.GetComponent<ScoreTracker>().won > coindestroyer.GetComponent<ScoreTracker>().secondscore) {
							if(coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale.x < coindestroyer.GetComponent<ScoreTracker>().thirdpercscale) {
								float scalehowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().thirdscore) * coindestroyer.GetComponent<ScoreTracker>().thirdpercscale;
								float tranhowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().thirdscore) * (coindestroyer.GetComponent<ScoreTracker>().thirdachievementpos - coindestroyer.GetComponent<ScoreTracker>().startxpos);
								coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
								coindestroyer.GetComponent<ScoreTracker>().progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
							}
							coindestroyer.GetComponent<ScoreTracker>().won += treasurehunt.GetComponent<CreditBonus>().clickedonesvalue;
						}
						bonusplay = false;
						//foreach(GameObject theobj in bonusplaywithhor) {
						//	theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue = theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue *= spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().valuelandedon;
						//}
						bonuscountrepeattreasure++;
						
					}

					if(bonustype == "dice") {
						print ("we should get here for dice vertical");
						bonusplay = true;
						if(bonuscountrepeatdice == 0) {
							voiceover.PlayOneShot(freespinbonus);
						}
						if(bonuscountrepeatdice > 0) {
							voiceover.PlayOneShot(rollagain);
						}
						StartCoroutine(dicegame.GetComponent<FreeSpinBonus>().EnableDiceGame());
						dicegame.GetComponent<FreeSpinBonus>().readytoplaydicegame = true;
						
						while( dicegame.GetComponent<FreeSpinBonus>().readytoplaydicegame == true )
						{
							yield return new WaitForSeconds(.01f);
						}
						yield return new WaitForSeconds(1);
						StartCoroutine(dicegame.GetComponent<FreeSpinBonus>().DisableDiceGame());
						//float scalehowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().targetscore) * coindestroyer.GetComponent<ScoreTracker>().targpercscale;
						//float tranhowmuch = (treasurehunt.GetComponent<CreditBonus>().clickedonesvalue / coindestroyer.GetComponent<ScoreTracker>().targetscore) * (coindestroyer.GetComponent<ScoreTracker>().hundpercxpos - coindestroyer.GetComponent<ScoreTracker>().startxpos);
						//coindestroyer.GetComponent<ScoreTracker>().progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
						//coindestroyer.GetComponent<ScoreTracker>().progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
						//coindestroyer.GetComponent<ScoreTracker>().won += treasurehunt.GetComponent<CreditBonus>().clickedonesvalue;
						bonusplay = false;
						//foreach(GameObject theobj in bonusplaywithhor) {
						//	theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue = theobj.gameObject.GetComponent<SlotValue>().myscoreisvalue *= spinwheel.gameObject.GetComponent<PrizeWheelSpinner>().valuelandedon;
						//}
						bonuscountrepeatdice++;
						
						
					}

				}
			}
			/////////////////End of bonus play code

			if (hormatch.Count > 0) {
				for (int i = 0; i < hormatch.Count; i++) {
					if (hormatch [i].gameObject != null) {
						if (startnomatches == true) {
							GameObject newobj = (GameObject)Instantiate(coindrop, new Vector3(hormatch [i].transform.position.x, hormatch [i].transform.position.y, -1f), Quaternion.identity);
							newobj.GetComponent<CoinDropDestroyer>().myvalue = hormatch[i].GetComponent<SlotValue>().myscoreisvalue;
						}
					}
				}
			}
			
			if (vermatch.Count > 0) {
				for (int i = 0; i < vermatch.Count; i++) {
					if (vermatch [i].gameObject != null) {
						if (startnomatches == true) {
							GameObject newobj = (GameObject)Instantiate(coindrop, new Vector3(vermatch [i].transform.position.x, vermatch [i].transform.position.y, -1f), Quaternion.identity);
							newobj.GetComponent<CoinDropDestroyer>().myvalue = vermatch[i].GetComponent<SlotValue>().myscoreisvalue;
						}
					}
				}
			}

			if (hormatch.Count > 0 || vermatch.Count > 0) {
				if (!matchburst.isPlaying && matchcascade == 1) {
					matchburst.PlayOneShot(matchburstclip1);
				}
				if (!matchburst.isPlaying && matchcascade == 2) {
					matchburst.PlayOneShot(matchburstclip2);
				}
				if (!matchburst.isPlaying && matchcascade == 3) {
					matchburst.PlayOneShot(matchburstclip3);
				}
				if (!matchburst.isPlaying && matchcascade == 4) {
					matchburst.PlayOneShot(matchburstclip4);
				}
				if (!matchburst.isPlaying && matchcascade > 4) {
					matchburst.PlayOneShot(matchburstclip5);
				}
			}
		}

		for (int i = 0; i < hormatch.Count; i++) {
			if (hormatch [i].gameObject != null) {
				int y = hormatch [i].GetComponent<SlotTracker> ().myindexyis;
				int x = hormatch [i].GetComponent<SlotTracker> ().myindexxis;
				scorepoper.GetComponent<ScoreTextPop>().scoretodisp = hormatch [i].GetComponent<SlotValue> ().myscoreisvalue;
				GameObject obj = hormatch [i];
				if (startnomatches == true) {
					Instantiate(scorepoper, new Vector3(obj.transform.position.x, obj.transform.position.y, 1.5f), Quaternion.identity);
					int randblast = Random.Range (0, 3);
					if(randblast == 0) {
						Instantiate(blast1, new Vector3(obj.transform.position.x, obj.transform.position.y, 1.5f), Quaternion.identity);
					}
					if(randblast == 1) {
						Instantiate(blast2, new Vector3(obj.transform.position.x, obj.transform.position.y, 1.5f), Quaternion.identity);
					}
					if(randblast == 2) {
						Instantiate(blast3, new Vector3(obj.transform.position.x, obj.transform.position.y, 1.5f), Quaternion.identity);
					}
				}
				Destroy (obj);
				grid [y, x] = null;
			}
		}

		for (int i = 0; i < vermatch.Count; i++) {
			if (vermatch [i].gameObject != null) {
				int y = vermatch [i].GetComponent<SlotTracker> ().myindexyis;
				int x = vermatch [i].GetComponent<SlotTracker> ().myindexxis;
				scorepoper.GetComponent<ScoreTextPop>().scoretodisp = vermatch [i].GetComponent<SlotValue> ().myscoreisvalue;
				GameObject obj = vermatch [i];
				if (startnomatches == true) {
					Instantiate(scorepoper, new Vector3(obj.transform.position.x, obj.transform.position.y, 1.5f), Quaternion.identity);
					int randblast = Random.Range (0, 3);
					if(randblast == 0) {
						Instantiate(blast1, new Vector3(obj.transform.position.x, obj.transform.position.y, 1.5f), Quaternion.identity);
					}
					if(randblast == 1) {
						Instantiate(blast2, new Vector3(obj.transform.position.x, obj.transform.position.y, 1.5f), Quaternion.identity);
					}
					if(randblast == 2) {
						Instantiate(blast3, new Vector3(obj.transform.position.x, obj.transform.position.y, 1.5f), Quaternion.identity);
					}
				}
				Destroy (obj);
				grid [y, x] = null;
			}
		}

	
		//match checking for game start
		/*if (hormatch.Count == 0 && vermatch.Count == 0 && startnomatches == false) {
			No matches so we can start playing
			for (int i = 0; i < sizey; i++) {
				for (int j = 0; j < sizex; j++) {
					grid [i, j].gameObject.GetComponent<SpriteRenderer> ().enabled = true;

				}
			}
			startnomatches = true;
			ismatches = 0;
			print ("No matches found return control");
			hormatch.Clear ();
			vermatch.Clear ();
			return ismatches;
		} else {
			print ("Matches found");
			ismatches = 1;
			//The grid will have empties because it just matched and matches were found and removed
			hormatch.Clear ();
			vermatch.Clear ();
			return ismatches;
		}*/

		//match checking return output

		if (hormatch.Count == 0 && vermatch.Count == 0 && startnomatches == true) {
			thebuttonimage.overrideSprite = activespinimage;
			thebutton.interactable = true; 

			if(destroyedcount > 8 && destroyedcount < 15 && playonevoice == false) {
				voiceover.PlayOneShot(fantastic);
				Instantiate(fantastictext, new Vector3(wintextplacer.transform.position.x, wintextplacer.transform.position.y, wintextplacer.transform.position.z), Quaternion.identity );
				playonevoice = true;
			}
			if(destroyedcount > 14 && destroyedcount < 24 && playonevoice == false) {
				voiceover.PlayOneShot(amazing);
				Instantiate(amazingtext, new Vector3(wintextplacer.transform.position.x, wintextplacer.transform.position.y, wintextplacer.transform.position.z), Quaternion.identity );
				playonevoice = true;
			}
			if(destroyedcount > 23 && destroyedcount < 31 && playonevoice == false) {
				voiceover.PlayOneShot(excellent);
				Instantiate(excellenttext, new Vector3(wintextplacer.transform.position.x, wintextplacer.transform.position.y, wintextplacer.transform.position.z), Quaternion.identity );
				playonevoice = true;
			}
			if(destroyedcount > 30 && playonevoice == false) {
				voiceover.PlayOneShot(marvelous);
				Instantiate(marveloustext, new Vector3(wintextplacer.transform.position.x, wintextplacer.transform.position.y, wintextplacer.transform.position.z), Quaternion.identity );
				playonevoice = true;
			}



			//No matches so we can continue
			ismatches = 0;
			print ("No matches found return control");
			hormatch.Clear ();
			vermatch.Clear ();
			counthorbonusmatch.Clear ();
			countverbonusmatch.Clear ();
			if(coindestroyer.GetComponent<ScoreTracker>().credtracker == 0 && reels.GetComponent<Spinner>().freespin == false) {
				print ("Coin drop count: " + GameObject.FindGameObjectsWithTag("Coin").Length);
				do{
					yield return new WaitForSeconds(0.01f);
					
				}while(GameObject.FindGameObjectsWithTag("Coin").Length > 0);
					

				print ("Coin drop count after while: " + GameObject.FindGameObjectsWithTag("Coin").Length);
				if(GameObject.FindGameObjectsWithTag("Coin").Length == 0) {
					StartCoroutine(EndGame ());
				}
			}
			yield return null;
		} 
		if (hormatch.Count > 0 || vermatch.Count > 0 && startnomatches == true) {
			thebuttonimage.overrideSprite = inactivespinimage; 
			thebutton.interactable = false;
			ismatches = 1;
			print ("Matches found");
			//The grid will have empties because it just matched and matches were found and removed
			hormatch.Clear ();
			vermatch.Clear ();
			counthorbonusmatch.Clear ();
			countverbonusmatch.Clear ();
			yield return StartCoroutine(Compressor());
		}

		if (hormatch.Count == 0 && vermatch.Count == 0 && startnomatches == false) {
			//No matches so we can start playing
			ismatches = 0;
			print ("No matches found return control");
			hormatch.Clear ();
			vermatch.Clear ();

			for (int i = 0; i < sizey; i++) {
				for (int j = 0; j < sizex; j++) {
					grid[i,j].gameObject.GetComponent<SpriteRenderer>().enabled = true;
				}
			}
			yield return new WaitForSeconds(0.3f);

			Tween boardmovein = gameObject.GetComponent<Transform>().DOMove (new Vector3(0, 0, 0), 0.5f).SetEase(Ease.OutBack);
			yield return boardmovein.WaitForCompletion ();

			gridstartx = gameObject.GetComponent<Transform> ().position.x - 3.5f;
			gridstarty = gameObject.GetComponent<Transform> ().position.y + 3.5f;

			gridstartxother = gridstartx;
			gridstartyother = gridstarty;

			StartCoroutine(StartBox ());
			startnomatches = true;
			yield return null;
		} 
		if(hormatch.Count > 0 || vermatch.Count > 0 && startnomatches == false) {
			ismatches = 1;
			print ("Matches found");
			thebuttonimage.overrideSprite = inactivespinimage;
			thebutton.interactable = false; 
			//The grid will have empties because it just matched and matches were found and removed
			hormatch.Clear ();
			vermatch.Clear ();

			for (int i = 0; i < sizey; i++) {
				for (int j = 0; j < sizex; j++) {
					if(grid[i,j] != null) {
						grid[i,j].gameObject.GetComponent<SpriteRenderer>().enabled = false;
					}
				}
			}
			startnomatches = false;
			yield return StartCoroutine(Compressor());
		}

		
		
		
	}
	
	public IEnumerator FillEmpty() {
		print ("Filling");
		isfilled = 0;
		thebuttonimage.overrideSprite = inactivespinimage; 
		thebutton.interactable = false;
		Sequence fillSequence = DOTween.Sequence ();
		List<Tween> droppers = new List<Tween> ();
		for (int j = sizey - 1; j > -1; j--) {
			playonce = false;
			for (int i = 0; i < sizex; i++) {
				if(startnomatches == false) {
					if(grid[j,i] == null) {
						int somerandom = Random.Range (0, 12);
						GameObject newslot = new GameObject();
						newslot.AddComponent<SpriteRenderer>().sprite = slots[somerandom];
						newslot.GetComponent<SpriteRenderer>().enabled = false;
						newslot.AddComponent<Selector>();
						newslot.AddComponent<SlotTracker>();
						newslot.GetComponent<SlotTracker>().myindexyis = j;
						newslot.GetComponent<SlotTracker>().myindexxis = i;
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
						newslot.AddComponent<SlotValue>();
						newslot.AddComponent<BoxCollider2D>();
						newslot.GetComponent<BoxCollider2D>().isTrigger = true;
						newslot.name = "slot_" + j.ToString () + "_" + i.ToString () ;
						newslot.transform.parent = gameObject.transform;
						newslot.transform.position = new Vector3(gridstartx + i, gridstarty - j, 1);
						grid[j,i] = newslot;
					}
				}
				if(startnomatches != false) {
					if(grid[j,i] == null) {
						int somerandom = Random.Range (0, 12);
						GameObject newslot = new GameObject();
						newslot.AddComponent<SpriteRenderer>().sprite = slots[somerandom];
						newslot.GetComponent<SpriteRenderer>().enabled = true;
						newslot.AddComponent<Selector>();
						newslot.AddComponent<SlotTracker>();
						newslot.GetComponent<SlotTracker>().myindexyis = j;
						newslot.GetComponent<SlotTracker>().myindexxis = i;
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
						newslot.AddComponent<SlotValue>();
						newslot.AddComponent<BoxCollider2D>();
						newslot.GetComponent<BoxCollider2D>().isTrigger = true;
						newslot.name = "slot_" + j.ToString () + "_" + i.ToString () ;
						newslot.transform.parent = gameObject.transform;
						newslot.transform.position = new Vector3(gridstartx + i, gridstarty - j + 3, 1);
						//newslot.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
						newslot.GetComponent<SpriteRenderer>().enabled = true;
						//fillSequence.Append (newslot.transform.DOMove(new Vector3(0, -3, 0), 0.3f).SetRelative().SetLoops(0, LoopType.Yoyo));
						droppers.Add (newslot.transform.DOMove(new Vector3(0, -3, 0), 0.2f).SetRelative().SetLoops(0, LoopType.Yoyo));
						//fillSequence.Join (newslot.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.5f).SetRelative().SetLoops(0, LoopType.Yoyo));
						grid[j,i] = newslot;
					}
				}

			}
			//fillSequence.Play ();
			//yield return fillSequence.WaitForCompletion ();
			//if (startnomatches == true) {
			//	if (!itemdrop.isPlaying) {
			//		itemdrop.PlayOneShot (dropdownsound);
			//	}
			//}
			foreach(Tween datween in droppers) {
				datween.Play();
				yield return datween.WaitForCompletion ();
				if (startnomatches == true) {
					if(droppers.Count >= 3 && playonce == false){
						playonce = true;
						largedrop.PlayOneShot (largerdrop);
					}
					if(droppers.Count < 3 && playonce == false){
						playonce = true;
						itemdrop.PlayOneShot (dropdownsound);
					}
				}
			}
			droppers.Clear ();

		}
		isfilled = 1;
		GameObject selectorena = (GameObject)GameObject.Find("selector(Clone)");
		if (selectorena != null) {
			selectorena.GetComponent<SpriteRenderer>().enabled = true;
		}
		yield return StartCoroutine (MatchCheck ());
	}
	
	public IEnumerator Compressor() {
		print ("Compressing");
		compressed = 0;
		thebuttonimage.overrideSprite = inactivespinimage; 
		thebutton.interactable = false;
		Sequence compressSequence = DOTween.Sequence ();
		List<Tween> compdrop = new List<Tween> ();
		for (int i = 0; i < sizex; i++) {
			compplayonce = false;
			for (int j = sizey - 1; j > -1; j--) {

				if(grid[j,i] == null) {
					//start searching up for the first non null
					for(int above = j - 1; above > -1; above--){
						//iterate down the stack to find gaps
						//move the first thing that is found to the current null position in loop
						if(grid[above,i] != null) {
							print ("get grid at " + j + ":" + i);

							grid[j,i] = grid[above,i].gameObject;
							float distance = j - above;
							if (startnomatches == false) {
								grid[j,i].gameObject.GetComponent<Transform>().position = new Vector3(grid[above,i].gameObject.GetComponent<Transform>().position.x, grid[above,i].gameObject.GetComponent<Transform>().position.y - distance, 0);
							}
							grid[above,i] = null;
							int newnamecount = j;
							string adjustedname = "slot_" + newnamecount.ToString() + "_" + i.ToString();
							grid[j,i].gameObject.name = adjustedname;
							grid[j,i].gameObject.GetComponent<SlotTracker>().myindexyis = newnamecount;
							//move the object to the correct position visually

							//build the dropping sequences
							if (startnomatches == true) {
							compressSequence.Join (grid[j,i].gameObject.transform.DOMove(new Vector3(0, -distance, 0), 0.3f).SetRelative().SetLoops(0, LoopType.Yoyo));
							}
							//compdrop.Add (grid[j,i].gameObject.transform.DOMove(new Vector3(0, -distance, 0), 0.2f).SetRelative().SetLoops(0, LoopType.Yoyo));
							break;
	
						}
						
					}
					
					
				}
				
			}
			/*foreach(Tween datween in compdrop) {
				datween.Play();
				yield return datween.WaitForCompletion ();
				if (startnomatches == true) {
					if(compdrop.Count >= 3 && compplayonce == false){
						compplayonce = true;
						largedrop.PlayOneShot (largerdrop);
					}
					if(compdrop.Count < 3 && compplayonce == false){
						playonce = true;
						itemdrop.PlayOneShot (dropdownsound);
					}
				}
			}
			compdrop.Clear ();
			*/
			
		}
		if (startnomatches == true) {
			compressSequence.Play ();
			yield return compressSequence.WaitForCompletion ();
		}
		if (startnomatches == true) {
			itemdrop.PlayOneShot (compdropsound);
		}
		compressed = 1;
		yield return StartCoroutine(FillEmpty ());
	}
	
	public int GridEmptyChecker() {
		hasempties = 0;
		print ("Checking for Empties in grid");
		for (int i = 0; i < sizey; i++) {
			for (int j = 0; j < sizex; j++) {
				
				if (grid [i, j] == null) {
					print ("Empties found compress");
					hasempties = 1;
					break;
				}
			}
		}
		return hasempties;
	}

	IEnumerator Whatever()
	{
		float timeToWait = 5;
		yield return new WaitForSeconds(timeToWait);
	}

	public IEnumerator SeqDone(Sequence daseq) {
		bool isComplete = daseq.IsComplete();
		if (isComplete == true) {
			yield return null;
		}
	}

	public IEnumerator StartBox() {
		reels.GetComponent<Spinner> ().canselect = false;
		thebuttonimage.overrideSprite = inactivespinimage; 
		thebutton.interactable = false;
		GameObject selector = (GameObject)GameObject.Find ("selector(Clone)");
		if (selector != null) {
			selector.GetComponent<SpriteRenderer> ().enabled = false;
		}
		yield return new WaitForSeconds (0.5f);
		Tween objectiveboxdropper = objectivebox.transform.DOMove(new Vector3(0f, 0f, -6.56f),0.5f);
		yield return objectiveboxdropper.WaitForCompletion ();
		yield return new WaitForSeconds (1.5f);
		Tween objectiveboxremover = objectivebox.transform.DOMove(new Vector3(0f, -15f, -6.56f),0.5f);
		yield return objectiveboxremover.WaitForCompletion ();
		objectivebox.GetComponentInChildren<SpriteRenderer> ().enabled = false;
		objectivebox.GetComponentInChildren<MeshRenderer> ().enabled = false;
		thebuttonimage.overrideSprite = activespinimage;
		thebutton.interactable = true;
		if (selector != null) {
			selector.GetComponent<SpriteRenderer> ().enabled = true;
		}
		thebutton.interactable = true; 
		thebuttonimage.overrideSprite = activespinimage;
		reels.GetComponent<Spinner> ().canselect = true;
		yield return null;
	}

	public IEnumerator EndGame() {
		if (coindestroyer.GetComponent<ScoreTracker> ().won < coindestroyer.GetComponent<ScoreTracker> ().targetscore) {
			print ("Level Failed");
			reels.GetComponent<Spinner> ().canselect = false;
			thebuttonimage.overrideSprite = inactivespinimage; 
			thebutton.interactable = false;
			levelfailedbanner.SetActive (true);
			Tween failedmoverup = levelfailedbanner.GetComponent<Transform>().DOMove (new Vector3(0, 0, -6.56f), 0.5f);
			yield return failedmoverup.WaitForCompletion ();
			yield return new WaitForSeconds (2f);
			Tween failedmoverfin = levelfailedbanner.GetComponent<Transform>().DOMove (new Vector3(0, 15, -6.56f), 0.5f);
			yield return failedmoverfin.WaitForCompletion ();
			levelfailedbanner.SetActive (false);

		}

		if (coindestroyer.GetComponent<ScoreTracker> ().won >= coindestroyer.GetComponent<ScoreTracker> ().targetscore) {

			print ("Level Completed");
			PlayerPrefs.SetString ("From_Level", "True");

			//This will only be true if we havent completed the level yet
			//We will set the level completed to true
			if(!PlayerPrefs.HasKey("Level_"+levelnumber.ToString ()+"_Complete")) {
				PlayerPrefs.SetString("Level_"+levelnumber.ToString ()+"_Complete", "True");
			}

			if(!PlayerPrefs.HasKey("unlocked_level")) {
				PlayerPrefs.SetInt("unlocked_level", levelnumber);
			}

			if(PlayerPrefs.HasKey("unlocked_level")) {
				int currunlocked = PlayerPrefs.GetInt("unlocked_level");

				if(levelnumber + 1 > currunlocked) {
					PlayerPrefs.SetInt("unlocked_level", levelnumber + 1);
					int newunlocked = levelnumber + 1;
					PlayerPrefs.SetString("unlocked_level_anim_"+newunlocked.ToString(), "True");
				}
			}

			//If we havenet played anything yet than set the first levels complete int
			if(!PlayerPrefs.HasKey("Levels_Complete")) {
				PlayerPrefs.SetInt("Levels_Complete", levelnumber);
			}

			//We will always hit this
			if(PlayerPrefs.HasKey("Levels_Complete")) {
				int levelscompleted = PlayerPrefs.GetInt ("Levels_Complete");
				//We will only get here if we complete a level that is higher than the previous level
				//If we re-play a previous level we wont get here
				if(levelnumber > levelscompleted) {
					PlayerPrefs.SetInt("Levels_Complete", levelnumber);
				}
			}

			if(PlayerPrefs.HasKey("Score_Level_"+levelnumber.ToString ())) {
				int prevscore = PlayerPrefs.GetInt("Score_Level_"+levelnumber.ToString ());
				if(prevscore <= coindestroyer.GetComponent<ScoreTracker> ().won) {
					PlayerPrefs.SetInt("Score_Level_"+levelnumber.ToString (), coindestroyer.GetComponent<ScoreTracker> ().won);
				}
			}
			else {
				PlayerPrefs.SetInt("Score_Level_"+levelnumber.ToString (), coindestroyer.GetComponent<ScoreTracker> ().won);
			}
			gameObject.GetComponent<AudioSource>().Stop();
			reels.GetComponent<Spinner> ().canselect = false;
			thebuttonimage.overrideSprite = inactivespinimage; 
			thebutton.interactable = false;
			levelcompletebanner.SetActive (true);
			successscreen.SetActive (true);
			successmusic.Play ();
			successscreen.GetComponentInChildren<TextMesh>().text = coindestroyer.GetComponent<ScoreTracker> ().won.ToString ();
			Tween compmoverdown = levelcompletebanner.GetComponent<Transform>().DOMove (new Vector3(0, 0, -6.56f), 0.5f);
			yield return compmoverdown.WaitForCompletion ();
			yield return new WaitForSeconds (1.5f);
			Tween compmoverfin = levelcompletebanner.GetComponent<Transform>().DOMove (new Vector3(0, -15, -6.56f), 0.5f);
			yield return compmoverfin.WaitForCompletion ();
			Tween successdesc = successscreen.GetComponent<Transform>().DOMove (new Vector3(0, 0, -7f), 0.5f).SetEase(Ease.OutBack);
			yield return successdesc.WaitForCompletion ();


			if(coindestroyer.GetComponent<ScoreTracker> ().won >= coindestroyer.GetComponent<ScoreTracker> ().targetscore && coindestroyer.GetComponent<ScoreTracker> ().won < coindestroyer.GetComponent<ScoreTracker> ().secondscore) {
				bronze.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				Tween bronzestamp = bronze.GetComponent<Transform>().DOScale(new Vector3(0.68f, 0.68f, 1f), 0.3f);
				yield return bronzestamp.WaitForCompletion ();
				bool playitonce = false;
				if (playitonce == false) {
				successaudio.PlayOneShot(successcoinstamp);
					playitonce = true;
				}
				if(!PlayerPrefs.HasKey("Coins_Level_"+levelnumber.ToString ())) {
					PlayerPrefs.SetString("Coins_Level_"+levelnumber.ToString (), "Bronze");
				}
			}

			if(coindestroyer.GetComponent<ScoreTracker> ().won >= coindestroyer.GetComponent<ScoreTracker> ().secondscore && coindestroyer.GetComponent<ScoreTracker> ().won < coindestroyer.GetComponent<ScoreTracker> ().thirdscore) {
				bronze.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				Tween bronzestamp = bronze.GetComponent<Transform>().DOScale(new Vector3(0.68f, 0.68f, 1f), 0.2f);
				yield return bronzestamp.WaitForCompletion ();
				bool playitonce = false;
				if (playitonce == false) {
					successaudio.PlayOneShot(successcoinstamp);
					playitonce = true;
				}
				silver.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				Tween silverstamp = silver.GetComponent<Transform>().DOScale(new Vector3(0.68f, 0.68f, 1f), 0.2f);
				yield return silverstamp.WaitForCompletion ();
				bool playittwice = false;
				if (playittwice == false) {
					successaudio.PlayOneShot(successcoinstamp);
					playittwice = true;
				}
				if(!PlayerPrefs.HasKey("Coins_Level_"+levelnumber.ToString ())) {
					PlayerPrefs.SetString("Coins_Level_"+levelnumber.ToString (), "Silver");
				}
				else {
					string prevcoinwon = PlayerPrefs.GetString("Coins_Level_"+levelnumber.ToString ());
					if(prevcoinwon == "Bronze") {
						PlayerPrefs.SetString("Coins_Level_"+levelnumber.ToString (), "Silver");
					}
				}
			}

			if(coindestroyer.GetComponent<ScoreTracker> ().won >= coindestroyer.GetComponent<ScoreTracker> ().thirdscore) {
				bronze.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				Tween bronzestamp = bronze.GetComponent<Transform>().DOScale(new Vector3(0.68f, 0.68f, 1f), 0.2f);
				yield return bronzestamp.WaitForCompletion ();
				bool playitonce = false;
				if (playitonce == false) {
					successaudio.PlayOneShot(successcoinstamp);
					playitonce = true;
				}
				silver.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				Tween silverstamp = silver.GetComponent<Transform>().DOScale(new Vector3(0.68f, 0.68f, 1f), 0.2f);
				yield return silverstamp.WaitForCompletion ();
				bool playittwice = false;
				if (playittwice == false) {
					successaudio.PlayOneShot(successcoinstamp);
					playittwice = true;
				}
				gold.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
				Tween goldstamp = gold.GetComponent<Transform>().DOScale(new Vector3(0.68f, 0.68f, 1f), 0.2f);
				yield return goldstamp.WaitForCompletion ();
				bool playitthird = false;
				if (playitthird == false) {
					successaudio.PlayOneShot(successcoinstamp);
					playitthird = true;
				}

				if(!PlayerPrefs.HasKey("Coins_Level_"+levelnumber.ToString ())) {
					PlayerPrefs.SetString("Coins_Level_"+levelnumber.ToString (), "Gold");
				}
				else {
					string prevcoinwon = PlayerPrefs.GetString("Coins_Level_"+levelnumber.ToString ());
					if(prevcoinwon == "Bronze" || prevcoinwon == "Silver") {
						PlayerPrefs.SetString("Coins_Level_"+levelnumber.ToString (), "Gold");
					}
				}
			}



			levelcompletebanner.SetActive (false);
		}

		yield return null;
	}


	
}
