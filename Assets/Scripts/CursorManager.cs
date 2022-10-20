using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
     public Texture2D cursorTex;    
     void Awake() { 
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.ForceSoftware);  
    }
}
