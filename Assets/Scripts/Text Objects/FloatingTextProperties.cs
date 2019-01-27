using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextProperties {

    private Vector3 spawn;
    private string text;
    private SceneObject path;
    private float waitTime;

    public FloatingTextProperties(Vector3 spawn, string text) {
        this.spawn = spawn;
        this.text = text;
    }

    public FloatingTextProperties(Vector3 spawn, string text, SceneObject path) {
        this.spawn = spawn;
        this.text = text;
        this.path = path;
    }

    public FloatingTextProperties(Vector3 spawn, string text, SceneObject path, float waitTime) {
        this.spawn = spawn;
        this.text = text;
        this.path = path;
        this.waitTime = waitTime;
    }

    public Vector3 GetSpawn() {
        return spawn;
    }

    public string GetText() {
        return text;
    }

    public SceneObject GetPath() {
        return path;
    }

    public float GetWaitTime() {
        return waitTime;
    }
}
