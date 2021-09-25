using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public List<GameObject> hand = new List<GameObject>();

    public void FixedUpdate()
    {
        Vector3 pos = gameObject.transform.position;
        if(hand.Count != 0){
            float width;
            float half;
            int num = hand.Count;
            int numHalf = num/2;
            float rot = hand[0].transform.rotation.z;
            if(rot != 0 && rot != 1){
                width = hand[0].GetComponent<SpriteRenderer>().bounds.size.y;
                half = width/2;//half is a third
                pos.y -= (float) half*numHalf;
            }else{
                width  = hand[0].GetComponent<SpriteRenderer>().bounds.size.x;
                half = width/2;//half is a third
                pos.x -= (float) half*numHalf;
            }
            for(int i = 0; i < num; i++){
                hand[i].transform.position = pos;
                if(rot != 0 && rot != 1){
                    pos.y += half;
                }else{
                    pos.x += half;
                }
            }
        }
    }
}
