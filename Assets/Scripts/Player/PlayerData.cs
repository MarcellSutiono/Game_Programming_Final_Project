using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ScriptableObject
{
    //--- Movement ---
    private float playerSpd = 3.5f;
    private float jumpPower = 8f;
    private bool isJump = false;

    //--- Gems ---
    private bool redGem = false;
    private bool blueGem = false;
    private bool orangeGem = false;
    private bool whiteGem = false;

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
    public bool RedGem { get { return redGem; } set { redGem = value; } }
    public bool BlueGem { get { return blueGem; } set { blueGem = value; } }
    public bool OrangeGem { get { return orangeGem; } set { orangeGem = value; } }
    public bool WhiteGem { get { return whiteGem; } set { whiteGem = value; } }

}
