using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private GameObject[] MusicObject;
    void Awake()
    {
        MusicObject = GameObject.FindGameObjectsWithTag("BGMusic");
        if (MusicObject.Length >= 2)
        {
            Destroy(MusicObject[1]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
