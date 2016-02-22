using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PrizeWheelSpinner : MonoBehaviour {

	public AnimationCurve animationcurve;
	public bool spinning;
	public bool donespin;
	public GameObject theactualspinner;
	public GameObject gridgen;

	public int valuelandedon;

	private Vector2 startPosition;
	private Vector2 endPosition;

	PolygonCollider2D[] allChildren;

	public GameObject swipetospinarrow;
	public GameObject swipetospinactualarrow;
	public bool swipetospinarrowactive;
	public bool readytorepeat;

	public GameObject swipetext;

	void Start() {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		allChildren = GetComponentsInChildren<PolygonCollider2D>();
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		spinning = false;
		donespin = false;
		foreach (PolygonCollider2D child in allChildren)
		{
			child.enabled = false;
		}

		swipetospinarrow.gameObject.GetComponent<Transform> ().localEulerAngles = new Vector3 (0,0,87f);
		swipetospinactualarrow.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		swipetospinarrowactive = false;
		swipetext.GetComponent<MeshRenderer> ().enabled = false;
	}

	void Update() {

		if (swipetospinarrowactive == true && readytorepeat == true) {
			swipetext.GetComponent<MeshRenderer> ().enabled = true;
			readytorepeat = false;
			swipetospinarrow.gameObject.GetComponent<Transform> ().localEulerAngles = new Vector3 (0,0,87f);
			StartCoroutine(SwipeToSpin());

		}

		if (Input.GetMouseButtonDown (0) && !spinning && gridgen.GetComponent<GridGen> ().bonusplay == true && gridgen.GetComponent<GridGen> ().bonustype == "spin") {
			startPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}

		if (Input.GetMouseButtonUp (0) && !spinning && gridgen.GetComponent<GridGen> ().bonusplay == true  && gridgen.GetComponent<GridGen> ().bonustype == "spin") {
			endPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}



		if (startPosition != endPosition && startPosition != Vector2.zero && endPosition != Vector2.zero && !spinning && gridgen.GetComponent<GridGen>().bonusplay == true   && gridgen.GetComponent<GridGen> ().bonustype == "spin") {
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			foreach (PolygonCollider2D child in allChildren)
			{
				child.enabled = true;
			}
			float deltaX = endPosition.x - startPosition.x;

			if (deltaX > 1.0f || deltaX < -1.0f) {
				if (startPosition.x < endPosition.x) {
						startPosition = endPosition = Vector2.zero;
						StartCoroutine (DoSpin(3.0f, Random.Range (-720, -1500)));
				}
				if (startPosition.x > endPosition.x) {
					startPosition = endPosition = Vector2.zero;
					StartCoroutine (DoSpin(3.0f, Random.Range (720, 1500)));
				}
			}
		}
	}

	public IEnumerator DoSpin(float time, float angle) {
		spinning = true;
		donespin = false;
		swipetospinarrowactive = false;
		swipetospinactualarrow.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		swipetext.GetComponent<MeshRenderer> ().enabled = false;
		float timer = 0;
		float startAngle = transform.eulerAngles.z;
		while (timer < time) {
			float endAngle = animationcurve.Evaluate (timer/time) * -angle;
			theactualspinner.transform.eulerAngles = new Vector3 (0.0f, 0.0f, (endAngle + startAngle));
			timer += Time.deltaTime;
			yield return 0;
		}
		spinning = false;
		donespin = true;

		foreach (PolygonCollider2D child in allChildren)
		{
			child.enabled = false;
		}
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;

		//while (timer >= time) {
		//	yield return null;
		//}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "WheelValue") {
			valuelandedon = col.gameObject.GetComponent<WheelValue>().wheelvalue;
		}
	}

	public IEnumerator SwipeToSpin() {
		swipetospinactualarrow.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		Tween swiperarrow = swipetospinarrow.transform.DORotate (new Vector3 (0, 0, -34f), 0.7f);
		yield return swiperarrow.WaitForCompletion ();
		readytorepeat = true;
	}


}
