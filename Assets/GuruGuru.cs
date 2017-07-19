using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuruGuru : MonoBehaviour {

	public Sprite[] sprites;

	public void LoadSpritesFromResources()
	{
		sprites = new Sprite[6];
		for(int i = 7; i <= 12; i++)
		{
			sprites[i-7] = Resources.Load<Sprite>(i.ToString());
		}
	}

	public void UnloadConnected()
	{
		foreach(Sprite s in sprites)
		{
			Resources.UnloadAsset(s);
		}
		Debug.Log("Unloaded");
	}

	public void UnloadConnectedInnerTexture()
	{
		foreach(Sprite s in sprites)
		{
			Resources.UnloadAsset(s.texture);
		}
		Debug.Log("Unloaded");
	}

	private Sprite remember;
	public void RemoveReferences()
	{
		remember = GetComponent<Image>().sprite;
		sprites = new Sprite[6];
		GetComponent<Image>().sprite = null;
	}

	/// <summary>
	/// Can also unload the one that you just removed the references
	/// </summary>
	public void UnloadDisplaying()
	{
		if(remember != null)
		{
			Resources.UnloadAsset(remember);
		}
		else
		{
			Resources.UnloadAsset(GetComponent<Image>().sprite);
		}
	}

	public void UnloadDisplayingInnerTexture()
	{
		if(remember != null)
		{
			Resources.UnloadAsset(remember.texture);
		}
		else
		{
			Resources.UnloadAsset(GetComponent<Image>().sprite.texture);
		}
	}

	void Start()
	{
		Debug.Log("Start");
		StartCoroutine(AnimateRoutine());
	}

	IEnumerator AnimateRoutine()
	{
		foreach(Sprite s in sprites)
		{
			GetComponent<Image>().sprite = s;
			yield return new WaitForSeconds(0.2f);
		}
	}

}
