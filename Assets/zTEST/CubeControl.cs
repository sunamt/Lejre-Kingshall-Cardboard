using UnityEngine;
using System.Collections;

public class CubeControl : MonoBehaviour {
    
    SpriteRenderer[] c1;
    SpriteRenderer[] c2;
    SpriteRenderer[] c3;
    public Position pos; // public for debug
    Position lastPos;

    void Start()
    {
        pos = Position.Pos1;
        lastPos = Position.Pos1;
        c1 = GameObject.Find("Cube_Sprite1").GetComponentsInChildren<SpriteRenderer>();
        c2 = GameObject.Find("Cube_Sprite2").GetComponentsInChildren<SpriteRenderer>();
        c3 = GameObject.Find("Cube_Sprite3").GetComponentsInChildren<SpriteRenderer>();

        ToggleCube(true, c1);
        ToggleCube(false, c2);
        ToggleCube(false, c3);
    }
    
    void Update()
    {
        if (!pos.Equals(lastPos))
        {
            if (pos.Equals(Position.Pos1))
            {
                lastPos = Position.Pos1;
                ToggleCube(true, c1);
                ToggleCube(false, c2);
                ToggleCube(false, c3);
            }
            else if (pos.Equals(Position.Pos2))
            {
                lastPos = Position.Pos2;
                ToggleCube(false, c1);
                ToggleCube(true, c2);
                ToggleCube(false, c3);
            }
            else if (pos.Equals(Position.Pos3))
            {
                lastPos = Position.Pos3;
                ToggleCube(false, c1);
                ToggleCube(false, c2);
                ToggleCube(true, c3);

            }
        }
    }
    
    void ToggleCube(bool on, SpriteRenderer[] cube)
    {
        if(on)
        {
            foreach (SpriteRenderer sr in cube)
                sr.enabled = true;
        }
        else if (!on)
        {
            foreach (SpriteRenderer sr in cube)
                sr.enabled = false;
        }
    }

    public void SetPos(Position p)
    {
        pos = p;
        Debug.Log("new pos " + pos);
    }

    public enum Position { Pos1, Pos2, Pos3 }
}
