using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPlayerShot : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    public Sprite hitNeighborImage;

    public Sprite hitTopPlayerImage;


    // Use this for initialization
    void Start () {

        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.up * speed;

	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
        if(col.tag == "Neighbor")
        {
            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.neighborDies);
            IncreaseTextUIScore();
            col.GetComponent<SpriteRenderer>().sprite = hitNeighborImage;
            Destroy(gameObject);
            DestroyObject(col.gameObject, 0.5f);
        }

        if(col.tag == "TopPlayer")
        {
            IncreaseTextUIScore();
            col.GetComponent<SpriteRenderer>().sprite = hitTopPlayerImage;
            Destroy(gameObject);
            //DestroyObject(col.gameObject, 0.5f);
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
