﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

    private static DamageNumbers popupText;
    private static GameObject canvas;
    public GameObject popuptextreference;



    public static void Initialize()
    {
        Debug.Log("initializing Floatingtext Controller");
        canvas = GameObject.Find("PlayerUI");
        if (!popupText)
        {
            popupText = Resources.Load<DamageNumbers>("Prefabs/PopupTextParent");
        }
    }


    public static void CreateFloatingText(string text, Transform location,float DMGAMT)
    {
        if (GameManagerScript.instance.damageText)
        {
            DamageNumbers instance = Instantiate(popupText);
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2((location.position.x + Random.Range(-.3f, .3f)), (location.position.y-2f)));
            instance.transform.SetParent(canvas.transform, false);
            instance.transform.position = screenPosition;
            if (DMGAMT < 1)
            {
                instance.transform.localScale = new Vector2(.2f, .2f);
            }
            if ((DMGAMT < 10) && DMGAMT > 1)
            {
                instance.transform.localScale = new Vector2(.5f, .5f);
            }
            if (DMGAMT > 20)
            {
                instance.transform.localScale = new Vector2(1.5f, 1.5f);
            }
            instance.SetText(text);
        }
    }
}
