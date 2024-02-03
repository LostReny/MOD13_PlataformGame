using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string tagToCompare = "Player";

    public GameObject End_Game_Trigger; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(tagToCompare))
        {
            _EndGame();
        }
    }

    public void _EndGame()
    {
        End_Game_Trigger.SetActive(true);
    }
}
