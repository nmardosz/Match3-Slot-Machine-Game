using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CoinDropDestroyer : MonoBehaviour {

	float curypabove;
	bool above;

	public int myvalue;
	public static int myvalueis;

	// Use this for initialization
	void Start () {

		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		Sequence coinDropper = DOTween.Sequence ();

		float rander = Random.Range(1.0f,2.0f);
		float yander = Random.Range(1.0f,3.0f);
		float randtime = Random.Range (0.3f, 0.5000f);
		float randtimedrop = Random.Range (4.0f, 5.0f);

		if (gameObject.transform.position.x > 0) {
			coinDropper.Join (gameObject.transform.DOJump (new Vector3(gameObject.transform.position.x - rander, 0, 0),yander,1,randtime));
			//coinDropper.Join(gameObject.transform.DOMove(new Vector3(-rander, yander, 0), randtime).SetRelative().SetLoops(0, LoopType.Yoyo)).SetEase(Ease.InSine);

		}

		if (gameObject.transform.position.x < 0) {
			coinDropper.Join (gameObject.transform.DOJump (new Vector3(gameObject.transform.position.x + rander, 0, 0),yander,1,randtime));
			//coinDropper.Join(gameObject.transform.DOMove(new Vector3(rander, yander, 0), randtime).SetRelative().SetLoops(0, LoopType.Yoyo)).SetEase(Ease.InSine);
			
		}

		if (gameObject.transform.position.x == 0) {
			coinDropper.Join (gameObject.transform.DOJump (new Vector3(0, 0, 0),yander,1,randtime));
			//coinDropper.Join(gameObject.transform.DOMove(new Vector3(0, yander, 0), randtime).SetRelative().SetLoops(0, LoopType.Yoyo)).SetEase(Ease.InSine);
		}

		coinDropper.Append(gameObject.transform.DOMove(new Vector3(0, -10, 0), randtimedrop).SetRelative().SetLoops(0, LoopType.Yoyo));

		coinDropper.Play ();


	}

	void Update() {

	}
}
