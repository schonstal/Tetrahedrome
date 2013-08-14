using UnityEngine;
using System.Collections;

public class Spinna : MonoBehaviour {
  public int particleCount = 10000;
  public float radius = 100;
  public float tightness = 300f;
  public float scale = 2.5f;
  public GameObject prefab;

  public float sinCoefficient = 10;
  public float sinRate = 1;
   
  private float sinAmt;
  private GameObject[] particles;
  private Vector3[] sinOffsets;
  
  void Start() {
    particles = new GameObject[particleCount];
    sinOffsets = new Vector3[particleCount];
    
    for (int i = 0; i < particleCount-1; i++) {
      float offset = i * 1.61803398875f;
      GameObject particle = (GameObject)Instantiate(prefab, SphericalCoordinate.ToCartesian(radius, (offset/tightness)*Mathf.Sin(offset), (offset/tightness)*Mathf.Cos(offset)), Quaternion.identity);
 
      particles[i] = particle;
      sinOffsets[i] = particle.transform.position;
    }
  }
  
  void Update() {
    sinAmt += Time.deltaTime * sinRate;
    for (int i = 0; i < particleCount-1; i++) {
      float offset = i * 1.61803398875f;
      particles[i].transform.position =
        SphericalCoordinate.ToCartesian(radius, (offset/tightness)*Mathf.Sin(offset + sinAmt), (offset/tightness)*Mathf.Cos(offset + sinAmt));
    }	
  }
}

