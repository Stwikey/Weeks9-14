using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LocalMultiplayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Sprite> playerSprites;
    public List<PlayerInput> players;
    
    public void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player);
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[player.playerIndex];

        LocalMultiplayerController controller = player.GetComponent<LocalMultiplayerController>();

        controller.manager = this;
    }

    public void PlayerAttacking(PlayerInput attackingPlayer)
    {
        for (int i = 0; i < players.Count; i++)
        {   if (attackingPlayer == players[i]) continue;
            if(Vector2.Distance(attackingPlayer.transform.position, players[i].transform.position) < 0.5){
                Debug.Log("Player" + attackingPlayer.playerIndex + " attacked " + players[i].playerIndex);


            }

        }
    }

    
   
    
}
