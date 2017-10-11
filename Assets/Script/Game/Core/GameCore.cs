//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameCore : MonoBehaviour
{
    public static Boolean Valid { get { return m_Instance != null; } }

    private GameCore()
    {
    }

    private static GameCore m_Instance = null;

    public static GameCore Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = GameObject.FindObjectOfType(typeof(GameCore)) as GameCore;
            }
            if (m_Instance == null)
            {
                GameObject go = new GameObject("GameCore");
                DontDestroyOnLoad(go);
                m_Instance = go.AddComponent<GameCore>();
                Debug.Log(String.Format("GameCore has been created, used time:{0}",
                                        Time.realtimeSinceStartup));
            }
            return m_Instance;
        }
    }

    //事件
    private EventManager m_EventManager = new EventManager();

    public static EventManager Event { get { return Instance.m_EventManager; } }

    //流程
    private ProcedureManager m_ProcedureManager = new ProcedureManager();

    public static ProcedureManager Procedure { get { return Instance.m_ProcedureManager; } }

    //场景
    private SceneManager m_SceneManager = new SceneManager();

    public static SceneManager Scene { get { return Instance.m_SceneManager; } }

    //数据池
    private DataPool m_DataPool = new DataPool();

    public static DataPool DataPool { get { return Instance.m_DataPool; } }

    // 网络
    private NetworkManager m_NetworkManager = new NetworkManager();

    public static NetworkManager Network { get { return Instance.m_NetworkManager; } }

    private void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += LoadScene;
    }

    private void Start()
    {
        GameCore.Procedure.Init();
    }

    private void Update()
    {
        m_EventManager.Update();
        m_NetworkManager.Update();
    }

    private void OnDestroy()
    {
        if (m_Instance == this)
        {
            m_Instance = null;
        }
    }

    private void OnApplicationQuit()
    {
        if (m_Instance == this)
        {
            m_Instance = null;
        }
    }

    private void LoadScene(Scene scene, LoadSceneMode mode)
    {
        m_SceneManager.OnLoadingComplete();
    }
}