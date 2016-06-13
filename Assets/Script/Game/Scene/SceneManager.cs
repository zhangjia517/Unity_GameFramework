//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class SceneManager
{
    public delegate void LoadingStartEventHandler(SceneDefine scene);
    public event LoadingStartEventHandler LoadingStart;
    public delegate void LoadingCompleteEventHandler(SceneDefine scene);
    public event LoadingCompleteEventHandler LoadingComplete;
    public delegate void LoadingProgressEventHandler(SceneDefine scene, Single progress);
    public event LoadingProgressEventHandler LoadingProgress;

    private SceneDefine m_LastScene = SceneDefine.EMPTY;
    private SceneDefine m_CurrentScene = SceneDefine.EMPTY;
    private Boolean m_IsLoading = false;
    private Single m_LoadingProgress = 1.0f;

    private IDictionary<SceneDefine, String> m_SceneList = new Dictionary<SceneDefine, String>();
    public IDictionary<SceneDefine, String> SceneList
    {
        get { return m_SceneList; }
        set { m_SceneList = value; }
    }

    public SceneManager()
    {
        RegisterScene();
    }

    public void LoadScene(SceneDefine scene)
    {
        if (scene == m_CurrentScene)
        {
            return;
        }

        if (m_IsLoading)
        {
            return;
        }

        m_LastScene = m_CurrentScene;
        m_CurrentScene = scene;
        Loading loading = (new UnityEngine.GameObject("Loading")).AddComponent(typeof(Loading)) as Loading;
        loading.LoadingProgress += OnLoadingProgress;
        m_IsLoading = true;
        m_LoadingProgress = 0.0f;
        if (LoadingStart != null)
        {
            LoadingStart(scene);
        }
    }

    public SceneDefine GetLastScene()
    {
        return m_LastScene;
    }

    public SceneDefine GetCurrentScene()
    {
        return m_CurrentScene;
    }

    public Boolean IsLoading()
    {
        return m_IsLoading;
    }

    public Single GetLoadingProgress()
    {
        return m_LoadingProgress;
    }

    public void OnLoadingComplete()
    {
        m_IsLoading = false;
        m_LoadingProgress = 1.0f;
        if (LoadingComplete != null)
        {
            LoadingComplete(m_CurrentScene);
        }
    }

    private void OnLoadingProgress(SceneDefine scene, Single progress)
    {
        if (scene != m_CurrentScene)
        {
            Debug.Log("Current scene id error!");
            return;
        }

        m_LoadingProgress = progress;
        if (LoadingProgress != null)
        {
            LoadingProgress(scene, progress);
        }
    }

    private void RegisterScene()
    {
        m_SceneList.Add(SceneDefine.START_UP, "Startup");
        m_SceneList.Add(SceneDefine.MAIN_MENU, "MainMenu");
    }
}