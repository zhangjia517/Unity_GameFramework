using UnityEngine;
using System.Collections;
using System;

public class Player
{
    //玩家ID
    public Int32 PlayerId { get; set; }
    //玩家序列号
    public Int32 AccountId { get; set; }
    //设备ID
    public String DeviceId { get; set; }
    //名字
    public String Name { get; set; }
    //等级
    public Int32 Level { get; set; }
    //经验
    public Int32 Exp { get; set; }
    //属性
    public Int32 Property { get; set; }
    //金币
    public Int32 Gold { get; set; }
    //上次登录时间
    public DateTime LastLoginTime { get; set; }
    //当前体力
    public Int32 CurrentPower { get; set; }
}