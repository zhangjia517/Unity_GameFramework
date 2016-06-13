//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public sealed class EventManager
{
    public delegate void EventHandler(EventDefine type, object param1 = null, object param2 = null, object param3 = null, object param4 = null);

    private class Event
    {
        public EventDefine type;
        public object param1;
        public object param2;
        public object param3;
        public object param4;

        public Event(EventDefine type, object param1 = null, object param2 = null, object param3 = null, object param4 = null)
        {
            this.type = type;
            this.param1 = param1;
            this.param2 = param2;
            this.param3 = param3;
            this.param4 = param4;
        }
    }

    private IDictionary<EventDefine, ArrayList> m_EventHandlerList = new Dictionary<EventDefine, ArrayList>();
    private Queue m_EventQueue = Queue.Synchronized(new Queue());

    public EventManager()
    {

    }

    public void Update()
    {
        while (m_EventQueue.Count > 0)
        {
            Event e = m_EventQueue.Dequeue() as Event;
            if (e == null)
            {
                Debug.Log("A null-event found!");
                continue;
            }
            ProcessEvent(e);
        }
    }

    public Boolean RegisterEventHandler(EventDefine type, EventHandler handler)
    {
        if (handler == null)
        {
            return false;
        }
        if (!m_EventHandlerList.ContainsKey(type))
        {
            m_EventHandlerList.Add(type, new ArrayList());
        }

        ArrayList handlerList = m_EventHandlerList[type];
        if (handlerList.Contains(handler))
        {
            return false;
        }

        handlerList.Add(handler);
        return true;
    }

    public Boolean UnRegisterEventHandler(EventDefine type, EventHandler handler)
    {
        if (handler == null)
        {
            return false;
        }
        if (!m_EventHandlerList.ContainsKey(type))
        {
            return false;
        }

        ArrayList handlerList = m_EventHandlerList[type];
        if (!handlerList.Contains(handler))
        {
            return false;
        }

        handlerList.Remove(handler);
        return true;
    }

    public void Fire(EventDefine type, object param1 = null, object param2 = null, object param3 = null, object param4 = null)
    {
        m_EventQueue.Enqueue(new Event(type, param1, param2, param3, param4));
    }

    private void ProcessEvent(Event e)
    {
        if (!m_EventHandlerList.ContainsKey(e.type))
        {
            return;
        }

        ArrayList handlerList = m_EventHandlerList[e.type];
        for (int i = 0; i < handlerList.Count; i++)
        {
            EventHandler handler = (EventHandler)handlerList[i];
            if (handler == null)
            {
                Debug.Log("A null-handler found, you must forget UnregisterEventHandler it!");
                continue;
            }
            else
            {
                handler(e.type, e.param1, e.param2, e.param3, e.param4);
            }
        }
    }
}
