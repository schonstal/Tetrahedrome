using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {
	public int cubeCount = 10000;
	public float radius = 100;
  public float sinCoefficient = 10;
  public float sinRate = 1;
   
	private float sinAmt;
	private GameObject[] cubes;
	private Vector3[] sinOffsets;
	
	void Start() {
		cubes = new GameObject[cubeCount];
		sinOffsets = new Vector3[cubeCount];
		
		for (int i = 0; i < cubeCount-1; i++) {
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cubes[i] = cube;
			cube.transform.position = new Vector3(Random.Range(-radius, radius), Random.Range(-10, radius), Random.Range(-radius, radius));
      cube.transform.rotation = Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));
      float scale = (new float[20] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 8, 8 })[(int)Random.Range(0,19)];
      cube.transform.localScale = new Vector3(scale, scale, scale);
			sinOffsets[i] = cube.transform.position;
		}
	}
	
	void Update() {
		sinAmt += Time.deltaTime * sinRate;
		for (int i = 0; i < cubeCount-1; i++) {
			cubes[i].transform.position = new Vector3(
				sinOffsets[i].x,
				sinOffsets[i].y + Mathf.Sin(sinAmt + i)*sinCoefficient,
				sinOffsets[i].z);

			cubes[i].transform.Rotate(Vector3.one * Time.deltaTime * 100, Space.World);
    }	
	}
}
