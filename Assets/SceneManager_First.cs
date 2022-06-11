using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager_First : MonoBehaviour
{
    [SerializeField] GameObject TalkAssistOne;
    // Start is called before the first frame update
    void Start()
    {
        TalkAssistOne.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
