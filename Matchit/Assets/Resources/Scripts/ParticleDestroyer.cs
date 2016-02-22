using UnityEngine;
using System.Collections;

public class ParticleDestroyer : MonoBehaviour
{
	
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(GetComponent<ParticleSystem>().startLifetime);
		Destroy(gameObject); 
	}
	
}