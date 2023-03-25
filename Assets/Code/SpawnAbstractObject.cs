using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbstractObject : MonoBehaviour
{
    public GameObject abstractTreePrefab;
    public Vector3 center;
    public Vector3 size;
    public int treeCount;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < treeCount; i++){
            randomSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void randomSpawn(){
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x/2), size.y, Random.Range(-size.z / 2, size.z/2));

        Instantiate(abstractTreePrefab, pos, abstractTreePrefab.transform.rotation);
    }
}
