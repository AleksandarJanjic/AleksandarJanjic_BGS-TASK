using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject playerGraphics;
    private Rigidbody2D rigidbody;
    private Vector2 playerInput;
    private Vector2 playerInputNormalized;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        playerInputNormalized = playerInput.normalized;
    }

    void FixedUpdate()
    {
        rigidbody.velocity = playerInputNormalized * speed;
        if(rigidbody.velocity.x > 0)
        {
            playerGraphics.transform.localScale = new Vector2(-4, 4);
        } else if(rigidbody.velocity.x < 0)
        {
            playerGraphics.transform.localScale = new Vector2(4, 4);
        }
    }
}
