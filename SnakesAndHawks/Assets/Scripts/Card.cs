using System;
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
    public bool dontDo = true;
    /**
    * The only cards that are scored are the numerical declared snake color cards and all snakes and hawks.
    * Snakes of same color are 15 instead of 15
    * If all 4 Snakes are captured then its -50 points
    * Hawks are -3
    * Each other card is 1 point
    */
    public ClickManager clickManager;

    void Start()
    {
        clickManager = GameObject.Find("ClickManager").GetComponent<ClickManager>();
    }

    private void AIPlayTempMaybeSureWhyNot2(){
        for(int i = 4; i > 1; i--){
            float thing = (float) i;
            string PlayerNumThing = "Player"+i;
            GameObject.Find(PlayerNumThing).GetComponent<HandScript>().AIsPlay((thing));
        }
    }

    public void Click(){
        Vector3 scale;

        if(playerNum == "Player1" && GameObject.Find("Deck").GetComponent<Deck>().Dealing == false){
            List<GameObject> list = GameObject.Find("Player1").GetComponent<HandScript>().hand;

            if(clicked){
                PlayPlayerCard();
                AIPlayTempMaybeSureWhyNot2();
            }

            for(int i =0; i < list.Count; i++){
                if(list[i].GetComponent<Card>().clicked){
                    scale = list[i].transform.position;
                    scale.y -= 3f;
                    list[i].transform.position = scale;
                    list[i].GetComponent<Card>().clicked = false;
                }
            }
            
            if(dontDo){
                scale = transform.position;
                scale.y += 3f;
                transform.position = scale;
                clicked = true;
            }
        }
    }

    public void PlayPlayerCard(){
        Vector3 scale;
        if(playerNum == "Player1"){
            scale = GameObject.Find("Deck").transform.position;
            transform.position = scale;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = clickManager.Order;
            clickManager.Order += 1;
            clicked = false;
            GameObject.Find("Player1").GetComponent<HandScript>().RemoveCard(gameObject);
            dontDo = false;
        }

    }

    string NumConvert(int i, string card){
        if(i < 10 && card.Length == 1)
            return card+"0"+i;
        else
            return card+""+i;
    }

    public void PlayerAICard(string PlayerNumber, float x, float y){
        Vector3 scale;
        scale = GameObject.Find("Deck").transform.position;
        scale.x = x;
        scale.y = y;
        transform.position = scale;
        string CardName = gameObject.name;
        int CardNamelength = CardName.Length;
        CardName = NumConvert(Int32.Parse(CardName.Substring(CardNamelength - 2, 2)), CardName.Substring(0, CardNamelength - 2));
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/"+CardName);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = clickManager.Order;
        clickManager.Order += 1;
        GameObject.Find(PlayerNumber).GetComponent<HandScript>().RemoveCard(gameObject);
    }


    public void RightClick(){
        Vector3 scale;

        if(playerNum == "Player1" && GameObject.Find("Deck").GetComponent<Deck>().Dealing == false){
            if(clicked){
                scale = transform.position;
                scale.y -= 3f;
                transform.position = scale;
                clicked = false;
            }
        }
    }

}
