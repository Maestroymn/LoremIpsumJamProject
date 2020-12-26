using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmProjectile : MonoBehaviour
{

    [SerializeField] float xSpeed = 2f;

    private Rigidbody2D myRB;
    public GameObject player;
    private Animator animator;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        myRB.AddForce(new Vector2(-550, 0));
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("Bombbb");
            myRB.velocity = new Vector3(0, 0, 0);
            myRB.gravityScale = 0;
            animator.SetTrigger("Explode");
            Destroy(gameObject, 1f);
        }
    }
}
