using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    public Sprite closedWindow;
    int secBeforePopUp = 4;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
       // StartCoroutine(PopBackOut());
	}

    private Coroutine coroutine;
	
	// Update is called once per frame
	void Update () {
        if (spriteRenderer.sprite == closedWindow && coroutine == null)
        {
            coroutine = StartCoroutine(CoroutineDelayOpenWindow());
        }

    }

    //public IEnumerator PopBackOut()
    //{
    //    //while (true)
    //    {
    //        if(spriteRenderer.sprite == closedWindow)
    //        {
    //            GetComponent<Animator>().enabled = true;
    //            GetComponent<PolygonCollider2D>().enabled = true;

    //        }

    //        yield return new WaitForSeconds(secBeforePopUp);
             
    //    }
    //}


    private IEnumerator CoroutineDelayOpenWindow()
    {

        yield return new WaitForSeconds(secBeforePopUp);
       // if (spriteRenderer.sprite == closedWindow)
       // {
            GetComponent<Animator>().enabled = true;
            GetComponent<PolygonCollider2D>().enabled = true;

        
        coroutine = null;


    }
}
