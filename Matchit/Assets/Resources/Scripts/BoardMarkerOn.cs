using UnityEngine;
using System.Collections;

public class BoardMarkerOn : MonoBehaviour {

	public int markeron;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "BoardValue") {
			markeron = col.gameObject.GetComponent<BoardValue>().myboardvalue;
		}
	}
}
