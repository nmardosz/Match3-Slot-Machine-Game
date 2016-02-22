using UnityEngine;
using System.Collections;

public class SlotValue : MonoBehaviour {

	public static int myscoreis;
	public int myscoreisvalue;

	// Use this for initialization
	void Start () {
		myscoreisvalue = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		myscoreis = myscoreisvalue;
	}

}
