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
    private bool isDown;
    private bool isJoyDown;

    // Use this for initialization
    void Start() {
        currentScene = SceneManager.GetActiveScene();
        currButton = 0;
        highlight = ColorBlock.defaultColorBlock;
        highlight.normalColor = new Color(127/255f, 175/255f, 240/255f, 1f);
        isDown = OVRInput.Get(OVRInput.Button.One);
    }

	// Update is called once per frame
	void Update () {
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        bool buttonDown = OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.Three) || OVRInput.Get(OVRInput.Button.Four);

		if(currentScene.name == "StartScene") {
            if (Input.GetKeyDown(KeyCode.Alpha1)) // start the game
				ChangeMenu.PlayGame();
			if (Input.GetKeyDown(KeyCode.Alpha2)) // show instructions
				ChangeMenu.LoadInstructions();
			if (Input.GetKeyDown(KeyCode.Alpha3)) // quit the program
				ChangeMenu.QuitGame();

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

            for (int i = 0; i < 2; i++) {
                if (i == currButton)
                    buttons[i].colors = highlight;
                else
                    buttons[i].colors = ColorBlock.defaultColorBlock;
            }

            if (currButton == 0 && buttonDown && !isDown) {
                isDown = true;
                ChangeMenu.LoadInstructions();
            }
            else if (currButton == 1 && buttonDown && !isDown) {
                isDown = true;
                ChangeMenu.QuitGame();
            }

            if (!buttonDown) {
                isDown = false;
            }
		}
		if(currentScene.name == "InstructionScene") {
            if (Input.GetKeyDown(KeyCode.Alpha1) || buttonDown) { // go back to main menu
                if (!isDown) {
                    isDown = true;
                    ChangeMenu.PlayGame();
                }
            }
            else if (!buttonDown) {
                isDown = false;
            }
		}
	}
}
