using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class FirstAnswerPlayer: MonoBehaviour
{
    private Text messageText;
    private PlayerController talk_player;

    [SerializeField] GameObject textanswerplayer;
    private int counter = 0;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Start()
    {
        talk_player = GameObject.Find("Player").GetComponent<PlayerController>();    
    }

    private void Awake()
    {
        messageText = transform.Find("TextBorder").Find("messageText").GetComponent<Text>();
    }

    private void Update()
    {
        if(textanswerplayer.activeSelf == true)
        {
            talk_player.playerstate = false;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(textWriterSingle != null && textWriterSingle.IsActiveText())
            {
                textWriterSingle.WriteAndDestroy();
            } else 
            {
           string[] messageArray = new string[]
            {
                "Of course Mr.",
                "Everything is clear.",
                "  ",
            };
                string message = messageArray[counter];
                textWriterSingle = TextWriter.AddWrite_Static(messageText, message, .1f, true, true); 
                counter +=1;
                if(counter == 3)
                {
                    textanswerplayer.SetActive(false);
                }
            };
        }
    }
}
