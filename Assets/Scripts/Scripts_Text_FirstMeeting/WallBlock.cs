using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : MonoBehaviour
{
    Collider2D blockcollider;
    private ActionKeyFirstTalk talk_player;

    void Start()
    {
        talk_player = GameObject.Find("ChiefAssistant").GetComponent<ActionKeyFirstTalk>();
        blockcollider = GetComponent<Collider2D>();
        blockcollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(talk_player.talked == true)
        {
            blockcollider.isTrigger = true;
        }
    }
}
