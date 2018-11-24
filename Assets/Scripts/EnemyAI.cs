using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    #region variables
    // public
    public float speed = 3f;
    public float limitY = 1f;
    public float errorMargin = 0.1f;
    // private
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;
    private float height;
    private bool moveUpRequest;
    private bool moveDownRequest;
    private Vector2 velocity;
    private Transform ballInGame;
    private Rigidbody2D ballRB;
    [SerializeField]
    private bool isComingToMe;
    #endregion

    #region UnityMethods
    // Use this for initialization
    private void Start () {
        SetInitialReferences();
    }
	
	// Update is called once per frame
	private void Update () {
        if (ballInGame == null)
        {
            return;
        }
        // check if ball is coming
        if (ballRB.velocity.x > 0f)
        {
            isComingToMe = true;
        }else
        {
            isComingToMe = false;
        }
        if (isComingToMe)
        {
            if (ballInGame.position.y >= transform.position.y - errorMargin &&
                ballInGame.position.y <= transform.position.y + errorMargin)
            {
                Debug.Log("NotMove");
                moveUpRequest = false;
                moveDownRequest = false;
                return;
            }
            if (ballInGame.position.y > transform.position.y)
            {
                Debug.Log("MoveUp");
                moveUpRequest = true;
                moveDownRequest = false;
                return;
            }
            if (ballInGame.position.y < transform.position.y)
            {
                Debug.Log("ModeDown");
                moveDownRequest = true;
                moveUpRequest = false;
                return;
            }
        }
	}

    private void FixedUpdate()
    {
        if ((moveUpRequest && moveDownRequest) || (!moveUpRequest && !moveDownRequest))
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }
        if (moveUpRequest)
        {
            velocity = _rigidbody.velocity;
            velocity.y = speed;
            _rigidbody.velocity = velocity;
            return;
        }
        if (moveDownRequest)
        {
            velocity = _rigidbody.velocity;
            velocity.y = -speed;
            _rigidbody.velocity = velocity;
            return;
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = _transform.position;
        pos.y = Mathf.Clamp(pos.y, (-limitY + height / 2), (limitY - height / 2));
        _transform.position = pos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y - errorMargin),
            (new Vector3(transform.position.x, transform.position.y + errorMargin)));
    }
    #endregion

    #region MyMethods
    private void SetInitialReferences()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        velocity = _rigidbody.velocity;
        spriteRenderer = GetComponent<SpriteRenderer>();
        height = spriteRenderer.bounds.size.y;
        Vector3 limit = Camera.main.ViewportToWorldPoint(new Vector3(0, 1f));
        //Debug.Log(limitY);
        limitY = limit.y;
        //Debug.Log(limitY);
    }

    public void SetBallInGame(Transform ball)
    {        
        ballInGame = ball;
        ballRB = ballInGame.GetComponent<Rigidbody2D>();
    }
    #endregion
}
