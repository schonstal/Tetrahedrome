using UnityEngine;
using System.Collections;

public class CrystalSpawn : MonoBehaviour {
  public Transform bigCrystal;
  public Transform smallCrystal;
  public Transform tinyCrystal;

  public float scaleMin = 1f;
  public float scaleMax = 2f;

  public Vector3 rotationRate = new Vector3(0f,1f,0f);
  public float floatRate = 1f; 
  public float floatDistance = 0.5f;

  private float sinAmt = 0f;

	void Start() {
    Transform main = (Transform)Instantiate(bigCrystal, Vector3.zero, Quaternion.identity);
    main.parent = transform;

    float scale = Random.Range(scaleMin,scaleMax);
    main.localScale = new Vector3(scale, scale, scale);
    main.localRotation = Quaternion.identity;
    main.localPosition = new Vector3(0,0,0);
	}

	void Update() {
	}
}
