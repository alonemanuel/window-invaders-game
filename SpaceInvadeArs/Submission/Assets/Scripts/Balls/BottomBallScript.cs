using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BottomBallScript : MonoBehaviour
{

    public float speed = 1;

    private Rigidbody2D rigidBody;

    public Sprite closedWindow;

    public Sprite hitTopPlayerImage;


    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.up * speed;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (col.tag == "Neighbor")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.neighborDies);
            col.GetComponent<SpriteRenderer>().sprite = closedWindow;
            col.GetComponent<Animator>().enabled = false;
            Destroy(gameObject);

            col.GetComponent<PolygonCollider2D>().enabled = false;
        }

        if (col.tag == "TopPlayer")
        {
            col.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(gameObject);
            DestroyObject(col.gameObject, 0.5f);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.playerHit);
            SceneManager.LoadScene(2);

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void IncreaseTextUIScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();
        int score = int.Parse(textUIComp.text);
        score += 10;
        textUIComp.text = score.ToString();
    }
}
