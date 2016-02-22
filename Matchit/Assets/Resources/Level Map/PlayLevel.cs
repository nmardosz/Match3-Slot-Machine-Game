using UnityEngine;
using System.Collections;

public class PlayLevel : MonoBehaviour {

	public AudioSource sounds;

	public AudioClip selection;

	// Use this for initialization
	void Start () {
		sounds = (AudioSource)GameObject.Find ("Sounds").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator OnMouseDown() {
		sounds.PlayOneShot (selection);
		yield return new WaitForSeconds (selection.length);
		Application.LoadLevel ("casino_level_1");
	}
}
