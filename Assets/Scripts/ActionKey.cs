using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionKey : MonoBehaviour
{
    public GameObject talk;
    private PlayerController talk_player;
    void Start()
    {
        talk_player = GameObject.Find("Player").GetComponent<PlayerController>();
        talk.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TalkUse();
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
        if(Input.GetKeyDown(KeyCode.E) && talk.activeSelf == true)
        {
            Debug.Log("Talk_usage");
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        talk.SetActive(false);
    }
}
