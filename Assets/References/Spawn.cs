using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour

{
    float elapsed = 0f;
    public Transform prefab;
    void Start()
    {
        //  for (int i = 0; i < 10; i++)
        // {
        //    Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        //}
    }



    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            SpawnObject(1);
            OutputTime();
        }
    }
    void OutputTime()
    {
        Debug.Log(Time.time);
    }




    void SpawnObject(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(prefab, new Vector3(2, 0, 0), Quaternion.identity);


        }

    }
}