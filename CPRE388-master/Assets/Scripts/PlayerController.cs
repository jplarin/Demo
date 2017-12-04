using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    //public float speed = .1f;

    public Text countText;
	private ScoreManager SM;
	private UINavigation UINav;
	private GameManager GM;
	private bool deadPlaying = false;
    private int cout;
    private Vector2 destination = Vector2.zero;
    private Rigidbody2D rb; 
    private CircleCollider2D circleCollider;
    private Animator animator;
    

	// Use this for initialization
	void Start () {
		SM = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
        cout = 0;
        setCountText();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    { 
        if(Input.GetKey(KeyCode.UpArrow) && validMove(Vector2.up))
        {
            rb.MovePosition(rb.position + Vector2.up * .2f);
            destination = rb.position + Vector2.up;
        }
        else if(Input.GetKey(KeyCode.DownArrow) && validMove(Vector2.down))
        {
            rb.MovePosition(rb.position + Vector2.down * .2f);
            destination = rb.position + Vector2.down;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && validMove(Vector2.left))
        {
            rb.MovePosition(rb.position + Vector2.left * .2f);
            destination = rb.position + Vector2.left;
        }
        else if(Input.GetKey(KeyCode.RightArrow) && validMove(Vector2.right))
        {
            rb.MovePosition(rb.position + Vector2.right * .2f);
            destination = rb.position + Vector2.right;
        }

        Vector2 direction = destination - (Vector2)transform.position;
        animator.SetFloat("DirX", direction.x);
        animator.SetFloat("DirY", direction.y);
    }

    private bool validMove(Vector2 direction)
    {
        Vector2 start = transform.position;
        Vector2 end = start + direction;
        RaycastHit2D hit;

        circleCollider.enabled = false;
        hit = Physics2D.Linecast(start, end);
        circleCollider.enabled = true;

		if((hit.transform == null) || (hit.collider.name != "maze"))
        {
            return true;
        }
        else
        {
            Debug.Log(hit.collider.name);
            return false;
        }

        /*Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        return (hit.collider == GetComponent<Collider2D>());*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PickUp"))
        {
            cout++;
            Destroy(collision.gameObject);
            setCountText();
        }
        else
        {

        }
    }

    private void setCountText()
    {
        countText.text = "Count: " + cout.ToString();
    }
		
}
