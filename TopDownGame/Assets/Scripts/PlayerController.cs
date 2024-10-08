using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//importing sceneManagement Library 

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;
    public bool hasKey = false;

    //sprite variables
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite downSprite;
    
    //public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            sr.sprite = rightSprite;
        }
        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
            sr.sprite =  leftSprite;
        }
        if (Input.GetKey("s"))
        {
            newPosition.y -= speed;
            sr.sprite = downSprite;
        }
        if (Input.GetKey("w"))
        {
            newPosition.y += speed;
            //change sprite to up sprite 
            sr.sprite = upSprite;
        }
        
        transform.position = newPosition;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if colliding with a game object with specific tag
        if (collision.gameObject.tag.Equals("door1"))
        {
            Debug.Log("change scene");
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.tag.Equals("SheriffDoor"))
        {
            Debug.Log("change scene");
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.tag.Equals("key"))
        {
            Debug.Log("obtained key");
            hasKey = true; // player has the key
        }
        // you need to collide with the door AND have the key for it to be true  
        if (collision.gameObject.tag.Equals("door2") && hasKey == true)
        {
            Debug.Log("unlocked door");
        }
    }

}
