using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {


	public static float selectedx;
	public static float selectedy;

	public static int selectedxindex1;
	public static int selectedyindex1;
	public static int selectedxindex2;
	public static int selectedyindex2;
	public static int selectedxindex3;
	public static int selectedyindex3;
	
	public GameObject thespinner;


	// Use this for initialization
	void Start () {
		thespinner = (GameObject)GameObject.Find ("Reels");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		//if(gameObject.transform.position.x > )
		if (thespinner.gameObject.GetComponent<Spinner>().canselect == true) {
			selectedx = gameObject.transform.position.x;
			selectedy = gameObject.transform.position.y;

			//print (selectedxindex + " " + selectedyindex);
			//Destroy (GridGen.grid[selectedxindex,selectedyindex].gameObject);

			//GameObject gridgenerator = (GameObject)GameObject.Find("Grid Generator");
			//gridgenerator.GetComponent<GridGen>().Compressor();

			GameObject selector = (GameObject)GameObject.Find ("selector(Clone)");
			if (selector) {
				Destroy (selector);
			}

			GameObject go = (GameObject)Instantiate (Resources.Load ("selector"));
			GameObject reels = (GameObject)GameObject.Find ("Reels");

			if (gameObject.transform.position.x != GridGen.gridstartxother && gameObject.transform.position.x != GridGen.gridstartxother + GridGen.sizexother - 1) {
				go.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
				reels.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
				selectedxindex1 = gameObject.GetComponent<SlotTracker> ().myindexxis - 1;
				selectedyindex1 = gameObject.GetComponent<SlotTracker> ().myindexyis;
				selectedxindex2 = gameObject.GetComponent<SlotTracker> ().myindexxis;
				selectedyindex2 = gameObject.GetComponent<SlotTracker> ().myindexyis;
				selectedxindex3 = gameObject.GetComponent<SlotTracker> ().myindexxis + 1;
				selectedyindex3 = gameObject.GetComponent<SlotTracker> ().myindexyis;
			}

			if (gameObject.transform.position.x == GridGen.gridstartxother) {
				go.transform.position = new Vector2 (gameObject.transform.position.x + 1, gameObject.transform.position.y);
				reels.transform.position = new Vector2 (gameObject.transform.position.x + 1, gameObject.transform.position.y);
				selectedxindex1 = gameObject.GetComponent<SlotTracker> ().myindexxis;
				selectedyindex1 = gameObject.GetComponent<SlotTracker> ().myindexyis;
				selectedxindex2 = gameObject.GetComponent<SlotTracker> ().myindexxis + 1;
				selectedyindex2 = gameObject.GetComponent<SlotTracker> ().myindexyis;
				selectedxindex3 = gameObject.GetComponent<SlotTracker> ().myindexxis + 2;
				selectedyindex3 = gameObject.GetComponent<SlotTracker> ().myindexyis;
			}

			if (gameObject.transform.position.x == GridGen.gridstartxother + GridGen.sizexother - 1) {
				go.transform.position = new Vector2 (gameObject.transform.position.x - 1, gameObject.transform.position.y);
				reels.transform.position = new Vector2 (gameObject.transform.position.x - 1, gameObject.transform.position.y);
				selectedxindex1 = gameObject.GetComponent<SlotTracker> ().myindexxis - 2;
				selectedyindex1 = gameObject.GetComponent<SlotTracker> ().myindexyis;
				selectedxindex2 = gameObject.GetComponent<SlotTracker> ().myindexxis - 1;
				selectedyindex2 = gameObject.GetComponent<SlotTracker> ().myindexyis;
				selectedxindex3 = gameObject.GetComponent<SlotTracker> ().myindexxis;
				selectedyindex3 = gameObject.GetComponent<SlotTracker> ().myindexyis;
			}
		}

	}

}
