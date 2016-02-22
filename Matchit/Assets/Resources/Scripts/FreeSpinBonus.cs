using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FreeSpinBonus : MonoBehaviour {

	public GameObject semiback;
	public GameObject backgrnd;
	public GameObject diceboard;
	public GameObject dice1;
	public GameObject dice2;
	public GameObject rollbtn;
	public Sprite rollact;
	public GameObject diceboardmrkr;
	public bool rolled;
	public Camera thecamera;
	public Sprite[] largedice;
	public GameObject rolledd1;
	public GameObject rolledd2;
	public GameObject rolledtotaltext;
	Vector3 startposition;
	Vector3 currentposition;
	Vector3 position1;
	Vector3 position2;
	Vector3 position3;
	Vector3 position4;
	Vector3 position5;
	Vector3 position6;
	Vector3 position7;
	Vector3 position8;
	Vector3 position9;

	public AnimationClip roll1;
	public AnimationClip roll2;

	public AudioSource markermoveaudio;
	public AudioClip movecompletesound;
	public AudioClip dicerollsound;

	public int boardmarkeron;
	public GameObject gridgen;

	public bool readytoplaydicegame;
	public GameObject spinscoretracker;



	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		boardmarkeron = 0;
		rolled = false;
		readytoplaydicegame = false;
		startposition = new Vector3 (0.92f, -3.81f, -10.035f);
		position1 = new Vector3 (0.92f, -3.81f, -10.035f);
		position2 = new Vector3 (-1.77f, -3.45f, -10.035f);
		position3 = new Vector3 (-3.57f, -1.48f, -10.035f);
		position4 = new Vector3 (-3.12f, 1f, -10.035f);
		position5 = new Vector3 (-1.74f, 2.68f, -10.035f);
		position6 = new Vector3 (0.42f, 3.91f, -10.035f);
		position7 = new Vector3 (2.85f, 2.61f, -10.035f);
		position8 = new Vector3 (3.58f, -1.35f, -10.035f);
		position9 = new Vector3 (1.81f, -3.37f, -10.035f);

		semiback.gameObject.GetComponent<Transform> ().position = new Vector3 (0,0,-10.06f);
		rollbtn.gameObject.GetComponent<Transform> ().position = new Vector3 (0,-7.15f,-10.07f);
		diceboard.gameObject.GetComponent<Transform> ().position = new Vector3 (0,0f,-10.03f);
		diceboardmrkr.gameObject.GetComponent<Transform> ().position = new Vector3 (0.92f,-3.81f,-10.035f);
		currentposition = position1;
		semiback.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		backgrnd.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		rollbtn.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		diceboard.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		diceboardmrkr.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		dice1.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		dice1.gameObject.GetComponent<Animator> ().enabled = false;
		dice2.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		dice2.gameObject.GetComponent<Animator> ().enabled = false;
		rolledd1.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		rolledd2.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		rolledtotaltext.gameObject.GetComponent<MeshRenderer> ().enabled = false;

		foreach (PolygonCollider2D child in diceboard.GetComponentsInChildren<PolygonCollider2D>())
		{
			child.enabled = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (rolled == true) {
			rolled = false;
			StartCoroutine (RollIt ());
		}
	}

	public IEnumerator RollIt() {
		int onerollsound = 0;
		if (onerollsound == 0) {
			onerollsound = 1;
			markermoveaudio.PlayOneShot (dicerollsound);
		}
		int randd1 = Random.Range (0,6);
		int randd2 = Random.Range (0,6);
		rolledd1.gameObject.GetComponent<SpriteRenderer> ().sprite = largedice[randd1];
		rolledd2.gameObject.GetComponent<SpriteRenderer> ().sprite = largedice[randd2];
		dice1.gameObject.GetComponent<Transform> ().localScale = new Vector3(1f,1f,1f);
		dice2.gameObject.GetComponent<Transform> ().localScale = new Vector3(1f,1f,1f);
		Sequence rolldicesequenced1 = DOTween.Sequence ();
		Sequence rolldicesequenced2 = DOTween.Sequence ();
		//calculate the world point of screen left edge
		Vector3 leftmiddleedged1 = thecamera.ScreenToWorldPoint(new Vector3(0 + 23, (Screen.height / 2) - 23, 8.2f));
		Vector3 leftmiddleedged2 = thecamera.ScreenToWorldPoint(new Vector3(0 + 23, (Screen.height / 2) + 23, 8.2f));
		//calculate the world point of screen top edge
		Vector3 topmiddleedged1 = thecamera.ScreenToWorldPoint(new Vector3((Screen.width/2) - 23, Screen.height, 8.2f));
		Vector3 topmiddleedged2 = thecamera.ScreenToWorldPoint(new Vector3((Screen.width/2) + 23, Screen.height, 8.2f));
		//calculate the world point of screen right edge
		Vector3 rightmiddleedged1 = thecamera.ScreenToWorldPoint(new Vector3(Screen.width - 23, (Screen.height / 2) + 23, 8.2f));
		Vector3 rightmiddleedged2 = thecamera.ScreenToWorldPoint(new Vector3(Screen.width - 23, (Screen.height / 2) - 23, 8.2f));
		//Dice End Point
		Vector3 endpointd1 = new Vector3(-1.5f, -2.82f, -11.8f);
		Vector3 endpointd2 = new Vector3(1.5f, -2.82f, -11.8f);
		dice1.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		dice1.gameObject.GetComponent<Animator> ().enabled = true;
		dice1.gameObject.GetComponent<Animator> ().SetBool ("playitd1", true);
		dice1.gameObject.GetComponent<Animator> ().SetBool ("stopitd1", false);
		dice2.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		dice2.gameObject.GetComponent<Animator> ().enabled = true;
		dice2.gameObject.GetComponent<Animator> ().SetBool ("playitd2", true);
		dice2.gameObject.GetComponent<Animator> ().SetBool ("stopitd2", false);
		print ("left" + leftmiddleedged1);
		print ("top" + topmiddleedged1);
		print ("right" + rightmiddleedged1);

		rolldicesequenced1.Append (dice1.transform.DOMove(leftmiddleedged1,0.2f));
		rolldicesequenced2.Append (dice2.transform.DOMove(leftmiddleedged2,0.3f));
		rolldicesequenced1.Append (dice1.transform.DOMove(topmiddleedged1,0.3f));
		rolldicesequenced2.Append (dice2.transform.DOMove(topmiddleedged2,0.2f));
		rolldicesequenced1.Append (dice1.transform.DOMove(rightmiddleedged1,0.2f));
		rolldicesequenced2.Append (dice2.transform.DOMove(rightmiddleedged2,0.3f));
		rolldicesequenced1.Append (dice1.transform.DOMove(endpointd1,0.2f));
		rolldicesequenced2.Append (dice2.transform.DOMove(endpointd2,0.3f));
		rolldicesequenced1.Join (dice1.transform.DOScale(new Vector3(3f,3f,0),0.2f));
		rolldicesequenced2.Join (dice2.transform.DOScale(new Vector3(3f,3f,0),0.3f));

		rolldicesequenced1.Play ();
		rolldicesequenced2.Play ();
		yield return rolldicesequenced1.WaitForCompletion ();
		dice1.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		dice1.gameObject.GetComponent<Animator> ().enabled = false;
		dice1.gameObject.GetComponent<Animator> ().SetBool ("stopitd1", true);
		dice1.gameObject.GetComponent<Animator> ().SetBool ("playitd1", false);
		rolledd1.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		yield return rolldicesequenced2.WaitForCompletion ();
		dice2.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		dice2.gameObject.GetComponent<Animator> ().enabled = false;
		dice2.gameObject.GetComponent<Animator> ().SetBool ("stopitd2", true);
		dice2.gameObject.GetComponent<Animator> ().SetBool ("playitd2", false);
		rolledd2.gameObject.GetComponent<SpriteRenderer> ().enabled = true;

		yield return new WaitForSeconds (2);

		rolledd1.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		rolledd2.gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		int rolledtotal = (randd1 + 1) + (randd2 + 1);

		rolledtotaltext.gameObject.GetComponent<TextMesh> ().text = rolledtotal.ToString ();
		rolledtotaltext.gameObject.GetComponent<MeshRenderer> ().enabled = true;

		semiback.gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		Sequence MarkerSequence = DOTween.Sequence ();

		for (int i = 0; i < rolledtotal; i++) {
			int justonce = 0;
			if(currentposition == position1 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position2,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position2;
				justonce++;
			}
			if(currentposition == position2 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position3,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position3;
				justonce++;

			}
			if(currentposition == position3 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position4,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position4;
				justonce++;

			}
			if(currentposition == position4 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position5,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position5;
				justonce++;

			}
			if(currentposition == position5 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position6,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position6;
				justonce++;

			}
			if(currentposition == position6 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position7,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position7;
				justonce++;

			}
			if(currentposition == position7 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position8,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position8;
				justonce++;

			}
			if(currentposition == position8 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position9,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position9;
				justonce++;

			}
			if(currentposition == position9 && justonce == 0) {
				Tween movemarker = diceboardmrkr.transform.DOMove(position1,0.5f);
				yield return movemarker.WaitForCompletion();
				markermoveaudio.PlayOneShot(movecompletesound);
				currentposition = position1;
				justonce++;

			}
		}

		//MarkerSequence.Play ();
		//yield return MarkerSequence.WaitForCompletion ();

		boardmarkeron += diceboardmrkr.GetComponent<BoardMarkerOn> ().markeron;


		spinscoretracker.gameObject.GetComponent<Spinner> ().freespin = true;

		readytoplaydicegame = false;

		yield return null;
	}

	public IEnumerator EnableDiceGame() {
		rollbtn.GetComponent<SpriteRenderer> ().sprite = rollact;
		semiback.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		backgrnd.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		rollbtn.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		rollbtn.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		diceboard.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		diceboardmrkr.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		diceboardmrkr.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		
		foreach (PolygonCollider2D child in diceboard.GetComponentsInChildren<PolygonCollider2D>())
		{
			child.enabled = true;
		}

		rollbtn.GetComponent<FreeSpinButton> ().canroll = true;

		yield return null;
	}

	public IEnumerator DisableDiceGame() {
		semiback.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		backgrnd.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		rollbtn.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		rollbtn.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		diceboard.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		diceboardmrkr.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		diceboardmrkr.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		rolledtotaltext.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		
		foreach (PolygonCollider2D child in diceboard.GetComponentsInChildren<PolygonCollider2D>())
		{
			child.enabled = false;
		}

		yield return null;
		
	}

}
