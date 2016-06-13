//---------------------------------------------------------
// Foskill Game Framework v1.0
// Copyright © 2013-2018 Fostudio. All rights reserved.
// Feedback: zhangjia517@hotmail.com
//---------------------------------------------------------


using System;
using UnityEngine;

public sealed class GameUtility
{
    public static Boolean ExistProperty(CharacterProperty propertySet, CharacterProperty property)
    {
        return (propertySet & property) != 0;
    }

    public static Color GetCharacterPropertyColor(CharacterProperty property)
    {
        if (ExistProperty(property, CharacterProperty.Fire))
        {
            return GameDefine.PROPERTY_COLOR_FIRE;
        }
        else if (ExistProperty(property, CharacterProperty.Water))
        {
            return GameDefine.PROPERTY_COLOR_WATER;
        }
        else if (ExistProperty(property, CharacterProperty.Wood))
        {
            return GameDefine.PROPERTY_COLOR_WOOD;
        }
        else if (ExistProperty(property, CharacterProperty.Light))
        {
            return GameDefine.PROPERTY_COLOR_LIGHT;
        }
        else if (ExistProperty(property, CharacterProperty.Dark))
        {
            return GameDefine.PROPERTY_COLOR_DARK;
        }
        else
        {
            return Color.white;
        }
    }
}