using UnityEngine;
using System.Collections;

public class CrystalSpawn : MonoBehaviour {
  public Transform bigCrystal;
  public Transform smallCrystal;
  public Transform tinyCrystal;

  public float scaleMin = 1f;
  public float scaleMax = 2f;

  public float distanceMin = 0f;
  public float distanceMax = 1f;

  public int crystalMax = 10;

  private float scale;

	void Start() {
    Transform main = (Transform)Instantiate(bigCrystal, Vector3.zero, Quaternion.identity);
    main.parent = transform;

    scale = Random.Range(scaleMin,scaleMax);
    main.localScale = new Vector3(scale, scale, scale);
    main.localRotation = Quaternion.identity;
    main.localPosition = new Vector3(0,0,0);

    instantiateCrystals((int)Mathf.Round(Random.Range(1,crystalMax)));
	}

  void instantiateCrystals(int count) {
    float rotationAmount = 360f / (float)count;
    for(int i=0; i < count; i++) {
      Transform t = Random.Range(0,1) < 0.5f ? smallCrystal : tinyCrystal;
      Transform anchor = (Transform)Instantiate(t, Vector3.zero, Quaternion.identity);
      anchor.parent = transform;
      anchor.localRotation = Quaternion.Euler(0, rotationAmount * i, 0);
      anchor.localPosition = Vector3.zero;

      anchor.localScale = new Vector3(scale, scale, scale);

      Transform crystal = anchor.Find("Crystal").transform;
      crystal.localPosition = new Vector3(Random.Range(crystal.localScale.x + distanceMin, distanceMax), -0.5f, 0);
    }
  }

	void Update() {
	}

  void OnDrawGizmosSelected() {
    Gizmos.color = new Color(1, 0, 0, 0.5F);
    Gizmos.DrawCube(transform.position, new Vector3(5, 5, 5));
  }

  void OnDrawGizmos() {
    Gizmos.color = new Color(0f, 0.5f, 0.2f, 0.5F);
    Gizmos.DrawCube(transform.position, new Vector3(5, 5, 5));
  }
}
