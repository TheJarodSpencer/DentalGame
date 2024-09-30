using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4; //Three copies of baskets spaced out vertically (UPDATED: Changed to 4)
    public float basketBottomY = -14f; 
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    public RoundManager roundManager;
    public int countBaskets = 1;

    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i <numBaskets; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY*i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

    }

    public void AppleMissed(){ //needs to be public to be called by Apple.cs
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tempGO in appleArray){
            Destroy(tempGO);
        }
        //Destroy one Basket by getting index of last Basket in basketList
        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];//reference to Basket Object
        basketList.RemoveAt(basketIndex);//Remove basket
        Destroy(basketGO);//destroy game object


        if(basketList.Count == 0){
            SceneManager.LoadScene("EndScreen");//Changed from Scene_0 to Game Over Screen
        }
        else{
            countBaskets++;
            roundManager.NextRound(countBaskets);//Connect to RoundManager.cs for round counter function
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
