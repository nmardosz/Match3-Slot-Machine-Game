using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CloseLevelDesc : MonoBehaviour {

	public GameObject leveldesc;
	public AudioSource sounds;

	public AudioClip selectsound;
	public AudioClip swooshsound;

	bool closesoundonce;
	bool swooshsoundonce;

	GameObject[] selectors;

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		sounds = (AudioSource)GameObject.Find ("Sounds").GetComponent<AudioSource>();

		if (selectors == null) {
			selectors = GameObject.FindGameObjectsWithTag ("LevelSelector");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator OnMouseDown() {
		closesoundonce = false;
		swooshsoundonce = false;
		sounds.PlayOneShot (selectsound);
		yield return new WaitForSeconds (selectsound.length + 0.1f);
		Tween leveldesctween = leveldesc.GetComponent<Transform> ().DOMove (new Vector3 (0f, 8f, -0.03f), 0.5f).SetEase(Ease.InBack);
		sounds.PlayOneShot (swooshsound);
		yield return leveldesctween.WaitForCompletion ();
		GameObject leveldescbronze = GameObject.Find("leveldescbronze");
		leveldescbronze.GetComponent<SpriteRenderer>().enabled = true;
		GameObject leveldescsilver = GameObject.Find("leveldescsilver");
		leveldescbronze.GetComponent<SpriteRenderer>().enabled = true;
		GameObject leveldescgold = GameObject.Find("leveldescgold");
		leveldescbronze.GetComponent<SpriteRenderer>().enabled = true;
		leveldesc.gameObject.SetActive(false);
		Destroy (leveldesc);
		foreach (GameObject select in selectors) {
			select.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
		yield return null;
	}
}
