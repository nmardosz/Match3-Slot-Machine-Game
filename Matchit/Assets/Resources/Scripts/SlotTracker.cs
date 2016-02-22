using UnityEngine;
using System.Collections;

public class SlotTracker : MonoBehaviour {

	public static int myindexx;
	public static int myindexy;
	public int myindexxis;
	public int myindexyis;
	public string firstsymbol;
	public string bonussymbol;
	public string horbonusgroup;
	public string verbonusgroup;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Awake() {
		myindexxis = myindexx;
		myindexyis = myindexy;
		horbonusgroup = "none";
		verbonusgroup = "none";
	}
}
