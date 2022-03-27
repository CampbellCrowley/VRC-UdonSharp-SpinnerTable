# SpikeyRobot's SpinnerTable
A customizable table with a spinner perfect for drinking games in VRChat. Built with UdonSharp.

Feel free to use this in your worlds, if possible please link back to this GitHub page so others can find this.

![Example Image of Table in Unity](./Images/ExampleScene.png?raw=true)

## Requirements / Installation
1) VRChat Udon Worlds SDK.
2) [UdonSharp](https://github.com/vrchat-community/UdonSharp).
3) Import this project.
4) If prompted, import TMP Essentials.

## Configuration
- The "TablePicker" GameObject contains the main UdonBehaviour that can be used to configure prompts and colors.
  - ![Location of table settings](./Images/TablePromptSettings1.png?raw=true)
  - For those interested in customizing further, this can also be edited to add more table tops and prompts. Just ensure that `Table_col`, `Prompts`, and `Buttons` have the same number of elements.
  - ![Example layout of table settings](./Images/TablePromptSettings2.png?raw=true)
- Spinner speeds can be configured on the "Spinner/default" GameObject.
  - ![Location of spinner settings](./Images/TableSpinnerSettings.png?raw=true)
  - Values for Impulse are the range in initial velocities of the spinner in degrees per second.
  - Acceleration is degrees/s^2.

# License
MIT License  
Please provide credits such that others can find this project.
