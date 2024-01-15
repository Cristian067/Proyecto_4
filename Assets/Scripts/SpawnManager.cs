using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]private GameObject foe;

    [SerializeField] private float[] posX;
    [SerializeField] private float[] posz;
    [SerializeField] private Vector3[] poses;

    [SerializeField] private int wave = 3;


    public int enemyCount;

    private int powerupNum;




    // Start is called before the first frame update
    void Start()
    {
        //waves(wave);
        //InvokeRepeating("summon",1,10f);
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyCount <= 0)
        {
            wave++;
            waves(wave);
            //wave++;
        }

        //powerupNum = int.GameObject.Find("PowerUp");
        
    }

    void summon()
    {

        int ran = Random.Range(0, posX.Length);

        Instantiate(foe, poses[ran],Quaternion.identity);
    }


    private void waves(int spwanEnemies)
    {

        for(int i = 0; i < spwanEnemies; i++)
        {
            int ran = Random.Range(0, poses.Length);
            Instantiate(foe, poses[ran], Quaternion.identity);
        }

    }



}
