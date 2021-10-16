using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, IClickable
{
    public string color;
    public float number;
    public float value;
    public string playerNum;
    public bool clicked = false;
    /**
    * The only cards that are scored are the numerical declared snake color cards and all snakes and hawks.
    * Snakes of same color are 15 instead of 15
    * If all 4 Snakes are captured then its -50 points
    * Hawks are -3
    * Each other card is 1 point
    */

    public void Click(){
        Vector3 scale;

        if(playerNum == "Player1"){
            List<GameObject> list = GameObject.Find("Player1").GetComponent<HandScript>().hand;

            for(int i =0; i < list.Count; i++){
                if(list[i].GetComponent<Card>().clicked){
                    scale = list[i].transform.position;
                    scale.y -= 3f;
                    list[i].transform.position = scale;
                    list[i].GetComponent<Card>().clicked = false;
                }
            }

            scale = transform.position;
            scale.y += 3f;
            transform.position = scale;
            clicked = true;
        }
    }

}
