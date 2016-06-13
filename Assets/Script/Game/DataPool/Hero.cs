using System;

public class Hero
{
    private Int32 m_ID;
    public Int32 ID
    {
        get { return m_ID; }
        set { m_ID = value; }
    }

    private Int32 m_MaxHp;
    public Int32 MaxHp
    {
        get { return m_MaxHp; }
        set { m_MaxHp = value; }
    }

    private Int32 m_CurHp;
    public Int32 CurHp
    {
        get { return m_CurHp; }
        set { m_CurHp = value; }
    }
}