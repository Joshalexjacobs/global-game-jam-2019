using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storyboard : MonoBehaviour {

    public Canvas canvas;
    public GameObject floatingText;
    public Text narratorText;

    private List<FloatingTextProperties> floatingTextPropertiesList = new List<FloatingTextProperties>();
    private List<FloatingText> floatingTextList = new List<FloatingText>();

    // Use this for initialization
    void Start () {
        floatingTextPropertiesList.Add(new FloatingTextProperties(new Vector3(-5f, 2f, 100f), "Hello?"));
        floatingTextPropertiesList.Add(new FloatingTextProperties(new Vector3(5f, 2f, 100f), "..."));

        StartCoroutine("SpawnNewWords");
    }

    IEnumerator SpawnNewWords() {
        foreach(FloatingTextProperties property in floatingTextPropertiesList) {
            SpawnSingleWord(property.GetSpawn(), property.GetText());
            yield return new WaitForSeconds(Random.Range(1f, 2.5f));
        }
    }
	
    private void SpawnSingleWord(Vector3 spawn, string text) {
        FloatingText floatingTextObj = Instantiate(floatingText, spawn, Quaternion.identity).GetComponent<FloatingText>();
        floatingTextObj.transform.parent = canvas.transform;
        floatingTextObj.transform.localScale = new Vector3(1f, 1f, 1f);
        floatingTextObj.Init(text);
        floatingTextList.Add(floatingTextObj);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
