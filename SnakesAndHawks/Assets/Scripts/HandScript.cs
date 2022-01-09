using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    [x] Add a part to hold stored Cards
    [x] Have a way to add cards to the Stored Cards list
*/

public class HandScript : MonoBehaviour
{
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> CardsCollected = new List<GameObject>();
    public bool CallAnyWays = false;
    public bool ActivePlayer = false;
    float lastCount = 0;

    public void AddCardToCollected(GameObject card){
        CardsCollected.Add(card);
    }

    public void RemoveCard(GameObject card)
    {
        List<GameObject> temp = new List<GameObject>();
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i] != card)
            {
                temp.Add(hand[i]);
            }
        }
        hand = temp;
        CallAnyWays = true;
    }

    public void AIsPlay(float ptemp){
        if(hand.Count > 0){
            Debug.Log(hand[0].name);
            if(ptemp == 4f){
                hand[0].GetComponent<Card>().PlayerAICard("Player4", 13, 0);
            }else if(ptemp == 3f){
                hand[0].GetComponent<Card>().PlayerAICard("Player3", 0, 15);
            }else if(ptemp == 2f){
                hand[0].GetComponent<Card>().PlayerAICard("Player2", -13, 0);
            }
        }
    }

    public void FixedUpdate()
    {
        Vector3 pos = gameObject.transform.position;
        if (hand.Count > lastCount || CallAnyWays)
        {
            CallAnyWays = false;
            if (gameObject.name != "Player1")
            {
                for (int i = 0; i < hand.Count; i++)
                {
                    hand[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/blank");
                }
            }
            else
            {

                IComparer myComparer = new HandSorter();
                GameObject[] test = (GameObject[])hand.ToArray();
                Array.Sort(test, myComparer);

                hand.Clear();
                int sortingOrder = 0;
                foreach (var thing in test)
                {
                    thing.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
                    sortingOrder++;
                    hand.Add(thing);
                }

                lastCount++;
                float width;
                float half;
                int num = hand.Count;
                int numHalf = num / 2;
                float rot = hand[0].transform.rotation.z;
                if (rot != 0 && rot != 1)
                {
                    width = hand[0].GetComponent<SpriteRenderer>().bounds.size.y;
                    half = width / 2;//half is a third
                    pos.y -= (float)half * numHalf;
                }
                else
                {
                    width = hand[0].GetComponent<SpriteRenderer>().bounds.size.x;
                    half = width / 2;//half is a third
                    pos.x -= (float)half * numHalf;
                }
                for (int i = 0; i < num; i++)
                {
                    hand[i].transform.position = pos;
                    if (rot != 0 && rot != 1)
                    {
                        pos.y += half;
                    }
                    else
                    {
                        pos.x += half;
                    }

                    hand[i].GetComponent<Card>().playerNum = gameObject.name;
                }

                float Arch = num/4;
                Vector3 tempVec;
                for(int i = 0; i < num; i++){
                    if(Arch < 0){
                        tempVec = hand[i].transform.position;
                        tempVec.y -= (Arch * -1);
                        Arch -= 0.5f;
                        hand[i].transform.position = tempVec;
                    }
                    else if(Arch == 0){
                        tempVec = hand[i].transform.position;
                        tempVec.y -= 0.5f;
                        Arch -= 0.5f;
                        hand[i].transform.position = tempVec;
                    }else{
                        tempVec = hand[i].transform.position;
                        tempVec.y -= Arch;
                        Arch -= 0.5f;
                        hand[i].transform.position = tempVec;
                    }
                }
            }
        }
    }
}
