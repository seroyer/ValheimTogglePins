# ValheimTogglePins
Valheim mod to support toggling pins on the map

# Setup
It is helpful to start with Valheim-Modding's [wiki pages](https://github.com/Valheim-Modding/Wiki/wiki) for doing basic setup of Visual Studio, BepInEx, etc...

When you open the Visual Studio project, you'll need to Add References to the dependent libraries:
* 0Harmony.dll
* BepInEx.dll
* UnityEngine.dll
* UnityEngine.CoreModule.dll
* UnityEngine.UI.dll
* assembly_utils.dll
* assembly_valheim.dll

Then build the project.  Take the resulting ValheimTogglePins.dll and install it into the BepInEx plugins directory.
