using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour {

    public float volume; //存储声音大小
    AudioClip micRecord; //存储录制信息
    string device; //设备名字
    public GameObject objPrefab;
    public Transform objPos;
    public float scaleValme;  //可生成物体的最大值
    private float timer = 0;
    public float titleTime; //球体生成间隔
    private bool isCreatObj = true;
    
	void Start () {
        device = Microphone.devices[0];//0代表默认设备,第一个设备
        micRecord = Microphone.Start(device, true, 999, 44100);//开始录制,true表示循环录制,999数字代表录制长度,44100采样率
	}
	
	
	void Update () {
        volume = GetMaxVolume();
        if (titleTime > timer && isCreatObj == false)
        {
            timer += Time.deltaTime;

        }
        else
        {
            isCreatObj = true;
        }
        if (volume>0.15f&&isCreatObj)//当声音大于0.2是生成球体
        {
            objPrefab.gameObject.transform.localScale = Vector3.one*volume* scaleValme;

            Instantiate(objPrefab, objPos.position, Quaternion.identity);
            timer = 0;
            isCreatObj = false;

        }
       
    }


    float GetMaxVolume() //返回最大音量
    {
        float maxVolume = 0f;
        float[] volumeDate = new float[128];
        int offest = Microphone.GetPosition(device) - 128 + 1;//采128个，加上1不为0
        if (offest<0)//当小于0的时候返回，没有这个音量
        {
            return 0;
        }
        micRecord.GetData(volumeDate, offest);

        for (int i = 0; i < 128; i++)//循环数组
        {
            float tempMax = volumeDate[i]* volumeDate[i];//存储数据
            if (maxVolume<tempMax)//
            {
                maxVolume = tempMax;
            }
        }

        return maxVolume;
    }
}
