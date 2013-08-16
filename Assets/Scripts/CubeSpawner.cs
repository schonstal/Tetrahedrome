using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {
	public int cubeCount = 10000;
	public float radius = 100;
  public float sinCoefficient = 1;
  public float sinRate = 1;
  public float minScale = 1;
  public float maxScale = 2;
  public float rotationRate = 3f;
  public float minStartHeight = 1.6f;
  public float maxStartHeight = 4f;
  public Transform particle;
  public bool rotate = true;
   
	private float sinAmt;
	private Transform[] cubes;
	private Vector3[] sinOffsets;
	
	void Start() {
		cubes = new Transform[cubeCount];
		sinOffsets = new Vector3[cubeCount];
		
		for (int i = 0; i < cubeCount; i++) {
      Transform cube = (Transform)Instantiate(particle, Vector3.zero, Quaternion.identity);
			cubes[i] = cube;
      float scale = Random.Range(minScale, maxScale);

			cube.position = new Vector3(Random.Range(-radius, radius), Random.Range(minStartHeight, maxStartHeight), Random.Range(-radius, radius));
      if(rotate) {
        cube.rotation = Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));
      }
      cube.localScale = new Vector3(scale, scale, scale);

			sinOffsets[i] = cube.position;
		}
	}
	
	void Update() {
		sinAmt += Time.deltaTime * sinRate;
		for (int i = 0; i < cubeCount-1; i++) {
			cubes[i].transform.position = new Vector3(
				sinOffsets[i].x,
				sinOffsets[i].y + Mathf.Sin(sinAmt + i)*sinCoefficient,
				sinOffsets[i].z);

      if(rotate) {
        cubes[i].Rotate(Vector3.one * Time.deltaTime * rotationRate, Space.World);
      }
    }	
	}

  void OnDrawGizmosSelected() {
    Gizmos.color = new Color(1, 0, 0, 0.5F);
    Gizmos.DrawCube(transform.position, new Vector3(2*radius, 5, 2*radius));
  }

}
