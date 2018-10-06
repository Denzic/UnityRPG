using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using UnityEngine.UI;

public class JoyButton : MonoBehaviour {

    Image iceImage;
    Image fireImage;
    Button fireButton;
    Button iceButton;
    float fireButtonTimer = 3;
    float iceButtonTimer = 3;

    public GameObject Weapon;
    // Use this for initialization
    void Start () {
        Weapon = GameObject.FindGameObjectWithTag("LongSword");
        fireImage = GameObject.FindGameObjectWithTag("CastFireBall").GetComponent<Image>();
        fireButton = GameObject.FindGameObjectWithTag("CastFireBall").GetComponent<Button>();
        iceImage = GameObject.FindGameObjectWithTag("CastIceBall").GetComponent<Image>();
        iceButton = GameObject.FindGameObjectWithTag("CastIceBall").GetComponent<Button>();
    }

    private void Update()
    {
        fireButtonTimer += Time.deltaTime;
        iceButtonTimer += Time.deltaTime;
        fireImage.fillAmount = CDTime(fireButtonTimer, fireImage, fireButton);
        iceImage.fillAmount = CDTime(iceButtonTimer, iceImage, iceButton);
    }

    public void FireBall()
    {
        Weapon.GetComponent<WeaponAction>().CastSpell();
        fireButtonTimer = 0;
    }

    public void IceBall()
    {
        Weapon.GetComponent<WeaponAction>().CastIceBall();
        iceButtonTimer = 0;
    }

    public float CDTime(float buttonTimer, Image buttonImage, Button button)
    {
        float clamped = Mathf.Clamp(buttonTimer, 0f, 3f);
        float normalized = (clamped - 0) / (3 - 0);
        if (normalized < 1f)
        {
            buttonImage.color = Color.grey;
            button.enabled = false;
        }
        else
        {
            buttonImage.color = Color.white;
            button.enabled = true;
        }
            
        return normalized;
    }


}
