using UnityEngine;
using System.Collections;

public class Tetrahedron : MonoBehaviour {
  public Transform tetra;
  public int triangleCount = 10;
  public float triangleScale = 100f;
  public float rotationSpeed = 1f;

  void Start() {
    for(int i = 1; i < triangleCount; i++) {
      Transform clone = (Transform)Instantiate(tetra, Vector3.zero, Quaternion.identity);
      clone.parent = transform;
      clone.localRotation = Quaternion.identity;
      clone.localPosition = new Vector3(0,0,0);
      clone.localScale = new Vector3(triangleScale*i, triangleScale*i, triangleScale*i);
    }
  }
	
  void Update() {
    transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed, Space.World);
    transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
  }
}
