using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{

    public string[] messages;
    public TMP_Text messageBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //display messages in a text box
            messageBox.text = messages[Random.Range(0, messages.Length)];
        }
    }
}
