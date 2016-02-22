using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CoinsAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		gameObject.transform.DOScale (new Vector3 (0.08f, 0.08f, 1f), 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
