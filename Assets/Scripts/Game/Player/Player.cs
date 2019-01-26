using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 4f;

    private bool isDead = false;

    private Rigidbody2D rb;
    private Animator animator;
    private DudeController dudeController;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dudeController = GetComponent<DudeController>();
    }
	
	// Update is called once per frame
	void Update () {
		if(!isDead) {
            HandleMovement();
        }
	}

    private void HandleMovement() {
        /* HORIZONTAL MOVEMENT */
        float dx = HandleHorizontalMovement(dudeController.DudeHorizontal() != 0f);

        if(dx > 0 || dx < 0) {
            animator.SetFloat("hSpeed", dx);
        }
        
        /* VERTICAL MOVEMENT */
        float dy = HandleVerticalMovement(dudeController.DudeVertical() != 0f);

        /* UPDATE RB */
        rb.velocity = new Vector2(dx, dy);
    }

    private float HandleHorizontalMovement(bool isHorizontal) {
        float dx = rb.velocity.x;

        if (isHorizontal) {
            dx = speed * dudeController.DudeHorizontal();
        }

        return dx;
    }

    private float HandleVerticalMovement(bool isVertical) {
        float dy = rb.velocity.y;

        if (isVertical) {
            dy = speed * dudeController.DudeVertical();
        }

        return dy;
    }
}
