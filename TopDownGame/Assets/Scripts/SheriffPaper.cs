using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheriffPaper : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject); //destroy the key
            Debug.Log("ive been collected!");
            //keySound.Play();
        }
    }
}