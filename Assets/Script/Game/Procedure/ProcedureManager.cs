//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class ProcedureManager
{
    private ProcedureBase m_CurrentProcedure = null;
    private IDictionary<ProcedureType, ProcedureBase> m_ProcedureList = new Dictionary<ProcedureType, ProcedureBase>();

    public ProcedureManager()
    {
        m_ProcedureList[ProcedureType.GAME_STARTUP] = new ProcedureStartup();
    }

    public Boolean Init()
    {
        foreach (KeyValuePair<ProcedureType, ProcedureBase> procedure in m_ProcedureList)
        {
            if (!procedure.Value.Init(this))
            {
                return false;
            }
        }

        m_CurrentProcedure = m_ProcedureList[ProcedureType.GAME_STARTUP];
        Debug.Log("Enter procedure : " + m_CurrentProcedure.GetProcedureType().ToString());
        m_CurrentProcedure.OnEnter(this);

        return true;
    }

    public void Update()
    {
        m_CurrentProcedure.Update(this);
    }

    public ProcedureBase GetActiveProcedure()
    {
        return m_CurrentProcedure;
    }

    public void ChangeProcedure(ProcedureType type)
    {
        if (m_CurrentProcedure.GetProcedureType() == type)
        {
            return;
        }
        m_CurrentProcedure.OnLeave(this);
        Debug.Log("Leave procedure : " + m_CurrentProcedure.GetProcedureType().ToString());
        m_CurrentProcedure = m_ProcedureList[type];
        Debug.Log("Enter procedure : " + m_CurrentProcedure.GetProcedureType().ToString());
        m_CurrentProcedure.OnEnter(this);
    }
}