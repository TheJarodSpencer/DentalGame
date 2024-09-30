using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//To go to Game Over menu

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    void Start()
    {
        //Find GameObject named ScoreCounter in Scene
        GameObject scoreGO = GameObject.Find("ScoreCounter");//Find is vvy slow so do it once per script
        //Get ScoreCounter script component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        //Camera Main is public and static any other script can access it 
        Vector3 mousePos2D = Input.mousePosition;//Current screen pos of mouse from input
        mousePos2D.z = -Camera.main.transform.position.z;//how far to push mouse in 3D
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);//point of 2D into 3D

        //Move x pos of Basket to x pos of mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll){
        //Find out what hits the basket
        GameObject collidedWith = coll.gameObject; //temp variable to tell what collided object is
        if(collidedWith.CompareTag("Apple")){ //Looks for apple tag
            Destroy(collidedWith);
            scoreCounter.score += 100; //Increase score by 100
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);//set highscore connects with ApplePicker.cs
        }
        else if(collidedWith.CompareTag("Branch")){ //Added code to end the game if collided with branch
            SceneManager.LoadScene("EndScreen");
        }
    }

}
