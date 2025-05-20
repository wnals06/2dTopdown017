using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{

    float moveSpeed = 2f;

    [SerializeField] Sprite spriteUp;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;
    [SerializeField] TextMeshProUGUI scoreText;
    Rigidbody2D rb;

    SpriteRenderer sr;

    Vector2 input;

    Vector2 velocity;

    int score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
 
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");       //방향키 상하좌우 or wasd로 움지이게 가능

        velocity = input.normalized * moveSpeed;

        if(input.sqrMagnitude > .01f)
        {
            if (MathF.Abs(input.x) > MathF.Abs(input.y))
            {
                if (input.x > 0)
                    sr.sprite = spriteRight;
                else if (input.x < 0)
                    sr.sprite = spriteLeft;
            }
            else
            {
                if (input.y > 0)
                    sr.sprite = spriteUp;
                else
                    sr.sprite = spriteDown;
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            score += collision.GetComponent<ItemObject>().GetPoint();
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
