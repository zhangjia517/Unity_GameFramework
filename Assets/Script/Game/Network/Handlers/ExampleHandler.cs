//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;

public class ExampleHandler : IPacketHandler
{
    public Int32 GetMessageId()
    {
        return 10001;
    }

    public void Handle(Byte[] data)
    {
        Debug.Log(System.Text.Encoding.Default.GetString(data));
    }
}