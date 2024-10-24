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

    //audio variables
    public AudioSource soundEffects;
    public AudioClip[] sounds;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        if(instance != null) //if another of the player i sin the scene 
        {
            Destroy(gameObject); // then destroy it 
        }

        instance = this; // reasign the instance to th current player
        GameObject.DontDestroyOnLoad(this.gameObject);
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
            soundEffects.PlayOneShot(sounds[1], .7f);  // .7f is the volume
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.tag.Equals("SheriffDoor"))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.tag.Equals("ExitSheriffDoor"))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(4);
        }

        if (collision.gameObject.tag.Equals("key"))
        {
            Debug.Log("obtained key");
            soundEffects.PlayOneShot(sounds[0], .7f); 
            hasKey = true; // player has the key
        }
        // you need to collide with the door AND have the key for it to be true  
        if (collision.gameObject.tag.Equals("door2") && hasKey == true)
        {
            Debug.Log("unlocked door");
            soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(3);
        }

        if (collision.gameObject.tag.Equals("ExitTownDoor") && hasKey == true)
        {
            soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.tag.Equals("TownHouseDoor"))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(5);
        }

        if (collision.gameObject.tag.Equals("TownHouse1Door"))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(6);
        }

        if (collision.gameObject.tag.Equals("TownHouse2Door"))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(7);
        }

        if (collision.gameObject.tag.Equals("TownHouse3Door"))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(sounds[1], .7f);
            SceneManager.LoadScene(8);
        }
    }

}
