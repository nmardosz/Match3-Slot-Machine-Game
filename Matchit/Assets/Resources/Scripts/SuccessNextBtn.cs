using UnityEngine;
using System.Collections;

public class SuccessNextBtn : MonoBehaviour {

	public AudioClip btnsound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator OnMouseDown() {
		gameObject.GetComponent<AudioSource>().PlayOneShot (btnsound);
		yield return new WaitForSeconds (btnsound.length);
		Application.LoadLevel ("LevelMap");
	}
}
