using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private Rigidbody2D rb;
	private bool collidingLeft;
	private bool collidingRight;
	private bool collidingTop;
	private bool collidingBottom;
	private bool isPlaying;
	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		collidingLeft = false;
		collidingRight = false;
		collidingTop = false;
		collidingBottom = false;
		isPlaying = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (isPlaying)
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				rb.velocity = new Vector2(rb.velocity.x, 50);
			}
			else if (Input.GetKeyDown(KeyCode.S))
			{
				rb.velocity = new Vector2(rb.velocity.x, -50);
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				rb.velocity = new Vector2(-50, rb.velocity.y);
			}
			else if (Input.GetKeyDown(KeyCode.D))
			{
				rb.velocity = new Vector2(50, rb.velocity.y);
			}
		}
		else
		{
			Time.timeScale = 0;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 pos = collision.collider.transform.position;
		float timer = collision.collider.GetComponent<Wall>().timer;

		if (collision.collider.name == "Left Wall")
		{
			collidingLeft = true;
			collision.otherCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 0));
			if (pos.x > -9 && timer <= 0)
			{
				collision.collider.transform.position = new Vector2(pos.x - 1, pos.y);
				collision.collider.GetComponent<Wall>().timer = 3;
			}
		}
		else if (collision.collider.name == "Right Wall")
		{
			collidingRight = true;
			collision.otherCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
			if (pos.x < 9 && timer <= 0)
			{
				collision.collider.transform.position = new Vector2(pos.x + 1, pos.y);
				collision.collider.GetComponent<Wall>().timer = 3;
			}
		}
		else if (collision.collider.name == "Floor")
		{
			collidingBottom = true;
			collision.otherCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
			if (pos.y > -5 && timer <= 0)
			{
				collision.collider.transform.position = new Vector2(pos.x, pos.y - 1);
				collision.collider.GetComponent<Wall>().timer = 3;
			}
		}
		else if (collision.collider.name == "Ceiling")
		{
			collidingTop = true;
			collision.otherCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
			if (pos.y < 5 && timer <= 0)
			{
				collision.collider.transform.position = new Vector2(pos.x, pos.y + 1);
				collision.collider.GetComponent<Wall>().timer = 3;
			}
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collidingRight && collidingLeft)
		{
			isPlaying = false;
		}
		else if (collidingTop && collidingBottom)
		{
			isPlaying = false;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.name == "Left Wall")
		{
			collidingLeft = false;
		}
		else if (collision.collider.name == "Right Wall")
		{
			collidingRight = false;
		}
		else if (collision.collider.name == "Floor")
		{
			collidingBottom = false;
		}
		else if (collision.collider.name == "Ceiling")
		{
			collidingTop = false;
		}
	}
}
