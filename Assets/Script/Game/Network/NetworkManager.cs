//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public sealed partial class NetworkManager
{
    private class NetPacket
    {
        public Boolean Cancelled { get; set; }
        public Exception Error { get; set; }
        public Int32 MessageId { get; set; }
        public Byte[] Data { get; set; }

        public NetPacket(Boolean cancelled, Exception error, Int32 messageId, Byte[] data)
        {
            this.Cancelled = cancelled;
            this.Error = error;
            this.MessageId = messageId;
            this.Data = data;
        }
    }

    private Uri m_ServerUri = null;
    private const String MESSAGE_ID = "MessageId";
    private WebClient m_WebClient = new WebClient();
    private IDictionary<Int32, IPacketHandler> m_PacketHandlers = new Dictionary<Int32, IPacketHandler>();
    private Queue m_PacketQueue = Queue.Synchronized(new Queue());

    public NetworkManager()
    {
        m_WebClient.UploadDataCompleted += new UploadDataCompletedEventHandler(OnUploadDataCompleted);
        RegisterAllHandler();
    }

    public void Update()
    {
        lock (m_PacketQueue)
        {
            if (m_PacketQueue.Count > 0)
            {
                //ConnectFinish...
            }

            while (m_PacketQueue.Count > 0)
            {
                NetPacket netPacket = m_PacketQueue.Dequeue() as NetPacket;

                if (netPacket == null)
                {
                    Debug.LogWarning("A null-packet found!");
                    continue;
                }

                if (netPacket.Cancelled)
                {
                    Debug.LogWarning("Upload data cancelled!");
                    continue;
                }

                if (netPacket.Error != null)
                {
                    Debug.LogWarning("Upload data exception: " + netPacket.Error.Message);
                    continue;
                }

                if (netPacket.Data == null)
                {
                    Debug.LogWarning("Invalid packet data!");
                    continue;
                }

                if (!m_PacketHandlers.ContainsKey(netPacket.MessageId))
                {
                    Debug.LogWarning("A valid packet found (MessageId=" + netPacket.MessageId + "), but there is no handler, you must forget RegisterHandler!");
                    continue;
                }

                m_PacketHandlers[netPacket.MessageId].Handle(netPacket.Data);
            }
        }
    }

    public void SetServerUrl(String url)
    {
        if (String.IsNullOrEmpty(url))
        {
            m_ServerUri = null;
            return;
        }
        m_ServerUri = new Uri(url);
    }

    public void Send(Byte[] data)
    {
        if (m_ServerUri == null)
        {
            Debug.LogError("Server URI is not available!");
            return;
        }

        if (m_WebClient.IsBusy)
        {
            Debug.LogWarning("WebClient is busy!");
            return;
        }

        try
        {
            m_WebClient.UploadDataAsync(m_ServerUri, data);
            //ConnectStart ...
        }
        catch (Exception e)
        {
            Debug.LogWarning("Upload data exception: " + e.Message);
        }
    }

    private void RegisterHandler(IPacketHandler handler)
    {
        Int32 messageId = handler.GetMessageId();
        if (m_PacketHandlers.ContainsKey(messageId))
        {
            Debug.LogWarning("Exist same handler (MessageId=" + messageId + ") already!");
            return;
        }
        m_PacketHandlers.Add(messageId, handler);
    }

    private void OnUploadDataCompleted(object sender, UploadDataCompletedEventArgs args)
    {
        Int32 messageId = 0;
        if (m_WebClient.ResponseHeaders != null)
        {
            String messageIdStr = m_WebClient.ResponseHeaders.Get(MESSAGE_ID);
            Int32.TryParse(messageIdStr, out messageId);
        }

        lock (m_PacketQueue)
        {
            m_PacketQueue.Enqueue(new NetPacket(args.Cancelled, args.Error, messageId, args.Result));
        }
    }
}