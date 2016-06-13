//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;

public abstract class ProcedureBase
{
    public abstract ProcedureType GetProcedureType();

    public abstract Boolean Init(ProcedureManager manager);

    public abstract void OnEnter(ProcedureManager manager);

    public abstract void Update(ProcedureManager manager);

    public abstract void OnLeave(ProcedureManager manager);
}