using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class DudeController : MonoBehaviour {

    DudeActions dudeActions;

	// Use this for initialization
	void Start () {
        dudeActions = new DudeActions();

        dudeActions.left.AddDefaultBinding(Key.A);
        dudeActions.left.AddDefaultBinding(Key.LeftArrow);
        dudeActions.left.AddDefaultBinding(InputControlType.DPadLeft);
        dudeActions.left.AddDefaultBinding(InputControlType.LeftStickLeft);

        dudeActions.right.AddDefaultBinding(Key.D);
        dudeActions.right.AddDefaultBinding(Key.RightArrow);
        dudeActions.right.AddDefaultBinding(InputControlType.DPadRight);
        dudeActions.right.AddDefaultBinding(InputControlType.LeftStickRight);

        dudeActions.up.AddDefaultBinding(Key.W);
        dudeActions.up.AddDefaultBinding(Key.UpArrow);
        dudeActions.up.AddDefaultBinding(InputControlType.DPadUp);
        dudeActions.up.AddDefaultBinding(InputControlType.LeftStickUp);

        dudeActions.down.AddDefaultBinding(Key.S);
        dudeActions.down.AddDefaultBinding(Key.DownArrow);
        dudeActions.down.AddDefaultBinding(InputControlType.DPadDown);
        dudeActions.down.AddDefaultBinding(InputControlType.LeftStickDown);
    }

    public float DudeHorizontal() {
        return dudeActions.moveX.Value;
    }

    public float DudeVertical() {
        return dudeActions.moveY.Value;
    }
}
