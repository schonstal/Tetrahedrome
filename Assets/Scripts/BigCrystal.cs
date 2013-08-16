using UnityEngine;
using System.Collections;

public class BigCrystal : MonoBehaviour {
  public float floatRate = 1f; 
  public float floatDistance = 0.5f;

  public Vector3 rotationRate = new Vector3(0f,1f,0f);

  private float sinAmt = 0f;

  void Start() {
    sinAmt = Random.Range(0, 6.2f);
  }

  void Update() {
    transform.localRotation = Quaternion.Euler(
      Time.deltaTime * rotationRate.x + transform.localRotation.eulerAngles.x,
      Time.deltaTime * rotationRate.y + transform.localRotation.eulerAngles.y,
      Time.deltaTime * rotationRate.z + transform.localRotation.eulerAngles.z);

    sinAmt += Time.deltaTime * floatRate;
    transform.localPosition = new Vector3(0, Mathf.Sin(sinAmt) * floatDistance, 0);
  }
}
