using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")] //fields of the script will not change while running
    public GameObject applePrefab;//instantiating apples
    public GameObject branchPrefab;//instaniating branches

    public float speed = 1f; //speed AppleTree moves
    public float leftAndRightEdge = 10f; //distance when AppleTree turns around
    public float changeDirChance = 0.1f; //chance AppleTree changes direction
    public float appleDropDelay = 1f; //time between apples
    public float branchDropDelay = 3f; //falls much less than apples

    void Start()
    {
        //Start Apple Drop
        Invoke("DropApple", 2f); //calls after waiting 2 sec
        Invoke("DropBranch", 3f); //calls after waiting 3 sec
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
    
    void DropBranch()
    {
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        branch.transform.position = transform.position;
        Invoke("DropBranch", branchDropDelay);
    }

    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position; //position of AppleTree
        pos.x += speed * Time.deltaTime; //makes AppleTree time-based
        transform.position = pos; //this moves the AppleTree

        //Changing Direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }
        /*else if(Random.value < changeDirChance) //Random.value = float val between/can be 0 and 1
        {
            speed *= -1; //sets speed as negative of itself
        }
        */
    }
        void FixedUpdate() //sets a fixed #(50) of rendered frames so same across everyone's devices
        {
            if(Random.value < changeDirChance)
            {
                speed *= -1; //change direction
            }
        }

    
}
