using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string color;
    public float number;
    public float value;
    /**
    * The only cards that are scored are the numerical declared snake color cards and all snakes and hawks.
    * Snakes of same color are 15 instead of 15
    * If all 4 Snakes are captured then its -50 points
    * Hawks are -3
    * Each other card is 1 point
    */
}
