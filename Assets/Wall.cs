using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	public Vector2 vel;
	public float timer;
	private float time;
	// Start is called before the first frame update
	void Start()
	{
		gameObject.GetComponent<Rigidbody2D>().velocity = vel;
		timer = 0;
	}

	private void Update()
	{
		timer -= 3.2f * Time.deltaTime;
	}
}
