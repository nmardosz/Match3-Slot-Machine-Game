using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {


	public int startingcredits;
	public int won;
	public float targetscore;
	public float secondscore;
	public float thirdscore;
	public int startingbet;
	public GameObject coin;
	public GameObject progbar;

	public Text dascore;

	public float targpercscale;
	public float secondpercscale;
	public float thirdpercscale;
	public float startxpos;
	public float hundpercxpos;
	public float secondachievementpos;
	public float thirdachievementpos;
	public float maxposition;

	public Text credits;
	public Text bet;
	public Text targettext;

	public int credtracker;
	public int bettracker;

	public AudioSource coindroppersound;
	public AudioClip coindropsound3;
	public AudioClip coindropsound4;
	public AudioClip coindropsound5;
	public AudioClip coindropsound6;
	public AudioClip coindropsound7;
	public AudioClip coindropsound8;
	public AudioClip coindropsound9;
	public AudioClip targetachieved;

	public bool targetachievedplayonce;

	public GameObject freespins;
	public GameObject thespinner;

	int coincounter;



	// Use this for initialization
	void Start () {

		targetachievedplayonce = false;
		targettext.text = "Target: " + targetscore;

		credtracker = startingcredits;
		bettracker = startingbet;

		won = 0;


	}

	void Update() {
		dascore.text = won.ToString();
		credits.text = credtracker.ToString ();
		if (thespinner.gameObject.GetComponent<Spinner> ().freespin == false) {
			bet.rectTransform.localScale = new Vector3(0.7f, 0.7f, 1f);
			bet.text = bettracker.ToString ();
		}
		if (thespinner.gameObject.GetComponent<Spinner> ().freespin == true) {
			bet.rectTransform.localScale = new Vector3(0.3f, 0.3f, 1f);
			bet.text = "Free Spins " + freespins.GetComponent<FreeSpinBonus>().boardmarkeron.ToString ();
		}	
	}
	

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Coin") {
			if (!coindroppersound.isPlaying && col.gameObject.GetComponent<CoinDropDestroyer>().myvalue > 30) {
				coindroppersound.PlayOneShot(coindropsound5);
			}
			if (!coindroppersound.isPlaying && col.gameObject.GetComponent<CoinDropDestroyer>().myvalue > 20 && col.gameObject.GetComponent<CoinDropDestroyer>().myvalue <= 30) {
				coindroppersound.PlayOneShot(coindropsound4);
			}
			if (!coindroppersound.isPlaying && col.gameObject.GetComponent<CoinDropDestroyer>().myvalue == 20) {
				coindroppersound.PlayOneShot(coindropsound3);
			}
			if(won < targetscore) {
				float scalehowmuch = (col.gameObject.GetComponent<CoinDropDestroyer>().myvalue / targetscore) * targpercscale;
				float tranhowmuch = (col.gameObject.GetComponent<CoinDropDestroyer>().myvalue / targetscore) * (hundpercxpos - startxpos);
				progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
				progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
				won += col.gameObject.GetComponent<CoinDropDestroyer>().myvalue;
				Destroy (col.gameObject);
			}
			if(won >= targetscore && won <= secondscore) {
				if(targetachievedplayonce == false){
					coindroppersound.PlayOneShot(targetachieved);
					targetachievedplayonce = true;
				}
				float scalehowmuch = (col.gameObject.GetComponent<CoinDropDestroyer>().myvalue / secondscore) * secondpercscale;
				float tranhowmuch = (col.gameObject.GetComponent<CoinDropDestroyer>().myvalue / secondscore) * (secondachievementpos - startxpos);
				progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
				progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
				won += col.gameObject.GetComponent<CoinDropDestroyer>().myvalue;
				Destroy (col.gameObject);
			}
			if(won > secondscore) {
				if(progbar.GetComponent<Transform>().localScale.x < thirdpercscale) {
					float scalehowmuch = (col.gameObject.GetComponent<CoinDropDestroyer>().myvalue / thirdscore) * thirdpercscale;
					float tranhowmuch = (col.gameObject.GetComponent<CoinDropDestroyer>().myvalue / thirdscore) * (thirdachievementpos - startxpos);
					progbar.transform.localScale += new Vector3(scalehowmuch, 0, 0);
					progbar.transform.position += new Vector3(tranhowmuch/2f, 0, 0);
				}
				won += col.gameObject.GetComponent<CoinDropDestroyer>().myvalue;
				Destroy (col.gameObject);
			}
		}
	}
}
