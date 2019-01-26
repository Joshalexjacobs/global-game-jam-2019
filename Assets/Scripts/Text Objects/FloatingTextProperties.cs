using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextProperties {

    private Vector3 spawn;
    private string text;

    public FloatingTextProperties(Vector3 spawn, string text) {
        this.spawn = spawn;
        this.text = text;
    }

    public Vector3 GetSpawn() {
        return spawn;
    }

    public string GetText() {
        return text;
    }
}
