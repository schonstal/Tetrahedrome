using UnityEngine;
using System.Collections;

public class Colorshifter : MonoBehaviour {
  public float oscillationRate = 1;
  public float startingHue = 0.5f;
  public int direction = -1;

  private float sinAmt = 0;

	// Use this for initialization
	void Start () {
	  sinAmt = startingHue;
	}
	
	// Update is called once per frame
	void Update () {
    sinAmt += Time.deltaTime * oscillationRate * (float)direction;
    if(sinAmt > 1) sinAmt = 0;
    if(sinAmt < 0) sinAmt = 1;

    gameObject.GetComponent<EdgeDetectEffectNormals>().edgesOnlyBgColor = (new HSBColor(sinAmt, 0.6f, 0.6f)).ToColor();
	
	}
}
