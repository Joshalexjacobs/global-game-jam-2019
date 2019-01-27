using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject {

    private string narratorText;
    private List<BranchObject> branches = new List<BranchObject> ();

    public SceneObject(string narratorText) {
        this.narratorText = narratorText;
    }

    public void AddBranch(BranchObject branch) {
        branches.Add(branch);
    }

    public string GetNarratorText() {
        return narratorText;
    }

    public List<BranchObject> GetBranches() {
        return branches;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
