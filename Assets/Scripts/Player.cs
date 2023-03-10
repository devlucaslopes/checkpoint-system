using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;

    private Rigidbody2D rb;
    private Animator anim;

    private float _direction;
    private bool _canUseCheckpoint;
    private Vector3 _checkpointPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canUseCheckpoint)
        {
            GameManager.Instance.SaveCheckpoint(_checkpointPosition);
            anim.SetTrigger("save");
        }

        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(_direction * Speed, rb.velocity.y);

        Flip();

        // anim.SetInteger("transitionIndex", _direction != 0 ? 1 : 0);

        if (_direction != 0)
        {
            anim.SetInteger("transitionIndex", 1);
        } else
        {
            anim.SetInteger("transitionIndex", 0);
        }
    }

    private void Flip()
    {
        if (_direction > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            _canUseCheckpoint = true;
            _checkpointPosition = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            _canUseCheckpoint = false;
            _checkpointPosition = Vector3.zero;
        }
    }
}
