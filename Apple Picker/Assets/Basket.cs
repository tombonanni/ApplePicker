﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Basket : MonoBehaviour {

    public Text scoreGT;

	// Use this for initialization
	void Start () {

        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";

	}
	
	// Update is called once per frame
	void Update () {

        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition; // 1   
              
        // The Camera's z position sets the how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z; // 2   
              
        // Convert the point from 2D screen space into 3D game world space         
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D ); // 3   
              
        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter ( Collision coll )
    {
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
        }

        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();

        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
