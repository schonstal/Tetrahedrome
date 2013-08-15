using UnityEngine;
 
public class GradientBackground : MonoBehaviour {
 
	public Color topColor = Color.blue;
	public Color bottomColor = Color.white;
	public int gradientLayer = 7;
  public bool leftEye;
  public float hueSpeed = 20f;

  private GameObject gradientPlane;
  private Mesh mesh;
 
	void Awake() {	
		gradientLayer = Mathf.Clamp(gradientLayer, 0, 31);
   		if (!camera) {
        	Debug.LogError ("Must attach GradientBackground script to the camera");
        	return;
    	}
 
    	camera.clearFlags = CameraClearFlags.Depth;
    	camera.cullingMask = camera.cullingMask & ~(1 << gradientLayer);
    	Camera gradientCam = new GameObject("Gradient Cam",typeof(Camera)).camera;
    	gradientCam.depth = camera.depth-1;
    	gradientCam.cullingMask = 1 << gradientLayer;
      gradientCam.pixelRect = new Rect((leftEye ? 0 : Screen.width/2),0,Screen.width/2,Screen.height);
 
		mesh = new Mesh();
		mesh.vertices = new Vector3[4]
						{new Vector3(-100f, .577f, 1f), new Vector3(100f, .577f, 1f), new Vector3(-100f, -.577f, 1f), new Vector3(100f, -.577f, 1f)};
 
		mesh.colors = new Color[4] {topColor,topColor,bottomColor,bottomColor};
 
		mesh.triangles = new int[6] {0, 1, 2, 1, 3, 2};
 
		Material mat = new Material("Shader \"Vertex Color Only\"{Subshader{BindChannels{Bind \"vertex\", vertex Bind \"color\", color}Pass{}}}");
    gradientPlane = new GameObject("Gradient Plane", typeof(MeshFilter), typeof(MeshRenderer));
 
		((MeshFilter)gradientPlane.GetComponent(typeof(MeshFilter))).mesh = mesh;
    	gradientPlane.renderer.material = mat;
    	gradientPlane.layer = gradientLayer;
	}
 
  void Update() {
    HSBColor newColor = HSBColor.FromColor(topColor);
    newColor.h += Time.deltaTime / hueSpeed;
    newColor.h = Mathf.Repeat(newColor.h, 1);
    topColor = newColor.ToColor();

    newColor = HSBColor.FromColor(bottomColor);
    newColor.h += Time.deltaTime / hueSpeed;
    newColor.h = Mathf.Repeat(newColor.h, 1);
    bottomColor = newColor.ToColor();

		mesh.colors = new Color[4] {topColor,topColor,bottomColor,bottomColor};

		((MeshFilter)gradientPlane.GetComponent(typeof(MeshFilter))).mesh = mesh;
  }
}
