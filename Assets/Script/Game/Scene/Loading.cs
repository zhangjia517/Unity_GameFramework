//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
    public delegate void LoadingProgressEventHandler(SceneDefine scene, Single progress);
    public event LoadingProgressEventHandler LoadingProgress;

    private AsyncOperation m_AsyncOperation = null;
    private SceneDefine m_Scene = SceneDefine.EMPTY;

    private void Start()
    {
        m_Scene = GameCore.Scene.GetCurrentScene();
        StartCoroutine(Load());
    }

    private void Update()
    {
        if (m_AsyncOperation == null)
        {
            return;
        }
        if (LoadingProgress != null)
        {
            LoadingProgress(m_Scene, m_AsyncOperation.progress);
        }
    }

    private IEnumerator Load()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
        m_AsyncOperation = Application.LoadLevelAsync(GameCore.Scene.SceneList[m_Scene]);
        yield return m_AsyncOperation;
    }

    private void OnLevelWasLoaded()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}