//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;

public interface IPacketHandler
{
    Int32 GetMessageId();
    void Handle(Byte[] data);
}