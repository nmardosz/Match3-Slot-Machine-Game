using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CreditBonusBox : MonoBehaviour {

	public int thisboxvalue;
	public GameObject thecreditbonuscontroller;

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		if(thecreditbonuscontroller.GetComponent<CreditBonus> ().onewasclicked == false){
			gameObject.GetComponent<Animator> ().SetBool ("closeit", false);
			gameObject.GetComponent<Animator> ().SetBool ("openit", true);
			thecreditbonuscontroller.GetComponent<CreditBonus> ().whichonewasclicked = this.gameObject;

			//gameObject.GetComponentInChildren<MeshRenderer> ().transform.position = new Vector3(gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y + 0.4f, gameObject.GetComponent<Transform> ().position.z - 0.01f);
			gameObject.GetComponentInChildren<TextMesh> ().color = Color.black;
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
			gameObject.GetComponentInChildren<MeshRenderer> ().transform.DOMove (new Vector3(gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y + 0.4f, gameObject.GetComponent<Transform> ().position.z  - 0.01f),0.3f);
			gameObject.GetComponentInChildren<MeshRenderer> ().transform.DOScale (1.5f, 0.3f);

			thecreditbonuscontroller.GetComponent<CreditBonus> ().wearereadytoplayagain = true;
			thecreditbonuscontroller.GetComponent<CreditBonus> ().onewasclicked = true;
		}

	}
}
