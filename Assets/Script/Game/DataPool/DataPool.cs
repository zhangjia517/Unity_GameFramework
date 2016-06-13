//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;

public sealed class DataPool
{
    public DataPool()
    {

    }

    //玩家
    private Player m_Player = new Player();
    public Player Player { get { return m_Player; } }

    //英雄
    private IList<Hero> m_HeroList = new List<Hero>();
    public IList<Hero> HeroList { get { return m_HeroList; } }
}