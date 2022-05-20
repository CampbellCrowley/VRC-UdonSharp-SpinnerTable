using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class TablePicker : UdonSharpBehaviour {
  public Material table_mat;
  public Color[] table_col;
  public string[][] prompts;
  public TablePrompt[] tiles;
  public Image[] buttons;

  [UdonSynced] public int selected = 0;

  public void Start() {
    UpdateBoardWithSelected();
    for (int i = 0; i < buttons.Length; ++i) {
      buttons[i].color = i < table_col.Length ? table_col[i] : Color.black;
    }
  }
  public override void OnDeserialization() {
    UpdateBoardWithSelected();
  }
  private void UpdateBoardWithSelected() {
    string[] sel_prompts = selected < prompts.Length ? prompts[selected] : null;
    for (int i = 0; i < tiles.Length; ++i) {
      string txt = sel_prompts != null && i < sel_prompts.Length ? sel_prompts[i] : "";
      tiles[i].SetPrompt(txt);
    }
    if (table_mat != null && table_col.Length > 0) {
      int idx = selected % table_col.Length;
      table_mat.SetColor("_Color", table_col[idx]);
    }
  }
  public void Board(int num) {
    Debug.Log("SpinnerBoard Change Requested to " + num);
    if (!Networking.IsOwner(gameObject)) {
      Networking.SetOwner(Networking.LocalPlayer, gameObject);
    }
    selected = num;
    UpdateBoardWithSelected();
    RequestSerialization();
  }

  // Custom event handlers.
  public void Board0() { Board(0); }
  public void Board1() { Board(1); }
  public void Board2() { Board(2); }
  public void Board3() { Board(3); }
  public void Board4() { Board(4); }
  public void Board5() { Board(5); }
  public void Board6() { Board(6); }
  public void Board7() { Board(7); }
}
