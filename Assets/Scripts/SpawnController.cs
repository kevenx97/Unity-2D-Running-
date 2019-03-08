using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject blockPreFab;
    public float rateSpawn;
    public float currentTime;
    private int position;
    private float y;

	// Use this for initialization
	void Start () {
        currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if(currentTime >= rateSpawn)
        {
            position = Random.Range(1, 10);

            if(position > 5)
            {
                y = -2.2f;
            }
            else
            {
                y = -1.55f;
            }

            currentTime = 0;
            GameObject temPreFab = Instantiate(blockPreFab) as GameObject;
            temPreFab.transform.position = new Vector3(transform.position.x, y, temPreFab.transform.position.z); 
        }
	}
}
