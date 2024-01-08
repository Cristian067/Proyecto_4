using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]private GameObject foe;

    [SerializeField] private float[] posX;
    [SerializeField] private float[] posz;
    [SerializeField] private Vector3[] poses;


    public int enemyCount;




    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("summon",1,10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void summon()
    {

        int ran = Random.Range(0, posX.Length);

        Instantiate(foe, poses[ran],Quaternion.identity);
    }


}
