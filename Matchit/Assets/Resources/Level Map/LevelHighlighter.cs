using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LevelHighlighter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		Tween highlighterx = gameObject.transform.DOScaleX (1.5f, 0.7f).SetLoops(-1, LoopType.Restart);
		Tween highlightery = gameObject.transform.DOScaleY (1.25f, 0.7f).SetLoops(-1, LoopType.Restart);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
