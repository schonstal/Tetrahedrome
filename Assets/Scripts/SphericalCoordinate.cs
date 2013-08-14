using UnityEngine;
 
public class SphericalCoordinate
{
  public float Radius {
    get { return radius; }
    set { radius = value; }
  }

  public float Polar {
    get{ return polar; }
    set { polar = Mathf.Repeat(value, Mathf.PI*2.0f); }
  }

  public float Azimuth {
    get{ return azimuth; }
    set { azimuth = Mathf.Repeat(value, Mathf.PI*2.0f); }
  }

  private float radius,
                polar,
                azimuth;

  public static Vector3 ToCartesian(float radius, float polar, float azimuth) {
    float a = radius * Mathf.Cos(azimuth);
    return new Vector3(a * Mathf.Cos(polar), radius * Mathf.Sin(azimuth), a * Mathf.Sin(polar));
  }

  public SphericalCoordinate(Vector3 cartesianCoordinate) {
    FromCartesian(cartesianCoordinate);
  }

  public SphericalCoordinate(float radius, float polar, float azimuth) {
      Radius = radius;
      Polar = polar;
      Azimuth = azimuth;
  }

  public Vector3 ToCartesian() {
    float a = radius * Mathf.Cos(azimuth);
    return new Vector3(a * Mathf.Cos(polar), radius * Mathf.Sin(azimuth), a * Mathf.Sin(polar));
  }

  public SphericalCoordinate FromCartesian(Vector3 cartesianCoordinate)
  {
      if(cartesianCoordinate.x == 0f)
        cartesianCoordinate.x = Mathf.Epsilon;
      radius = cartesianCoordinate.magnitude;

      polar = Mathf.Atan(cartesianCoordinate.z / cartesianCoordinate.x);

      if( cartesianCoordinate.x < 0f )
          polar += Mathf.PI;
      azimuth = Mathf.Asin(cartesianCoordinate.y / radius);

      return this;
  }
}
