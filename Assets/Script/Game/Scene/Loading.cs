//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public delegate void LoadingProgressEventHandler(SceneDefine scene, Single progress);
    public event LoadingProgressEventHandler LoadingProgress;

    private AsyncOperation m_AsyncOperation = null;
    private SceneDefine m_Scene = SceneDefine.EMPTY;

    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += LoadScene;
    }

    private void LoadScene(Scene scene, LoadSceneMode mode)
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();

    }

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
        m_AsyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(GameCore.Scene.SceneList[m_Scene]);
        yield return m_AsyncOperation;
    }
}