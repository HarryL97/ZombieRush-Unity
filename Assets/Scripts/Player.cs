using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{

    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;




    private Animator anim;
    private Rigidbody rigBod;
    private AudioSource audioSource;
    private bool jump = false;
    private bool death = false;
    

    private void Awake() 
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigBod = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigBod.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
             if (Input.GetMouseButtonDown(0))
            {
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigBod.useGravity = true;
                jump = true;
                GameManager.instance.PlayerStart();
    
            }
        }
       
    }

    void FixedUpdate() 
    {
        if(jump==true) 
        {
         jump = false;
         rigBod.velocity = new Vector2(0,0);
         rigBod.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //print("meme");
        if(collision.gameObject.tag == "obstacle")
        {
            rigBod.AddForce(new Vector2(-50,200), ForceMode.Impulse);
            rigBod.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();

        }
    }
}
