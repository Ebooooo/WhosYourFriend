using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UI_DisplayText : MonoBehaviour
{
    private Text messageText;
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
            } else{
           string[] messageArray = new string[]
            {
                "Money...",
                "Money, can destroy everyone",
                "We resort to scams, thefts...",
                "We sell ourselves or our views, and even kill, just to get our fortune",
                "I thought it didn't concern me, that i was better than that",
                "Oh how wrong i was... how much wrong i had done, overshadowed by quick profit and a safe job",
                "The next move... it will change my life once and for all",
                "I just need to think... how... how it even started?",
                "  ",
            };
                string message = messageArray[counter];
                textWriterSingle = TextWriter.AddWrite_Static(messageText, message, .1f, true, true); 
                counter +=1;
                if(counter == messageArray.Length)
                {
                    SceneManager.LoadScene("FirstMeetingWithChief");
                }
            };
        }
    }
}
