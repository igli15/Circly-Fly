using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainDrop : MonoBehaviour,IPooleableObject
{
	private SpriteRenderer spriteRender;

	private float speed;


	private void Update()
	{
		transform.Translate(-transform.up * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("BottomBoundary"))
		{
			ObjectPooler.instance.DestroyFromPool("RainDrop",gameObject);
		}
	}

	public void OnObjectSpawn()
	{
		spriteRender = GetComponent<SpriteRenderer>();

		spriteRender.color = new Color(1,1,1,Random.Range(0.1f,0.2f));
		
		
		transform.localScale = new Vector3(Random.Range(0.01f,0.015f),Random.Range(0.01f,0.015f),0);

		speed = Random.Range(2,5);
	}
}
