using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Question1 : UdonSharpBehaviour {
  public TMPro.TextMeshProUGUI text;
  public void SetPrompt(string new_prompt) {
    text.text = new_prompt;
  }
}
