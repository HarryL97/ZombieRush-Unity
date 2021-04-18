using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : Object
{

    [SerializeField] Vector3 topPos;
    [SerializeField] Vector3 botPos;
    [SerializeField] float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
            StartCoroutine(Move(botPos));
    }

    protected override void Update()
    {
        if(GameManager.instance.PlayerActive)
        {
            base.Update();
        }
    }

    IEnumerator Move(Vector3 target)
    {
        while(Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * speed;

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPos.y ? botPos : topPos; 

        StartCoroutine(Move(newTarget));


    }

}

