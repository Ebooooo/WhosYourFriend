using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionKeyFirstTalk : MonoBehaviour
{
    public GameObject talk;
    private PlayerController talk_player;
    [SerializeField] GameObject firsttalk;
    public bool talked;

    void Start()
    {
        talk_player = GameObject.Find("Player").GetComponent<PlayerController>();
        talk.SetActive(false);
        talked = false;
    }

    void Update()
    {
        TalkUse();
        BackToMove();
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
    if(col.CompareTag("Player") && talked == false)
    {
        talk.SetActive(true);
    }
    }
    private void TalkUse()
    {
        if(Input.GetKeyDown(KeyCode.E) && talk.activeSelf == true && talked == false)
        {
            talked = true;
            firsttalk.SetActive(true);
            talk_player.playerstate = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player") && talked == false)
        {
            talk.SetActive(true);
        }
        else
        {
            talk.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        talk.SetActive(false);
    }
    public void BackToMove()
    {
        if(firsttalk.activeSelf == false)
        {
            talk_player.playerstate = true;
        }
    }
}
