using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
     public Texture2D cursorTex;    
     void Awake() { 
        Debug.Log("adfasdf");
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.ForceSoftware);  
    }
}
