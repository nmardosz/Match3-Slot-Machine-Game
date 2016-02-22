using UnityEngine;
using System.Collections;

public class BurstDestroyer : MonoBehaviour
{
	public AnimationClip anim;

	IEnumerator Start() {
		yield return new WaitForSeconds(anim.length);
		Destroy (gameObject);
	}
	
}