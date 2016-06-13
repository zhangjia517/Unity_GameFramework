//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;

public sealed class GameDefine
{
    public static readonly Int32 GAME_VERSION = 20150101;
    public static readonly String DEVICE_ID = SystemInfo.deviceUniqueIdentifier;

    public static readonly Color PROPERTY_COLOR_FIRE = new Color32(227, 48, 0, 255);
    public static readonly Color PROPERTY_COLOR_WATER = new Color32(36, 150, 230, 255);
    public static readonly Color PROPERTY_COLOR_WOOD = new Color32(103, 196, 2, 255);
    public static readonly Color PROPERTY_COLOR_LIGHT = new Color32(246, 197, 0, 255);
    public static readonly Color PROPERTY_COLOR_DARK = new Color32(141, 75, 250, 255);
}

public enum CharacterProperty
{
    None = 0,
    Fire = 1 << 0,
    Water = 1 << 1,
    Wood = 1 << 2,
    Light = 1 << 3,
    Dark = 1 << 4,
    All = Fire | Water | Wood | Light | Dark,
}