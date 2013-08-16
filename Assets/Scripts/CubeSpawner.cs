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
  public Transform particle;
   
	private float sinAmt;
	private Transform[] cubes;
	private Vector3[] sinOffsets;
	
	void Start() {
		cubes = new Transform[cubeCount];
		sinOffsets = new Vector3[cubeCount];
		
		for (int i = 0; i < cubeCount-1; i++) {
      Transform cube = (Transform)Instantiate(particle, Vector3.zero, Quaternion.identity);
			cubes[i] = cube;
      float scale = Random.Range(minScale, maxScale);

			cube.position = new Vector3(Random.Range(-radius, radius), Random.Range(2, 5), Random.Range(-radius, radius));
      cube.rotation = Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));
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

			cubes[i].Rotate(Vector3.one * Time.deltaTime * rotationRate, Space.World);
    }	
	}
}
