using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
     public Texture2D cursorTex;    
     void Awake() { 
        Vector2 hotspot = new Vector2(cursorTex.width / 2, cursorTex.height / 2);
        Cursor.SetCursor(cursorTex, hotspot, CursorMode.ForceSoftware);  
    }
}
