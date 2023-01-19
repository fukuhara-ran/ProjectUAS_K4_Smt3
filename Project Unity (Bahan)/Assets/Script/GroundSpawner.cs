using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject Ground1, Ground2, Ground3;
    bool hasGround = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGround)
        {
            spawnGround();
            hasGround = true;
        }
    }
    public void spawnGround()
    {
        int randNum = Random.Range(1,4);
        if(randNum == 1)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + 3, 2.54f, 0), Quaternion.identity);
        }
        if(randNum == 2)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + 1, 3.8f, 0), Quaternion.identity);
        }
        if(randNum == 3)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + 2, 4f, 0), Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }
    }
}
