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
        SceneObject scene6Traffic = new SceneObject("The low hum of engines as they passed. Every car ride you went on you would always fall asleep.");
        SceneObject scene6Traffic2 = new SceneObject("How many cars did you own?");
        SceneObject scene6Traffic3 = new SceneObject("Sitting there quietly in the driveway.");
        SceneObject scene6Birds = new SceneObject("I can hear them chirping now, singing their song as they dance around the feeder.\nWhich bird was your favorite?");
        SceneObject scene6Birds2 = new SceneObject("I always loved its  chirping");
        SceneObject scene6Neighbors = new SceneObject("Oh you creeper, you. Always had to see what everyone was up to.\nHow did you feel about the neighbors?");
        SceneObject scene6Neighbors2 = new SceneObject("A strange bunch indeed. Always walking and playing in the yard.");

        SceneObject scene7 = new SceneObject("What else was in the front yard?");

        SceneObject scene8Table = new SceneObject("Worn now, but still solid and strong. Outside parties and picnics has given it years of use.\nWho did you enjoy time with?");
        SceneObject scene8Table2 = new SceneObject("You would eat by yourself?");

        SceneObject scene8OakTree = new SceneObject("Wide spreading arms gave the perfect shade.");
        SceneObject scene8PineTree = new SceneObject("With a height that pierced the clouds and hid the harsh sun.");

        SceneObject scene8Tree = new SceneObject("What do you enjoy doing underneath the tree?");
        SceneObject scene8Tree2 = new SceneObject("Feel the peaceful breeze and the smell of freshly mowed grass.\nWho would wake you up from the nap?");
        SceneObject scene8Tree3 = new SceneObject("You would wake up on you own?");

        SceneObject sceneEnd1 = new SceneObject("Who do you enjoy life with?");
        SceneObject sceneEnd2 = new SceneObject("You're not alone. We're here for you. We're ALL here for you.");
        SceneObject sceneEnd3 = new SceneObject("It's been a long day. You look tired. We'll try again tomorrow.");

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

        scene6Big.AddBranch(new BranchObject("Traffic", scene6Traffic));
        scene6Big.AddBranch(new BranchObject("Birds", scene6Birds));
        scene6Big.AddBranch(new BranchObject("Neighbors", scene6Neighbors));

        scene6Traffic.AddBranch(new BranchObject("...", scene6Traffic2));
        scene6Traffic2.AddBranch(new BranchObject("1", scene6Traffic3));
        scene6Traffic2.AddBranch(new BranchObject("2", scene6Traffic3));
        scene6Traffic2.AddBranch(new BranchObject("3", scene6Traffic3));
        scene6Traffic3.AddBranch(new BranchObject("...", scene7));

        scene6Birds.AddBranch(new BranchObject("Robin", scene6Birds2));
        scene6Birds.AddBranch(new BranchObject("Cardinal", scene6Birds2));
        scene6Birds.AddBranch(new BranchObject("Bluejay", scene6Birds2));
        scene6Birds2.AddBranch(new BranchObject("...", scene7));

        scene6Neighbors.AddBranch(new BranchObject("Sad", scene6Neighbors2));
        scene6Neighbors.AddBranch(new BranchObject("Angry", scene6Neighbors2));
        scene6Neighbors.AddBranch(new BranchObject("Nervous", scene6Neighbors2));
        scene6Neighbors2.AddBranch(new BranchObject("...", scene7));

        scene7.AddBranch(new BranchObject("Oak Table", scene8Table));
        scene7.AddBranch(new BranchObject("Pine Table", scene8Table));
        scene7.AddBranch(new BranchObject("Oak Tree", scene8OakTree));
        scene7.AddBranch(new BranchObject("Pine Tree", scene8PineTree));

        scene8Table.AddBranch(new BranchObject("My Spouse", scene8Table));
        scene8Table.AddBranch(new BranchObject("My Family", scene8Table));
        scene8Table.AddBranch(new BranchObject("My Friends", scene8Table));
        scene8Table.AddBranch(new BranchObject("No one", scene8Table2));

        scene8Table2.AddBranch(new BranchObject("...", sceneEnd1));

        scene8OakTree.AddBranch(new BranchObject("...", scene8Tree));
        scene8PineTree.AddBranch(new BranchObject("...", scene8Tree));

        scene8Tree.AddBranch(new BranchObject("Reading a book", scene8Tree2));
        scene8Tree.AddBranch(new BranchObject("Taking a nap", scene8Tree2));

        scene8Tree2.AddBranch(new BranchObject("My Spouse", scene8Tree3));
        scene8Tree2.AddBranch(new BranchObject("My Family", scene8Tree3));
        scene8Tree2.AddBranch(new BranchObject("My Friends", scene8Tree3));
        scene8Tree2.AddBranch(new BranchObject("No one", scene8Tree3));

        scene8Tree3.AddBranch(new BranchObject("...", sceneEnd1));

        sceneEnd1.AddBranch(new BranchObject("I'm alone", sceneEnd2));
        sceneEnd1.AddBranch(new BranchObject("I'm alone", sceneEnd2));
        sceneEnd1.AddBranch(new BranchObject("I'm alone", sceneEnd2));

        sceneEnd2.AddBranch(new BranchObject("...", sceneEnd3));

        StartScene(scene1);
        //StartScene(scene4);
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
