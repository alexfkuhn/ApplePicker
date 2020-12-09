using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public GameObject appleMediumPrefab;
    public GameObject appleHardPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    static public bool medium = false;
    static public bool hard = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        int rand = Random.Range(1,9);
        if((medium == false && hard ==false) || rand < 4 ){
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
        }
        else if (medium && (rand < 7||(rand > 6 && !hard))){
            GameObject apple = Instantiate<GameObject>(appleMediumPrefab);
            apple.transform.position = transform.position;
        }
        else if (hard&& rand>6){
            GameObject apple = Instantiate<GameObject>(appleHardPrefab);
            apple.transform.position = transform.position;

        }
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        }
    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections){
            speed *= -1;
        }
    }
}
