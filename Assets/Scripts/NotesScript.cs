using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{
    public GameObject notes;

    public void Start()
    {
        notes.SetActive(false);
    }

    public void Update()
    {
        UseNotes();
    }

    public void UseNotes()
    {
        if(Input.GetKeyDown(KeyCode.N) && notes.activeSelf == true)
        {
            notes.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.N) && notes.activeSelf == false)
        {
            notes.SetActive(true);
        }
    }
}
