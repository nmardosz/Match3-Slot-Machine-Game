using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreTextPop : MonoBehaviour {

	public int scoretodisp;
	TextMesh thetextpop;
	float startypos;
	float enddespos;



	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		startypos = gameObject.transform.position.y;
		enddespos = gameObject.transform.position.y + 1;

		gameObject.transform.DOMove (new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1.5f, 0), 2f);

	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y > enddespos) {
			Destroy (gameObject);
		}
	}

	void Awake() {
		thetextpop = gameObject.GetComponent<TextMesh> ();
		thetextpop.text = scoretodisp.ToString ();
	}
}
