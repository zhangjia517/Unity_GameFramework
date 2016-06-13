//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour
{
    void Start()
    {
        if (GameCore.Instance == null)
        {
            //单例（非实例化）
        }
    }
}