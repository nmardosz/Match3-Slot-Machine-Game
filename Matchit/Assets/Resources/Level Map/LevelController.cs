using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LevelController : MonoBehaviour {

	public GameObject playermarker;
	public GameObject bronzecoinpref;
	public GameObject silvercoinpref;
	public GameObject goldcoinpref;

	public GameObject levelhighlight;
	public GameObject levelmarker;

	public AudioClip coinsuccesssound;

	public GameObject lburst;

	bool playsoundonce;

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		if (!PlayerPrefs.HasKey("unlocked_level")) {
			playermarker.gameObject.GetComponent<Transform> ().position = new Vector3 (-2.45f, -4.01f, -0.03f);
		}


		string fromlevel = PlayerPrefs.GetString("From_Level");

		if (fromlevel == "False") {
			StartCoroutine (SetCurrLevel());
		}

		if (fromlevel == "True") {
			PlayerPrefs.SetString ("From_Level", "False");
			StartCoroutine(SetCoinsAndMove());
		}

		playsoundonce = false;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public IEnumerator SetCoinsAndMove() {
		GameObject levelhighlighter = (GameObject)GameObject.Find ("levelhighlighter");
		Destroy (levelhighlighter);
		if (PlayerPrefs.GetInt("unlocked_level") == 2 && PlayerPrefs.GetString("unlocked_level_anim_2") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_2", "False");
			if(PlayerPrefs.GetString("Coins_Level_1") == "Bronze") {
				GameObject bronzeobj = (GameObject)Instantiate(bronzecoinpref, new Vector3(-2.63f, -4.74f, -0.04f), Quaternion.identity);
				Tween bronzescaler = bronzeobj.transform.DOScale (new Vector3 (0.08f, 0.08f, 1f), 0.5f);
				yield return bronzescaler.WaitForCompletion ();
				if (playsoundonce == false) {
					playsoundonce = true;
					gameObject.GetComponent<AudioSource>().PlayOneShot(coinsuccesssound);
					playsoundonce = false;
				}
			}
			if(PlayerPrefs.GetString("Coins_Level_1") == "Silver") {
				GameObject bronzeobj = (GameObject)Instantiate(bronzecoinpref, new Vector3(-2.63f, -4.74f, -0.04f), Quaternion.identity);
				Tween bronzescaler = bronzeobj.transform.DOScale (new Vector3 (0.08f, 0.08f, 1f), 0.3f);
				yield return bronzescaler.WaitForCompletion ();
				if (playsoundonce == false) {
					playsoundonce = true;
					gameObject.GetComponent<AudioSource>().PlayOneShot(coinsuccesssound);
					playsoundonce = false;
				}
				GameObject silverobj = (GameObject)Instantiate(silvercoinpref, new Vector3(-2.44f, -4.77f, -0.04f), Quaternion.identity);
				Tween silverscaler = silverobj.transform.DOScale (new Vector3 (0.08f, 0.08f, 1f), 0.3f);
				yield return silverscaler.WaitForCompletion ();
				if (playsoundonce == false) {
					playsoundonce = true;
					gameObject.GetComponent<AudioSource>().PlayOneShot(coinsuccesssound);
					playsoundonce = false;
				}
			}
			if(PlayerPrefs.GetString("Coins_Level_1") == "Gold") {
				GameObject bronzeobj = (GameObject)Instantiate(bronzecoinpref, new Vector3(-2.63f, -4.74f, -0.04f), Quaternion.identity);
				Tween bronzescaler = bronzeobj.transform.DOScale (new Vector3 (0.08f, 0.08f, 1f), 0.3f);
				yield return bronzescaler.WaitForCompletion ();
				if (playsoundonce == false) {
					playsoundonce = true;
					gameObject.GetComponent<AudioSource>().PlayOneShot(coinsuccesssound);
					playsoundonce = false;
				}
				GameObject silverobj = (GameObject)Instantiate(silvercoinpref, new Vector3(-2.44f, -4.77f, -0.04f), Quaternion.identity);
				Tween silverscaler = silverobj.transform.DOScale (new Vector3 (0.08f, 0.08f, 1f), 0.3f);
				yield return silverscaler.WaitForCompletion ();
				if (playsoundonce == false) {
					playsoundonce = true;
					gameObject.GetComponent<AudioSource>().PlayOneShot(coinsuccesssound);
					playsoundonce = false;
				}
				GameObject goldobj = (GameObject)Instantiate(goldcoinpref, new Vector3(-2.25f, -4.74f, -0.04f), Quaternion.identity);
				Tween goldscaler = goldobj.transform.DOScale (new Vector3 (0.08f, 0.08f, 1f), 0.3f);
				yield return goldscaler.WaitForCompletion ();
				if (playsoundonce == false) {
					playsoundonce = true;
					gameObject.GetComponent<AudioSource>().PlayOneShot(coinsuccesssound);
					playsoundonce = false;
				}
			}

			Tween moveplayermarker = playermarker.GetComponent<Transform>().DOMove(new Vector3(-0.89f, -3.32f, -0.03f), 2f);
			yield return moveplayermarker.WaitForCompletion ();
			Instantiate(lburst, new Vector3(-0.9f, -3.86f, -0.05f), Quaternion.identity);
			GameObject levelmark = (GameObject)Instantiate(levelmarker, new Vector3(-0.89f, -3.86f, -0.03f), Quaternion.identity);
			levelmark.name = "levelmarker2";
			levelmark.GetComponentInChildren<TextMesh>().text = "2";
			Instantiate(levelhighlight, new Vector3(-0.89f, -4f, -0.01f), Quaternion.identity);


		}
		if (PlayerPrefs.GetInt ("unlocked_level") == 2 && PlayerPrefs.GetString ("unlocked_level_anim_2") == "False") {
			StartCoroutine (SetCurrLevel());
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 3 && PlayerPrefs.GetString("unlocked_level_anim_3") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_3", "False");
			
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 4 && PlayerPrefs.GetString("unlocked_level_anim_4") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_4", "False");
			
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 5 && PlayerPrefs.GetString("unlocked_level_anim_5") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_5", "False");
			
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 6 && PlayerPrefs.GetString("unlocked_level_anim_6") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_6", "False");
			
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 7 && PlayerPrefs.GetString("unlocked_level_anim_7") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_7", "False");
			
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 8 && PlayerPrefs.GetString("unlocked_level_anim_8") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_8", "False");
			
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 9 && PlayerPrefs.GetString("unlocked_level_anim_9") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_9", "False");
			
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 10 && PlayerPrefs.GetString("unlocked_level_anim_10") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_10", "False");
			
		}
		if (PlayerPrefs.GetInt("unlocked_level") == 11 && PlayerPrefs.GetString("unlocked_level_anim_11") == "True") {
			PlayerPrefs.SetString("unlocked_level_anim_11", "False");
			
		}

		yield return null;
	}

	public IEnumerator SetCurrLevel() {
		GameObject levelhighlighter = (GameObject)GameObject.Find ("levelhighlighter");
		GameObject playermarker = (GameObject)GameObject.Find ("playermarker");
		Destroy (levelhighlighter);
		Destroy (playermarker);
		if (PlayerPrefs.GetInt ("unlocked_level") == 2 && PlayerPrefs.GetString ("unlocked_level_anim_2") == "False") {
			GameObject levelmark = (GameObject)Instantiate(levelmarker, new Vector3(-0.89f, -3.86f, -0.03f), Quaternion.identity);
			levelmark.name = "levelmarker2";
			levelmark.GetComponentInChildren<TextMesh>().text = "2";
			Instantiate(levelhighlight, new Vector3(-0.89f, -4f, -0.01f), Quaternion.identity);
			Instantiate(playermarker, new Vector3(-0.89f, -3.32f, -0.03f), Quaternion.identity);
		}


			yield return null;
	}
}
