using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayButtonWiggle : MonoBehaviour {

	public AudioSource buttonaudiosource;
	public AudioClip buttonclicksound;

	bool playsoundonce;
	

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		playsoundonce = true;
		Tween wiggleloop = gameObject.transform.DOScaleX (1.1f, 0.7f).SetLoops(-1, LoopType.Yoyo);
		Tween wiggleloops = gameObject.transform.DOScaleY(1.1f, 1f).SetLoops(-1, LoopType.Yoyo);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.33f, 0.33f, 0.33f, 1f);
		Tween clicker = gameObject.transform.DOScale (new Vector3 (0.8f, 0.8f, 0f), 0.3f);
		StartCoroutine (WaitForSound ());
		print ("Changing");
	}

	public IEnumerator WaitForSound() {
		buttonaudiosource.PlayOneShot (buttonclicksound);
		yield return new WaitForSeconds (buttonclicksound.length);
		Application.LoadLevel ("LevelMap");
	}
}
