using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

	public Transform[] waypoints;
	public float speed = 0.3f;
	private Vector3 startPos;

	enum State { Wait, Init, Scatter, Chase, Run };
	State state;

	int index = 0;

	private Rigidbody2D rb2d;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
	}

	// Update is called once per frame
	void Update () {

	}

	private void FixedUpdate()
	{
		/*
		if(transform.position != waypoints[index].position)
		{
			Vector2 newPosition = Vector2.MoveTowards(transform.position, waypoints[index].position, speed);
			rb2d.MovePosition(newPosition);
			Debug.Log("Moving towards position");
		}
		else
		{
			index = (index + 1) % waypoints.Length;
			Debug.Log("New waypoint index is " + index);
		}

		Vector2 dir = waypoints[index].position - transform.position;
		animator.SetFloat("DirX", dir.x);
		animator.SetFloat("DirY", dir.y);
		*/
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Destroy(collision.gameObject);
		}
	}

	public void InitializeGhost()
	{
		startPos = getStartPosAccordingToName();
		//waypoints = transform.position;	
		state = State.Wait;
		//timeToEndWait = Time.time + waitLength + UINav.initialDelay;
		InitializeWaypoints(state);
	}

	private Vector3 getStartPosAccordingToName()
	{
		switch (gameObject.name)
		{
		case "blinky":
			return new Vector3(15f, 20f, 0f);

		case "pinky":
			return new Vector3(14.5f, 17f, 0f);

		case "inky":
			return new Vector3(16.5f, 17f, 0f);

		case "clyde":
			return new Vector3(12.5f, 17f, 0f);
		}

		return new Vector3();
	}

	private void InitializeWaypoints(State st)
	{

		string data = "";
		switch (name)
		{
		case "blinky":
			data = @"22 20
				     22 26

                     27 26
				 	 27 30
				 	 22 30
					 22 26";
			break;
		case "pinky":
			data = @"14.5 17
					 14 17
					 14 20
					 7 20

					 7 26
					 7 30
					 2 30
					2 26";
			break;
		case "inky":
			data = @"16.5 17
					 15 17
					 15 20
					 22 20

					 22 8
					 19 8
					 19 5
					 16 5
					 16 2
					 27 2
					 27 5
					 22 5";
			break;
		case "clyde":
			data = @"12.5 17
					 14 17
					 14 20
					 7 20

					 7 8
					 7 5
					 2 5
					 2 2
					13 2
					13 5
					10 5
					10 8";
			break;

		}
	}
}
