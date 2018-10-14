using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public Transform[] startPos;//生成点
    public Transform[] allEnemy;//所有小兵
    //public int SoldierIndex = 2;
    private int count = 0;
    // Use this for initialization
    void Start () {
        StartCoroutine(CreatSoldier());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CreatSoldier()
    {
        Debug.Log("shuabing");
        StartCoroutine(CreatEveryWaySoldier());
        yield return new WaitForSeconds(3);
        StartCoroutine(CreatSoldier());
        count += 1; 
         if (count >= 3)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator CreatEveryWaySoldier()
    {

        for (int i = 0; i < 2; i++)
        {
            Transform solder = Instantiate(allEnemy[i]);
            solder.position = startPos[0].position;
            //solder.localPosition = startPos[i].localPosition;
            yield return null;
        }


        //if (SoldierIndex > 0)
        //{
        //    SoldierIndex--;
        //    StartCoroutine(CreatEveryWaySoldier());
        //}
        //else
        //{
        //    SoldierIndex = 3;
        //}

    }
}
