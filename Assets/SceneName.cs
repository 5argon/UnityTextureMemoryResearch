using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneName : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(GameObject.FindObjectOfType<Control>().toInstantiate != null)
        {
            GetComponent<Text>().text = GameObject.FindObjectOfType<Control>().toInstantiate.name + "\n" + SceneManager.GetActiveScene().name;
        }
        else
        {
            GetComponent<Text>().text = (GameObject.FindObjectOfType<Control>().toInstantiateResource) + "\n" + SceneManager.GetActiveScene().name;
        }

    }
}
