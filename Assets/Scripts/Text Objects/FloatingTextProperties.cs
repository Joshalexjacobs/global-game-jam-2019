using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextProperties {

    private Vector3 spawn;
    private string text;
    private SceneObject path;
    private float waitTime;
    public bool fadeOut;

    public FloatingTextProperties(Vector3 spawn, string text) {
        this.spawn = spawn;
        this.text = text;
        fadeOut = false;
    }

    public FloatingTextProperties(Vector3 spawn, string text, SceneObject path) {
        this.spawn = spawn;
        this.text = text;
        this.path = path;
        fadeOut = false;
    }

    public FloatingTextProperties(Vector3 spawn, string text, SceneObject path, float waitTime) {
        this.spawn = spawn;
        this.text = text;
        this.path = path;
        this.waitTime = waitTime;
        fadeOut = false;
    }

    public FloatingTextProperties(Vector3 spawn, string text, SceneObject path, float waitTime, bool fadeOut) {
        this.spawn = spawn;
        this.text = text;
        this.path = path;
        this.waitTime = waitTime;
        this.fadeOut = fadeOut;
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

    public bool GetFadeOut() {
        return fadeOut;
    }
}
