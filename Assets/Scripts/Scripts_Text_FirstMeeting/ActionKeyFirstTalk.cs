using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionKeyFirstTalk : MonoBehaviour
{
    public GameObject talk;
    private PlayerController talk_player;
    [SerializeField] GameObject firsttalk;

    void Start()
    {
        talk_player = GameObject.Find("Player").GetComponent<PlayerController>();
        talk.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TalkUse();
        BackToMove();
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
    if(col.CompareTag("Player"))
    {
        talk.SetActive(true);
    }
    }
    private void TalkUse()
    {
        if(Input.GetKeyDown(KeyCode.E) && talk.active == true)
        {
            firsttalk.SetActive(true);
            talk_player.playerstate = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        talk.SetActive(false);
    }
    public void BackToMove()
    {
        if(firsttalk.active == false)
        {
            talk_player.playerstate = true;
        }
    }
}
