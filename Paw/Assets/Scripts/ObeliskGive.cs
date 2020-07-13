﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskGive : MonoBehaviour
{
    Controller Controller;
    private GameObject data;
    TreasureEditor treasureEditor;
    GameObject dog;//псина
    public GameObject strelka;
    void Start()
    {
        Controller = GameObject.Find("Data").GetComponent<Controller>();
        dog = GameObject.Find("Dog");
        data = GameObject.Find("Data");
        treasureEditor = data.GetComponent<TreasureEditor>();
    }

    private void OnTriggerEnter(Collider other)//зона на которой происходт потбор предмета
    {
        if (treasureEditor.amulet == true)
        {
            if (other.gameObject.tag == "Obelisk")//проверяем этот ли объект по тегу
            {
                dog.gameObject.GetComponent<Joystic_touch>().enabled = false;//отключаем передвежение для анимации
                treasureEditor.amulet = false;
                treasureEditor.score = treasureEditor.score + Convert.ToInt32((40 * treasureEditor.pointMultiplier));
                strelka.SetActive(false);
                treasureEditor.pointMultiplier = 1.5f;
                Invoke("EndOfEffect", 10);
                Invoke("TimeT", 0.5f);
            }
        }
    }
    void TimeT()//мто что мы запускаем через время
    {
        dog.gameObject.GetComponent<Joystic_touch>().enabled = true;
    }
    void EndOfEffect()
    {
        treasureEditor.pointMultiplier = 1;
    }
}
