using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsUpDisplay : MonoBehaviour {
    private void OnGUI()
    {
        GUIStyle myText = new GUIStyle();
        myText.fontSize = 30;
        myText.normal.textColor = Color.magenta;

        GUIStyle FinalMessage = new GUIStyle();
        FinalMessage.fontSize = 30;
        FinalMessage.normal.textColor = Color.red;

        GUI.Label(new Rect(15, 45, Screen.width, Screen.height),
             string.Format("<b>CoolDown: {0}</b>", Mathf.Round(CharacterController.TeleportCool.Counter).ToString()),
             myText
             );

        if (WorldManager.nextenemy.Counter > 4550)
        {
            GUI.Label(new Rect(260, 500, Screen.width, Screen.height),
           "All children have a right to survive, thrive and fulfill ",
           FinalMessage
           );

            GUI.Label(new Rect(270, 540, Screen.width, Screen.height),
               "their potential - to the benefit of a better world.",
               FinalMessage
               );
        }
    }
}
