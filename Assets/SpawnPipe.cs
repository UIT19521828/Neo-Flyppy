using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public float MaxTime = 1;
    private float timer = 0;
    public GameObject pipe;
    public float height;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > MaxTime)
        {
            GameObject newp = Instantiate(pipe);
            newp.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newp, 10);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
