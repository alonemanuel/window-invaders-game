using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlayer : MonoBehaviour {

    public float speed = 15;

    public GameObject theBullet;

    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("TopHorizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("TopPlayerFire"))
        {
            Instantiate(theBullet, transform.GetChild(0).position, Quaternion.identity);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.ballFire);
        }
		
	}
}
