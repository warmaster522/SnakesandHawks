using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Card 3 is Snake Card 8 is Hawk
    public float Players = 2f;
    public GameObject[] PlayersL;
    public float Teams = 2f;
    public float CardsPerColorInPlay = 8;
    public GameObject[,] cards;
    public float DealSpeed = 0.25f;//Smaller is faster

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject+" Start Called");
        cards = new GameObject[4, (int)CardsPerColorInPlay];
        GrabCards();

        PlayersL = new GameObject[(int)Players];
        for(int i = 0; i < PlayersL.Length; i++){
            PlayersL[i] = GameObject.Find("Player"+(i+1));
        }
        SetPlayersPostion();
        
        Shuffle(cards);
        StartCoroutine(DealDeck());
    }

    void SetPlayersPostion(){
        Vector3 temp = new Vector3();
        temp.y = -20;
        PlayersL[0].transform.position = temp;

        if(Players == 6){
            temp.x = -20f;
            temp.y = -20f;
            PlayersL[0].transform.position = temp;
            temp.x = 20f;
            PlayersL[5].transform.position = temp;
            temp.y = 20;
            var rotationV = PlayersL[3].transform.rotation.eulerAngles;
            rotationV.z = 180f;
            PlayersL[3].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[3].transform.position = temp;
            temp.x = -20;
            PlayersL[2].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[2].transform.position = temp;
            temp.y = 0;
            temp.x = -45;
            rotationV.z = -90;
            PlayersL[1].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[1].transform.position = temp;
            temp.x = 45;
            rotationV.z = 90;
            PlayersL[4].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[4].transform.position = temp;
        }else if(Players == 5){
            temp.y = 20f;
            temp.x = 20f;
            PlayersL[3].transform.position = temp;
            temp.y = 20;
            var rotationV = PlayersL[3].transform.rotation.eulerAngles;
            rotationV.z = 180f;
            temp.x = -20;
            PlayersL[2].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[2].transform.position = temp;
            temp.y = 0;
            temp.x = -45;
            rotationV.z = -90;
            PlayersL[1].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[1].transform.position = temp;
            temp.x = 45;
            rotationV.z = 90;
            PlayersL[4].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[4].transform.position = temp;
        }else if(Players == 4){
            temp.y = 20;
            var rotationV = PlayersL[0].transform.rotation.eulerAngles;
            rotationV.z = 180f;
            temp.x = -0;
            PlayersL[2].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[2].transform.position = temp;
            temp.y = 0;
            temp.x = -45;
            rotationV.z = -90;
            PlayersL[1].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[1].transform.position = temp;
            temp.x = 45;
            rotationV.z = 90;
            PlayersL[3].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[3].transform.position = temp;
        }else if(Players == 3){
            temp.y = 20;
            var rotationV = PlayersL[0].transform.rotation.eulerAngles;
            rotationV.z = 180f;
            temp.x = -0;
            PlayersL[2].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[2].transform.position = temp;
            temp.y = 0;
            temp.x = -45;
            rotationV.z = -90;
            PlayersL[1].transform.rotation = Quaternion.Euler(rotationV);
            PlayersL[1].transform.position = temp;
        }else if(Players == 2){
            var rotationV = PlayersL[0].transform.rotation.eulerAngles;
            rotationV.z = 180f;
            PlayersL[1].transform.rotation = Quaternion.Euler(rotationV);
        }

    }

    string NumConvert(int i){
        if(i < 10)
            return "0"+i;
        else
            return ""+i;
    }

    void GrabCards(){
        for(int i = 0; i < (int) CardsPerColorInPlay; i++){
            cards[0,i] = new GameObject("Cardr"+(i+1));
            SpriteRenderer renderer = cards[0,i].AddComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/r"+NumConvert(i+1));
            cards[0,i].AddComponent<Card>();
            cards[0,i].AddComponent<BoxCollider2D>();
            var card = cards[0,i].GetComponent<Card>();
            card.color = "Red";
            card.number = (float)(i+1);
            if(i == 7){
                card.value = -3f;
            }else if(i == 2){
                card.value = 10f;
            }else{
                card.value = 1;
            }
        }
        for(int i = 0; i < (int) CardsPerColorInPlay; i++){
            cards[1,i] = new GameObject("Cardb"+(i+1));
            SpriteRenderer renderer = cards[1,i].AddComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/b"+NumConvert(i+1));
            cards[1,i].AddComponent<Card>();
            cards[1,i].AddComponent<BoxCollider2D>();
            var card = cards[1,i].GetComponent<Card>();
            card.color = "Blue";
            card.number = (float)(i+1);
            if(i == 7){
                card.value = -3f;
            }else if(i == 2){
                card.value = 10f;
            }else{
                card.value = 1;
            }
        }
        for(int i = 0; i < (int) CardsPerColorInPlay; i++){
            cards[2,i] = new GameObject("Cardg"+(i+1));
            SpriteRenderer renderer = cards[2,i].AddComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/g"+NumConvert(i+1));
            cards[2,i].AddComponent<Card>();
            cards[2,i].AddComponent<BoxCollider2D>();
            var card = cards[2,i].GetComponent<Card>();
            card.color = "Green";
            card.number = (float)(i+1);
            if(i == 7){
                card.value = -3f;
            }else if(i == 2){
                card.value = 10f;
            }else{
                card.value = 1;
            }
        }
        for(int i = 0; i < (int) CardsPerColorInPlay; i++){
            cards[3,i] = new GameObject("Cardy"+(i+1));
            SpriteRenderer renderer = cards[3,i].AddComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load<Sprite>("Images/y"+NumConvert(i+1));
            cards[3,i].AddComponent<Card>();
            cards[3,i].AddComponent<BoxCollider2D>();
            var card = cards[3,i].GetComponent<Card>();
            card.color = "Yellow";
            card.number = (float)(i+1);
            if(i == 7){
                card.value = -3f;
            }else if(i == 2){
                card.value = 10f;
            }else{
                card.value = 1;
            }
        }
    }

// Gives the player a card
    void GiveCard(GameObject Player, int y, int x){
        cards[y,x].transform.position = Player.transform.position;
        cards[y,x].transform.rotation = Player.transform.rotation;
        HandScript temp = Player.GetComponent<HandScript>();
        temp.hand.Add(cards[y,x]);
        //Add the Card to the players hand as well... not just visually as done now
    }

// Deals the deck at the begining  
    IEnumerator DealDeck() {
        int total = 1;
        int p = 0;
        for(int y = 3; y >= 0; y--){
            for(int x = (int)CardsPerColorInPlay-1; x >= 0; x--){
                if(p == (int)Players-1){
                    GiveCard(PlayersL[p], y, x);
                    p = 0;
                }else{
                    GiveCard(PlayersL[p], y, x);
                    p++;
                }
                cards[y,x].GetComponent<SpriteRenderer>().sortingOrder = total;
                total++;
                yield return new WaitForSeconds(DealSpeed);
            }
        }
    }

// Randomizes the cards placement 
    static void Shuffle<T>(T[,] array){
        System.Random random = new System.Random();
        int lengthRow = array.GetLength(1);

        for (int i = array.Length - 1; i > 0; i--){
            int i0 = i / lengthRow;
            int i1 = i % lengthRow;

            int j = random.Next(i + 1);
            int j0 = j / lengthRow;
            int j1 = j % lengthRow;

            T temp = array[i0, i1];
            array[i0, i1] = array[j0, j1];
            array[j0, j1] = temp;
        }
    }
}
