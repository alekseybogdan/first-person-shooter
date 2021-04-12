using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEmerger : MonoBehaviour
{
	Graphic text;
	public float duration = 1f;
	public float fadeSpeed = 2f;

	void Start()
	{		
		text = GetComponent<Text>();
		text.GetComponent<CanvasRenderer>().SetAlpha(0f);
	}

	public void Activate()
	{
		text.CrossFadeAlpha(1f, fadeSpeed, false);

		Invoke("Deactivate", duration);
	}

	void Deactivate()
	{
		text.GetComponent<CanvasRenderer>().SetAlpha(1f);
		text.CrossFadeAlpha(0f, fadeSpeed, false);
	}
}
