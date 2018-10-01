using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTex : MonoBehaviour {

    public float ScrollX = 0.5f, ScrollY = 0.5f;

	void Update () {
        float offsetX = Time.time * ScrollX;
        float offsetY = Time.time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
	}
}
