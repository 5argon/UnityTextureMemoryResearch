using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuruGuruAni : MonoBehaviour {

	public void ToggleAnimator()
	{
		GetComponent<Animator>().enabled = !GetComponent<Animator>().enabled;
	}

	public void RemoveReference()
	{
		Animator a = GetComponent<Animator>();
		Destroy(a);
	}

	public Sprite[] spritesUsedInAnimation;

	public void UnloadUsedInAnimation()
	{
		if(spritesUsedInAnimation.Length != 0)
		{
			foreach(Sprite s in spritesUsedInAnimation)
			{
				Resources.UnloadAsset(s);
			}
		}
		else
		{
			for(int i = 7; i <= 12; i++)
			{
				//Since we didnt keep references, I deliberately load just to unload.
				Sprite s = Resources.Load<Sprite>(i.ToString());
				Resources.UnloadAsset(s);
			}
		}
		Debug.Log("Unload used");
	}

	public void UnloadUsedInAnimationInner()
	{
		if(spritesUsedInAnimation.Length != 0)
		{
			foreach(Sprite s in spritesUsedInAnimation)
			{
				Resources.UnloadAsset(s.texture);
			}
		}
		else
		{
			for(int i = 7; i <= 12; i++)
			{
				//Since we didnt keep references, I deliberately load just to unload.
				Sprite s = Resources.Load<Sprite>(i.ToString());
				Resources.UnloadAsset(s.texture);
			}
		}
		Debug.Log("Unload used");
	}

}
