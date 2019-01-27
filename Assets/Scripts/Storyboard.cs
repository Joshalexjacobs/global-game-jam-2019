using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storyboard : MonoBehaviour {

    public Canvas canvas;
    public GameObject floatingText;
    public Text narratorText;
    public LineManager lineManager;

    private List<string> branchTextList = new List<string>();
    private List<BranchObject> branches = new List<BranchObject>();
    private List<FloatingTextProperties> floatingTextPropertiesList = new List<FloatingTextProperties>();

    // Use this for initialization
    void Start () {
        SceneObject scene1 = new SceneObject("Hello...");
        SceneObject scene1Who = new SceneObject("You know me");
        SceneObject scene2 = new SceneObject("How are you feeling?");
        SceneObject scene3 = new SceneObject("Where are you right now?");
        SceneObject scene3Work = new SceneObject("Back to the grind.\nWhere do you work?");
        SceneObject scene3School = new SceneObject("Ah, the golden years...\nWhat school are you in?");

        SceneObject scene4 = new SceneObject("How big is your home?");

        SceneObject scene5Small = new SceneObject("Small and simple, but not too cramped.\nWhat do you see there?");
        SceneObject scene5Firepit = new SceneObject("The crackle of fire is so soothing. Especially at night when you can gaze at the stars.");
        SceneObject scene5Garden = new SceneObject("A rainbow of flowers and produce.\nWhat was your favorite thing to grow there?");
        SceneObject scene5Garden2 = new SceneObject("Always such a sight to behold.");
        SceneObject scene5Swingset = new SceneObject("I've always loved the rush of kicking your feet into the open sky.\nWere you able to go all the way around?");
        SceneObject scene5Swingset2 = new SceneObject("Well of course!");

        SceneObject scene6Big = new SceneObject("Big and spacious with a lot of windows.\nWhat did you enjoy seeing through the windows?");


        SceneObject scene7 = new SceneObject("What else was in the front yard?");

        scene1.AddBranch(new BranchObject("Hello?", scene2, 0.5f));
        scene1.AddBranch(new BranchObject("...", scene2, 1f));
        scene1.AddBranch(new BranchObject("Who are you?", scene1Who, 5f));

        scene1Who.AddBranch(new BranchObject("Uh...", scene2));

        scene2.AddBranch(new BranchObject("Alright...", scene3, 2f));
        scene2.AddBranch(new BranchObject("Good...", scene3, 2f));
        scene2.AddBranch(new BranchObject("Uh...", scene3, 2f));

        scene3.AddBranch(new BranchObject("Work", scene3Work));
        scene3.AddBranch(new BranchObject("School", scene3School));
        scene3.AddBranch(new BranchObject("Home", scene4));

        scene3Work.AddBranch(new BranchObject("Home..?", scene4));
        scene3School.AddBranch(new BranchObject("Home..?", scene4));

        scene4.AddBranch(new BranchObject("Big", scene6Big));
        scene4.AddBranch(new BranchObject("Small", scene5Small));

        scene5Small.AddBranch(new BranchObject("Firepit", scene5Firepit));
        scene5Firepit.AddBranch(new BranchObject("...", scene7));

        scene5Small.AddBranch(new BranchObject("Garden", scene5Garden2));
        scene5Garden.AddBranch(new BranchObject("Flowers", scene5Garden2));
        scene5Garden.AddBranch(new BranchObject("Fruits", scene5Garden2));
        scene5Garden.AddBranch(new BranchObject("Vegetables", scene5Garden2));

        scene5Garden2.AddBranch(new BranchObject("...", scene7));

        scene5Small.AddBranch(new BranchObject("Swingset", scene5Swingset));
        scene5Swingset.AddBranch(new BranchObject("Yes", scene5Swingset2));
        scene5Swingset.AddBranch(new BranchObject("No", scene5Swingset2));

        scene5Swingset2.AddBranch(new BranchObject("...", scene7));

        //StartScene(scene1);
        StartScene(scene4);
    }

    public void StartScene(SceneObject scene) {
        branchTextList.Clear();
        FloatingText[] floatingTextObjects = GameObject.FindObjectsOfType<FloatingText>();

        foreach(FloatingText floatingTextObj in floatingTextObjects) {
            if(!floatingTextObj.set) {
                Destroy(floatingTextObj.gameObject);
            } else {
                floatingTextObj.BeginFadeOut();
            }
        }

        if(scene != null) {
            narratorText.text = scene.GetNarratorText();
            branches = scene.GetBranches();

            foreach (BranchObject branch in branches) {
                FloatingTextProperties floatingTextProperty = new FloatingTextProperties(
                    new Vector3(Random.Range(-5f, 5f), Random.Range(1f, 3f), 100f), 
                    branch.GetBranchText(), 
                    branch.GetPath(), 
                    branch.GetWaitTime());

                branchTextList.Add(branch.GetBranchText());
                StartCoroutine("SpawnNewWord", floatingTextProperty);
            }
        }
    }

    IEnumerator SpawnNewWord(FloatingTextProperties textProperty) {
        yield return new WaitForSeconds(textProperty.GetWaitTime());
        SpawnSingleWord(textProperty.GetSpawn(), textProperty.GetText(), textProperty.GetPath());
    }

    private void SpawnSingleWord(Vector3 spawn, string text, SceneObject path) {
        if(branchTextList.Contains(text)) {
            FloatingText floatingTextObj = Instantiate(floatingText, spawn, Quaternion.identity).GetComponent<FloatingText>();
            floatingTextObj.transform.parent = canvas.transform;
            floatingTextObj.transform.localScale = new Vector3(1f, 1f, 1f);
            floatingTextObj.Init(text, path);
        }
    }
}
