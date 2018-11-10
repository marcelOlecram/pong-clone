using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region variables
    // public
    public float speed = 5f;
    public float limitY = 1f;
    // private
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;
    private float height;
    private bool moveUpRequest;
    private bool moveDownRequest;
    private Vector2 velocity;
    #endregion

    #region UnityMethods
    // Use this for initialization
    private void Start () {
        SetInitialReferences();
        //Debug.Log(height);
	}
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            moveUpRequest = true;
        }else
        {
            moveUpRequest = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDownRequest = true;
        }
        else
        {
            moveDownRequest = false;
        }
    }

    private void FixedUpdate()
    {
        if (moveUpRequest && moveDownRequest)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }
        if (!moveUpRequest && !moveDownRequest)
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
        pos.y = Mathf.Clamp(pos.y, (-limitY + height /2), (limitY - height/2));
        _transform.position = pos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(0f, -limitY), new Vector3(0, limitY));
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
	#endregion
}

