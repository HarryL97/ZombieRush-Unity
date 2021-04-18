using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    [SerializeField] private float objectSpeed = 1;
    [SerializeField] private float resetPos = -22.1f;
    [SerializeField] private float startPos = 54f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frames
    protected virtual void Update()
    {
        if(!GameManager.instance.GameOver)
        {
                    transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime)); 

            if (transform.localPosition.x <= resetPos)
            {
                Vector3 newPos = new Vector3(startPos, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
               
        }

    }
}
