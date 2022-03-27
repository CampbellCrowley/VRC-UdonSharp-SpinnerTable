using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Spinner : UdonSharpBehaviour {
  [UdonSynced] private float spinnerVelocity = 0f;
  [UdonSynced] private float spinnerPosition = 0f;
  private float sV = 0f;
  private float sP = 0f;
  public float minImpulse = 360f;
  public float maxImpulse = 720f;
  public float acceleration = -72f;
  private float t0 = 0f;

  public UnityEngine.UI.Text dbgText;

  public override void Interact() {
    StartSpinner();
  }

  public override void OnDeserialization() {
    if (sV != spinnerVelocity || sP != spinnerPosition) {
      Debug.Log("Spinning! " + spinnerVelocity + " " + spinnerPosition + " vs " + sV + " " + sP);
      sV = spinnerVelocity;
      sP = spinnerPosition;

      transform.rotation = Quaternion.Euler(0f, sP, 0f);
      t0 = Time.time;
    } else {
      // Debug.Log("Spinning! Again? " + spinnerVelocity + " " + spinnerPosition);
    }
  }

  void Update() {
    if (sV != 0f) {
      transform.localPosition = Vector3.zero;
      float dt = Time.time - t0;
      // v = v0 + at
      float v = sV + acceleration * dt;
      if (v <= 0f) {
        v = sV = 0f;
        sP = transform.rotation.eulerAngles.y;
        if (Networking.IsOwner(gameObject)) {
          spinnerVelocity = 0f;
          spinnerPosition = sP;
          RequestSerialization();
        }
      } else {
        // dx = v0t + 1/2 * at^2
        float dx = sV * dt + 0.5f * acceleration * (dt * dt);
        float x = dx + sP;
        transform.rotation = Quaternion.Euler(0f, x, 0f);
      }
      if (dbgText != null) {
        dbgText.text = "vel: " + v +
                     "\npos: " + transform.rotation.eulerAngles.y +
                     "\nimp: " + sV;
      }
    }
  }
  public void StartSpinner() {
    Debug.Log("Spinner Start Requested.");
    if (!Networking.IsOwner(gameObject)) {
      Networking.SetOwner(Networking.LocalPlayer, gameObject);
    }
    sV = spinnerVelocity = Random.Range(minImpulse, maxImpulse);
    sP = spinnerPosition = transform.rotation.eulerAngles.y;
    t0 = Time.time;
    RequestSerialization();
  }
}
