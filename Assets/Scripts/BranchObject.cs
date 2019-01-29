using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchObject {

    private string text;
    private SceneObject path;
    private float waitTime;
    private bool fadeOut;

    public BranchObject(string text) {
        this.text = text;
        path = null;
        waitTime = 0f;
    }

    public BranchObject(string text, SceneObject path) {
        this.text = text;
        this.path = path;
        this.fadeOut = false;
        waitTime = 0f;
    }

    public BranchObject(string text, bool fadeOut) {
        this.text = text;
        this.path = null;
        this.fadeOut = fadeOut;
        waitTime = 0f;
    }

    public BranchObject(string text, SceneObject path, float waitTime) {
        this.text = text;
        this.path = path;
        this.fadeOut = false;
        this.waitTime = waitTime;
    }

    public BranchObject(string text, SceneObject path, float waitTime, bool fadeOut) {
        this.text = text;
        this.path = path;
        this.fadeOut = fadeOut;
        this.waitTime = waitTime;
    }

    public string GetBranchText() {
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
