using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchObject {

    private string text;
    private SceneObject path;
    private float waitTime;

    public BranchObject(string text) {
        this.text = text;
        path = null;
        waitTime = 0f;
    }

    public BranchObject(string text, SceneObject path) {
        this.text = text;
        this.path = path;
        waitTime = 0f;
    }

    public BranchObject(string text, SceneObject path, float waitTime) {
        this.text = text;
        this.path = path;
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
}
