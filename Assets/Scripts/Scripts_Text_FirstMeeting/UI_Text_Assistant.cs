using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UI_Text_Assistant: MonoBehaviour
{
    private Text messageText;
    [SerializeField] GameObject textbcg;
    private int counter = 0;
    private TextWriter.TextWriterSingle textWriterSingle;
    private void Awake()
    {
        messageText = transform.Find("TextBorder").Find("messageText").GetComponent<Text>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(textWriterSingle != null && textWriterSingle.IsActiveText())
            {
                textWriterSingle.WriteAndDestroy();
            } else 
            {
           string[] messageArray = new string[]
            {
                "Mr. Stone as assume",
                "Is this the first time, that You meet face to face with right hand, of our precious Leader?",
                "Ahhhh wonderful feeling...",
                "I envy You this",
                "First meeting is an amazing expirience",
                "Almost like a touch of a god",
                "...",
                "We can go, but remember",
                "Words of our Leaders, are our duties",
                "  ",
            };
                string message = messageArray[counter];
                textWriterSingle = TextWriter.AddWrite_Static(messageText, message, .1f, true, true); 
                counter +=1;
                if(counter == 10)
                {
                    textbcg.SetActive(false);
                }
            };
        }
    }
}
