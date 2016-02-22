using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LevelSelect : MonoBehaviour {

	public GameObject leveldesc;

	public AudioSource sounds;
	
	public AudioClip selectsound;
	public AudioClip swooshsound;

	GameObject[] selectors;

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		leveldesc.GetComponent<Transform> ().position = new Vector3 (0f, 8f, -0.03f);
		leveldesc.gameObject.SetActive(false);

		sounds = (AudioSource)GameObject.Find ("Sounds").GetComponent<AudioSource>();

		if (selectors == null) {
			selectors = GameObject.FindGameObjectsWithTag ("LevelSelector");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator OnMouseDown(){
		print (gameObject.name);
		if (gameObject.name == "levelmarker1") {
			foreach (GameObject select in selectors) {
					select.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
			GameObject leveldescription = (GameObject)Instantiate(leveldesc, new Vector3(0, 8f, -0.03f), Quaternion.identity);
			GameObject leveldesctext = leveldescription.transform.Find("LevelText").gameObject;
			leveldesctext.gameObject.GetComponent<TextMesh>().text = "Level 1";
			GameObject leveltarget = leveldescription.transform.Find("TargetScoreText").gameObject;
			leveltarget.GetComponent<TextMesh>().text = "1000";
			sounds.PlayOneShot (selectsound);
			yield return new WaitForSeconds (selectsound.length + 0.1f);
			leveldescription.gameObject.SetActive (true);
			if(PlayerPrefs.HasKey("Coins_Level_1") && PlayerPrefs.GetString("Coins_Level_1") == "Bronze") {
				GameObject leveldescbronze = GameObject.Find("leveldescbronze");
				leveldescbronze.GetComponent<SpriteRenderer>().enabled = true;
			}
			if(PlayerPrefs.HasKey("Coins_Level_1") && PlayerPrefs.GetString("Coins_Level_1") == "Silver") {
				GameObject leveldescbronze = GameObject.Find("leveldescbronze");
				leveldescbronze.GetComponent<SpriteRenderer>().enabled = true;
				GameObject leveldescsilver = GameObject.Find("leveldescsilver");
				leveldescsilver.GetComponent<SpriteRenderer>().enabled = true;
			}
			if(PlayerPrefs.HasKey("Coins_Level_1") && PlayerPrefs.GetString("Coins_Level_1") == "Gold") {
				GameObject leveldescbronze = (GameObject)GameObject.Find("leveldescbronze");
				leveldescbronze.GetComponent<SpriteRenderer>().enabled = true;
				GameObject leveldescsilver = (GameObject)GameObject.Find("leveldescsilver");
				leveldescsilver.GetComponent<SpriteRenderer>().enabled = true;
				GameObject leveldescgold = (GameObject)GameObject.Find("leveldescgold");
				leveldescgold.GetComponent<SpriteRenderer>().enabled = true;
			}
			Tween leveldesctween = leveldescription.GetComponent<Transform> ().DOMove (new Vector3 (0f, 0f, -0.03f), 0.5f).SetEase (Ease.OutBack);
			sounds.PlayOneShot (swooshsound);
			yield return leveldesctween.WaitForCompletion ();
		}

		if (gameObject.name == "levelmarker2") {
			foreach (GameObject select in selectors) {
				select.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
			GameObject leveldescription = (GameObject)Instantiate(leveldesc, new Vector3(0, 8f, -0.03f), Quaternion.identity);
			GameObject leveldesctext = leveldescription.transform.Find("LevelText").gameObject;
			leveldesctext.gameObject.GetComponent<TextMesh>().text = "Level 2";
			GameObject leveltarget = leveldescription.transform.Find("TargetScoreText").gameObject;
			leveltarget.GetComponent<TextMesh>().text = "2000";
			sounds.PlayOneShot (selectsound);
			yield return new WaitForSeconds (selectsound.length + 0.1f);
			leveldescription.gameObject.SetActive (true);
			Tween leveldesctween = leveldescription.GetComponent<Transform> ().DOMove (new Vector3 (0f, 0f, -0.03f), 0.5f).SetEase (Ease.OutBack);
			sounds.PlayOneShot (swooshsound);
			yield return leveldesctween.WaitForCompletion ();
		}
		yield return null;
	}
}
