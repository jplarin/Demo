using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
    public float moveTime = 0.1f;

    private Rigidbody2D rb2d;
    private CircleCollider2D circleCollider2D;
    private float inverseMoveTime;

	// Use this for initialization
    //can be overidden by inheriting classes
	protected virtual void Start () {
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
	}

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while(sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2d.position, end, inverseMoveTime * Time.deltaTime);
            rb2d.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }

    protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        circleCollider2D.enabled = false;
        hit = Physics2D.Linecast(start, end);
        circleCollider2D.enabled = true;

        if(hit.transform == null)
        {
            StartCoroutine(SmoothMovement (end));
            return true;
        }

        return false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
