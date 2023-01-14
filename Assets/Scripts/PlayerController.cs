using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D model;
    private float koef;
    private float high_jump;
    private bool status_jump;
    private float left_right;
    private float up_down;
    private Vector2 force;

    // Before the first frame update
    void Start()
    {
        model = gameObject.GetComponent<Rigidbody2D>();
        koef = 2f;
        high_jump = 35f;
        status_jump = false;

    }

    // Update frame
    void Update()
    {
        left_right = Input.GetAxisRaw("Horizontal");
        up_down = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        if(left_right > 0.1f || left_right < 0.1f)
        {
            force = new Vector2(left_right * koef, 0f);
            model.AddForce(force, ForceMode2D.Impulse);
        }

        if (up_down > 0.1f && status_jump == false)
        {
            force = new Vector2(0f, up_down * high_jump);
            model.AddForce(force, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "terrain")
        {
            status_jump = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            status_jump = true;
        }
    }
}