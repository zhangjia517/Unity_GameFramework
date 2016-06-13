//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;

public class ProcedureStartup : ProcedureBase
{
    private Single m_ElapseTime = 0.0f;

    public override ProcedureType GetProcedureType()
    {
        return ProcedureType.GAME_STARTUP;
    }

    public override Boolean Init(ProcedureManager manager)
    {
        return true;
    }

    public override void OnEnter(ProcedureManager manager)
    {
        m_ElapseTime = 0.0f;
        GameCore.Scene.LoadScene(SceneDefine.START_UP);
        GameCore.Scene.LoadingComplete += OnSceneLoadComplete;
    }

    public override void Update(ProcedureManager manager)
    {
        m_ElapseTime += UnityEngine.Time.deltaTime;
    }

    public override void OnLeave(ProcedureManager manager)
    {

    }

    private void OnSceneLoadComplete(SceneDefine scene)
    {
        Debug.Log(GameCore.Scene.SceneList[scene] + " scene is load completed");
        //短连接
        GameCore.Network.SetServerUrl("http://127.0.0.1:5517");
    }
}