using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class ColliderToggleHandler : UdonSharpBehaviour {
  public Collider[] colliders;
  public AudioSource toggleSound;

  private Toggle toggle;
  private bool firstRun = true;
  private bool enabled = true;

  void Start() {
    toggle = GetComponent<Toggle>();
    OnValueChanged();
  }
  public override void Interact() {
    enabled = !enabled;
    OnValueChanged();
  }
  public void OnValueChanged() {
    if (toggle == null) {
      foreach (Collider c in colliders) c.enabled = enabled;
    } else {
      foreach (Collider c in colliders) c.enabled = toggle.isOn;
    }
    if (toggleSound != null && !firstRun) {
      toggleSound.PlayOneShot(toggleSound.clip);
    }
    firstRun = false;
  }
}
