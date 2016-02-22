using UnityEngine;
using System.Collections;

public class FreeSpinButton : MonoBehaviour {

	public bool canroll;
	public Sprite btnina;
	public GameObject freespincontroller;
	public GameObject gridgen;

	// Use this for initialization
	void Start () {
		canroll = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (canroll == true && gridgen.GetComponent<GridGen> ().bonusplay == true && gridgen.GetComponent<GridGen> ().bonustype == "dice") {
			print ("Rolled");
			canroll = false;
			gameObject.GetComponent<SpriteRenderer>().sprite = btnina;
			freespincontroller.GetComponent<FreeSpinBonus>().rolled = true;
		}
	}
}
