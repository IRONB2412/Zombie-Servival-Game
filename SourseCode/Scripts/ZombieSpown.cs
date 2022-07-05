using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpown : MonoBehaviour
{
    [SerializeField] private GameObject[] ZombiesModels;
    private int Znum;
    [SerializeField] float Xpos;
    public float Xmin,Xmax;
    [SerializeField] float Zpos;
    public float Zmin,Zmax;
    [SerializeField] float Ypos;
     public int n;
    public int ZombieNo;
    private void Start()
    {
        StartCoroutine(SpwanZombi());
    }
    
    IEnumerator SpwanZombi()
    {
        
        
            for (int i = 0; i < ZombieNo; i++)
            {
                if (n < 25)
                {
                    Xpos = Random.Range(Xmin, Xmax);
                    Zpos = Random.Range(Zmin, Zmax);
                    Znum = Random.Range(0, ZombiesModels.Length);
                    Instantiate(ZombiesModels[Znum], new Vector3(Xpos, 1f, Zpos), Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                    n++;
                }
            }
        

    }
   public void Chaken()
    {
        if (n < ZombieNo)
        {
            StartCoroutine(SpwanZombi());
        }
    }
}
