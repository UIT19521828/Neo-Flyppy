using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DichuyenCot : MonoBehaviour
{
    public float v;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * v * Time.deltaTime;
    }
}
