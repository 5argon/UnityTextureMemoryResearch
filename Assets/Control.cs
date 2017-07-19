using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {

	public GameObject toInstantiate;
	public string toInstantiateResource;
	public string nextSceneName;

	public void Awake()
	{
		RestScene.stopWatch?.Stop();
		Debug.LogWarning("Load Scene Time : " + RestScene.stopWatch?.ElapsedMilliseconds + " ms.");
	}

	public void UnloadUnused()
	{
		LogPress(nameof(UnloadUnused));
		StartCoroutine(UnloadRoutine());
	}

	IEnumerator UnloadRoutine()
	{
		yield return Resources.UnloadUnusedAssets();
		Debug.Log("UnloadUnused finished");
	}

	public void RemoveReferences()
	{
		LogPress(nameof(RemoveReferences));
		GameObject.FindObjectOfType<GuruGuru>()?.RemoveReferences();
		GameObject.FindObjectOfType<GuruGuruAni>()?.RemoveReference();
	}

	public void UnloadConnected()
	{
		LogPress(nameof(UnloadConnected));
		GameObject.FindObjectOfType<GuruGuru>()?.UnloadConnected();
	}

	public void UnloadConnectedInner()
	{
		LogPress(nameof(UnloadConnectedInner));
		GameObject.FindObjectOfType<GuruGuru>()?.UnloadConnectedInnerTexture();
	}

	public void UnloadDisplaying()
	{
		LogPress(nameof(UnloadDisplaying));
		GameObject.FindObjectOfType<GuruGuru>()?.UnloadDisplaying();
    }

	public void UnloadDisplayingInner()
	{
		LogPress(nameof(UnloadDisplayingInner));
		GameObject.FindObjectOfType<GuruGuru>()?.UnloadDisplayingInnerTexture();
    }

	public void UnloadUsedInAnimation()
	{
		LogPress(nameof(UnloadUsedInAnimation));
		GameObject.FindObjectOfType<GuruGuruAni>()?.UnloadUsedInAnimation();
    }

	public void UnloadUsedInAnimationInner()
	{
		LogPress(nameof(UnloadUsedInAnimationInner));
		GameObject.FindObjectOfType<GuruGuruAni>()?.UnloadUsedInAnimationInner();
    }

    /* 
    Illegal : 
    UnloadAsset may only be used on individual assets and can not be used on GameObject's / Components or AssetBundles
    UnityEngine.Resources:UnloadAsset(Object)
    Control:UnloadToInstantiate() (at Assets/Control.cs:47)
    UnityEngine.EventSystems.EventSystem:Update()

        public void UnloadToInstantiate()
        {
            LogPress(nameof(UnloadToInstantiate));
            Resources.UnloadAsset(toInstantiate);
        }
		
	Illegal :
	UnloadAsset can only be used on assets;
	UnityEngine.Resources:UnloadAsset(Object)
	Control:UnloadInstantiated() (at Assets/Control.cs:53)
	UnityEngine.EventSystems.EventSystem:Update()

        public void UnloadInstantiated()
        {
            LogPress(nameof(UnloadInstantiated));
            Resources.UnloadAsset(instantiated);
        }

    */

    public void Instantiate()
	{
		LogPress(nameof(Instantiate));
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		if(toInstantiate != null)
		{
			Instantiate(toInstantiate);
		}
		else
		{
			Instantiate(Resources.Load<GameObject>(toInstantiateResource));
		}
		stopWatch.Stop();
		UnityEngine.Debug.LogWarning("Instantiation Time : " + stopWatch.ElapsedMilliseconds + " ms.");
	}

	public void LoadSpritesFromResources()
	{
		LogPress(nameof(LoadSpritesFromResources));
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		GameObject.FindObjectOfType<GuruGuru>().LoadSpritesFromResources();
		stopWatch.Stop();
		UnityEngine.Debug.LogWarning("Load Sprites From Resources Time : " + stopWatch.ElapsedMilliseconds + " ms.");
	}

	public void Destroy()
	{
		LogPress(nameof(Destroy));
		Destroy(GameObject.FindObjectOfType<GuruGuru>()?.gameObject);
		Destroy(GameObject.FindObjectOfType<GuruGuruAni>()?.gameObject);
	}

	private void LogPress(string s)
	{
		Debug.Log("Pressed " + s);
	}

	public void ToggleComponentWithSprites()
	{
		LogPress(nameof(ToggleComponentWithSprites));
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		if(GameObject.FindObjectOfType<GuruGuru>())
		{
			GameObject.FindObjectOfType<GuruGuru>().enabled = !GameObject.FindObjectOfType<GuruGuru>().enabled;
		}
		stopWatch.Stop();
		UnityEngine.Debug.LogWarning("Toggle Component Time : " + stopWatch.ElapsedMilliseconds + " ms.");
	}

	public void ToggleAnimator()
	{
		LogPress(nameof(ToggleAnimator));
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		GameObject.FindObjectOfType<GuruGuruAni>()?.ToggleAnimator();
		stopWatch.Stop();
		UnityEngine.Debug.LogWarning("Toggle Animator Time : " + stopWatch.ElapsedMilliseconds + " ms.");
	}

	public void NextScene()
	{
		LogPress(nameof(NextScene));
		RestScene.NextScene = nextSceneName;
		SceneManager.LoadScene("RestScene");
	}

	public void RestartScene()
	{
		LogPress(nameof(RestartScene));
		RestScene.NextScene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("RestScene");
	}

}
