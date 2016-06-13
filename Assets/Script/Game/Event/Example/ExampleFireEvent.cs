//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using UnityEngine;
using System.Collections;

public class ExampleFireEvent : MonoBehaviour
{
    void Start()
    {
        GameCore.Event.RegisterEventHandler(EventDefine.GAME_START, OnGameStart);
        GameCore.Event.Fire(EventDefine.GAME_START, "ExampleFireEvent");
    }

    private void OnGameStart(EventDefine type, object param1 = null, object param2 = null, object param3 = null, object param4 = null)
    {
        Debug.Log(param1);
    }

    void OnDestroy()
    {
        if (GameCore.Valid)
        {
            GameCore.Event.UnRegisterEventHandler(EventDefine.GAME_START, OnGameStart);
        }
    }
}