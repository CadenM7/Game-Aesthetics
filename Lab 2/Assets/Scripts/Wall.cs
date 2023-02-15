using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public string text;

    public void OnCollisionEnter2D(Collision2D collision2D) {
        print("Hit something");
        if (collision2D.gameObject.CompareTag("Player")) {
            GameManager.Instance.DialogShow(text);
        }
    }
    public void OnCollisionExit2D(Collision2D collision2D) {
        if (collision2D.gameObject.CompareTag("Player")) {
            GameManager.Instance.DialogHide();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
