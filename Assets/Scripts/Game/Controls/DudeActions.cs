using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class DudeActions : PlayerActionSet {

    public PlayerAction left;
    public PlayerAction right;
    public PlayerAction up;
    public PlayerAction down;

    public PlayerOneAxisAction moveX;
    public PlayerOneAxisAction moveY;

	public DudeActions() {
        left = CreatePlayerAction("Left");
        right = CreatePlayerAction("Right");
        up = CreatePlayerAction("Up");
        down = CreatePlayerAction("Down");

        moveX = CreateOneAxisPlayerAction(left, right);
        moveY = CreateOneAxisPlayerAction(down, up);
    }
}
