using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;

    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }
    public static TextWriterSingle AddWrite_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool RemoveBeforeAdd)
    {
    if(RemoveBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        {
            return instance.AddWrite(uiText, textToWrite, timePerCharacter, invisibleCharacters);
        }
    }
    private TextWriterSingle AddWrite(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters);
       textWriterSingleList.Add(textWriterSingle);
       return textWriterSingle;
    }
    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }
    private void RemoveWriter(Text uiText)
    {
        for(int i = 0; i < textWriterSingleList.Count; i++)
        {
           if(textWriterSingleList[i].GetUIText() == uiText)
           {
               textWriterSingleList.RemoveAt(i);
               i--;
           }
        }
    }

    private void Update() 
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroynull = textWriterSingleList[i].Update();
            if(destroynull)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    public class TextWriterSingle
    {
        private Text uiText;
        private string textToWrite;
        private float timePerCharacter;
        private float timer;
        private int characterIndex;
        private bool invisibleCharacters;

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
       this.uiText = uiText;
       this.textToWrite = textToWrite;
       this.timePerCharacter = timePerCharacter;
       this.invisibleCharacters = invisibleCharacters;
       characterIndex = 0; 
    }

        public bool Update()
        {
            timer -= Time.deltaTime;
            while(timer <= 0f)
             {
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if(invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                if(characterIndex >= textToWrite.Length)
                {
                    return true;
                }
            }
            return false;
        }

        public Text GetUIText()
        {
            return uiText;
        }
        public bool IsActiveText()
        {
            return characterIndex < textToWrite.Length;
        }
        public void WriteAndDestroy()
        {
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            TextWriter.RemoveWriter_Static(uiText);
        }
    }
}

