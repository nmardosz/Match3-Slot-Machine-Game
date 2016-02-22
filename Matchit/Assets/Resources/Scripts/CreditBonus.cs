using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreditBonus : MonoBehaviour {


	public GameObject[] theboxes;
	public int numberboxes;
	List<int> boxvalues;
	public bool onewasclicked;
	public GameObject whichonewasclicked;
	public GameObject huntbackground;
	public bool wearereadytoplayagain;
	public int clickedonesvalue;

	// Use this for initialization
	void Start () {
		boxvalues = new List<int> ();
		//StartCoroutine (SetBoxValues());
		onewasclicked = false;
		wearereadytoplayagain = false;

		for (int i = 0; i < numberboxes; i++) {
			theboxes[i].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			theboxes[i].gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			theboxes[i].gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
			theboxes[i].gameObject.GetComponentInChildren<TextMesh> ().color = Color.white;
		}

		huntbackground.GetComponent<SpriteRenderer> ().enabled = false;



	}
	
	// Update is called once per frame
	void Update () {
		if (onewasclicked == true) {
			onewasclicked = false;
			clickedonesvalue = whichonewasclicked.GetComponent<CreditBonusBox>().thisboxvalue;
			for (int i = 0; i < numberboxes; i++) {
				if(theboxes[i] != whichonewasclicked) {
					theboxes[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
					theboxes[i].gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
				}
			}
		}
	}

	public IEnumerator SetBoxValues() {
		onewasclicked = false;
		wearereadytoplayagain = false;

		huntbackground.GetComponent<SpriteRenderer> ().enabled = true;

		boxvalues.Add (100);
		boxvalues.Add (200);
		boxvalues.Add (300);
		boxvalues.Add (400);
		boxvalues.Add (500);

		for (int i = 0; i < numberboxes; i++) {
			int theboxvalue = Random.Range (0,boxvalues.Count);
			theboxes[i].gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			theboxes[i].gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			theboxes[i].gameObject.GetComponent<CreditBonusBox>().thisboxvalue = boxvalues[theboxvalue];
			theboxes[i].gameObject.GetComponentInChildren<TextMesh>().text = boxvalues[theboxvalue].ToString ();
			theboxes[i].gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
			theboxes[i].gameObject.GetComponentInChildren<MeshRenderer> ().transform.localScale = new Vector3(1f,1f,1f);
			theboxes[i].gameObject.GetComponentInChildren<TextMesh> ().color = Color.white;
			boxvalues.RemoveAt (theboxvalue);
		}

		boxvalues.Clear ();
		yield return null;
	
	}


	public IEnumerator ClearTreasureHunt() {
		for (int i = 0; i < numberboxes; i++) {
			theboxes[i].gameObject.GetComponent<Animator> ().SetBool ("openit", false);
			theboxes[i].gameObject.GetComponent<Animator> ().SetBool ("closeit", true);
			theboxes[i].gameObject.GetComponentInChildren<TextMesh> ().color = Color.white;
			theboxes[i].gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
			theboxes[i].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			theboxes[i].gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}
		
		huntbackground.GetComponent<SpriteRenderer> ().enabled = false;
		onewasclicked = false;
		yield return null;
	}
}
