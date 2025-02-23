using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ScriptableObject
{
    //--- Movement ---
    private float playerSpd = 3f;
    private float jumpPower = 5f;
    private bool isJump = false;

    public static PlayerData instance;

    public static PlayerData getInstance()
    {
        if(instance == null)
        {
            instance = ScriptableObject.CreateInstance<PlayerData>();
        }

        return instance;
    }

    public float PlayerSpd { get { return playerSpd; }}
    public float JumpPower { get { return jumpPower; }}
    public bool IsJump { get { return isJump; } set { isJump = value; } }

}
