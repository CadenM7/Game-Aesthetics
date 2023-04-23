using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    public GameObject player;

    private int score;

    private int getScore;

    public TextMeshProUGUI scoreText;

    public TilemapCollider2D CompleteObj;

    public void DialogShow(string text) {
        dialogBox.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TypeText(text));
    }

    public void DialogHide() {
        dialogBox.SetActive(false);
    }

    IEnumerator TypeText(string text) {
        dialogText.text = "";
        foreach (char c in text.ToCharArray()) {
            dialogText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
    }

   void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    public void IncScore(int val) {
        score += val;
        if (score < 0) {
            score = 0;
        }
        scoreText.text = "Seeds : " + score;
    }

    public void Win()
    {
        if (score == 15) {
            DialogShow("You have all 15 seeds !!! You are free from this cage.");
            // Player.body.velocity = new Vector2(0,0);
        }
    }

    private void Start()
    {
        CompleteObj = GetComponent<TilemapCollider2D>();
    }
 
    private void Update ()
    {
        if (score == 15)
        {
            CompleteObj.enabled = false;
        }
    }
}
