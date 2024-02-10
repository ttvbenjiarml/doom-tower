using MelonLoader;
using BTD_Mod_Helper;
using Doom;

[assembly: MelonInfo(typeof(DoomMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Doom;

public class DoomMod : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        
    }
}