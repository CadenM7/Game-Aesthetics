using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D body;
    public float horizontal;
    public float vertical;

    private float moveLimiter = 0.7f;

    public float runSpeed = 5f;
    public GameObject prefab;

//art is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
            
        if (Input.GetMouseButtonDown(0))
        //if (Input.GetKeyDown("e"))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }

    void FixedUpdate() {
        if (horizontal != 0 && vertical != 0) {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        print("Collided with seed");
        if (collision2D.gameObject.CompareTag("seed"))
        {
            Physics2D.IgnoreLayerCollision(1, 2, true);

        }
    }
    public void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("seed"))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
    }

}
