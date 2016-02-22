using UnityEngine;
using System.Collections;

public class LevelBurstDestroyer : MonoBehaviour {

	public AnimationClip anim;
	
	IEnumerator Start() {
		yield return new WaitForSeconds(anim.length);
		Destroy (gameObject);
	}
}
