using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public float MaxTime;
    private float timer = 0;
    public GameObject pipe;
    public float height;
    void Start()
    {
        MaxTime = PlayerData.pd.Mt;
    }

    void Update()
    {
        if(timer > MaxTime)
        {
            GameObject newp = Instantiate(pipe);
            DichuyenCot dcc = newp.GetComponent<DichuyenCot>();
            dcc.ChangeV(PlayerData.pd.V);
            newp.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newp, 10);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
