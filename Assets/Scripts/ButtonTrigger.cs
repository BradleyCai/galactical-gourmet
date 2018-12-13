using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required when Using UI elements.

public class ButtonTrigger : MonoBehaviour {
    public Button[] buttons;

	private Scene currentScene;
    private int currButton;
    private ColorBlock highlight;
    private bool buttonDown;
    private bool isJoyDown;

    // Use this for initialization
    void Start() {
        currentScene = SceneManager.GetActiveScene();
        currButton = 0;
        highlight = ColorBlock.defaultColorBlock;
        highlight.normalColor = new Color(127/255f, 175/255f, 240/255f, 1f);
    }

	// Update is called once per frame
	void Update () {
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        buttonDown = OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Three) || OVRInput.GetDown(OVRInput.Button.Four);

		if(currentScene.name == "StartScene") {
            /* For Joystick reading */
            if (primaryAxis.y < 0) {
                if (!isJoyDown) {
                    isJoyDown = true;
                    currButton = (currButton + 1) % 2;
                }
            }
            if (primaryAxis.y > 0) {
                if (!isJoyDown) {
                    isJoyDown = true;
                    currButton = (currButton + 1) % 2;
                }
            }
            if (primaryAxis.y == 0) {
                isJoyDown = false;
            }

            // Determines which button to highlight
            for (int i = 0; i < 2; i++) {
                if (i == currButton) // highlights button user is on
                    buttons[i].colors = highlight;
                else // Button user not on is set back to default color
                    buttons[i].colors = ColorBlock.defaultColorBlock;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) || (currButton == 0 && buttonDown)) {
                SceneManager.LoadScene("InstructionScene");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || (currButton == 1 && buttonDown)) {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
            }

		}

		else if(currentScene.name == "InstructionScene") {
            if (Input.GetKeyDown(KeyCode.Alpha1) || buttonDown) { 
                SceneManager.LoadScene("PlayScene");
            }
		}

        else if(currentScene.name == "GameOverScene") {
            if (Input.GetKeyDown(KeyCode.Alpha1) || buttonDown) { 
                SceneManager.LoadScene("StartScene");
            }
        }
	}
}
