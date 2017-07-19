using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestScene : MonoBehaviour {

	public static string NextScene { set; private get;} 
	public static System.Diagnostics.Stopwatch stopWatch;

	IEnumerator Start () {
		stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();

		yield return Resources.UnloadUnusedAssets();
		SceneManager.LoadScene(NextScene);
		yield return null; //scene will be ready after a frame, Awake in Control.cs will stop the stopeatch since this coroutine has already been destroyed

	}
	
}
