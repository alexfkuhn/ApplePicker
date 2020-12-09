using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    static public int scoreNum;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        scoreGT = scoreGo.GetComponent<Text>();
        scoreGT.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter (Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple" || collidedWith.tag == "AppleMedium" || collidedWith.tag == "AppleHard") {
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            if (collidedWith.tag == "Apple"){
                score += 100;
            } else if (collidedWith.tag == "AppleMedium"){
                score += 200;
            } else if (collidedWith.tag == "AppleHard"){
                score += 300;
            }
            scoreGT.text = score.ToString();
            scoreNum = score;

            if(score > HighScore.score){
                HighScore.score = score;
                if(HighScore.newScore == false){
                    HighScore.newScore = true;
                }
            }
            if(AppleTree.medium == false && score > 1000){
                AppleTree.medium= true;
            }
            if (AppleTree.medium == true && score < 1000){
                AppleTree.medium = false;
            }
            if (AppleTree.hard == false && score > 3000){
                AppleTree.hard = true;
            }
            if (AppleTree.hard == true && score < 3000){
                AppleTree.hard = false;
            }
        }
    }
}
