using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int Player1Score = 0;
    public static int Player2Score = 0;
    private static bool started = false;

    public GUISkin layout;

    GameObject theBall;

    // Start is called before the first frame update
    void Start() {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }
    
    public static void Score (string wallID) {
        if (wallID == "RightWall") {
            Player1Score++;
        } else {
            Player2Score++;
        }
    }

    void OnGUI() {
        Rect startButtonRect = new Rect(Screen.width / 2 - 35, 20, 120, 53);
        GUI.skin = layout;
        GUI.Label(new Rect((Screen.width / 2) - 138, 20, 100, 100), "" + Player1Score);
        GUI.Label(new Rect((Screen.width / 2) + 162, 20, 100, 100), "" + Player2Score);

        if (started) {
            if (GUI.Button(startButtonRect, "RESTART")) {
                Player1Score = 0;
                Player2Score = 0;
                theBall.SendMessage("RestartGame", 0f, SendMessageOptions.RequireReceiver);
            }
        } else {
            if (GUI.Button(startButtonRect, "START")) {
                started = true;
                theBall.SendMessage("StartGame", 0.5f, SendMessageOptions.RequireReceiver);
            }
        }

        if (Player1Score == 10) {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (Player2Score == 10) {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
