using UnityEngine;
using System.Collections;

public class MusicCheck : MonoBehaviour {

	public AudioClip mainclip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Awake() {
		GameObject mainmusic = (GameObject)GameObject.Find ("MLmusic");
		if (!mainmusic) {
			AudioSource thisaudio = gameObject.AddComponent<AudioSource>();
			thisaudio.loop = true;
			thisaudio.volume = 0.348f;
			thisaudio.clip = mainclip;
			thisaudio.Play ();
		}
	}
}
