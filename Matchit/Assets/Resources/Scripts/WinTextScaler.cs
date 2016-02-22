using UnityEngine;
using System.Collections;
using DG.Tweening;

public class WinTextScaler : MonoBehaviour {
	
	Tween texttween;
	Vector3 maxsize;

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		texttween = gameObject.transform.DOScale (new Vector3 (.01f, .01f, 0), 2f);

	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.localScale.x > .009f && gameObject.transform.localScale.y > .009f) {
			Destroy (gameObject);
		}
	
	}
}
