//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;

public sealed partial class NetworkManager
{
    private void RegisterAllHandler()
    {
        RegisterHandler(new ExampleHandler());
    }
}