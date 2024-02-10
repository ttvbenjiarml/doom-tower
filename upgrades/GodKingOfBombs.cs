using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;

namespace Doom.Upgrades
{
    public class GodKingOfBombs : ModParagonUpgrade<Doom>
    {
        public override int Cost => 4000000;
        public override string Description => "Sometimes the hand of fate must be forced...";
        public override string DisplayName => "God-King of Bombs";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            // Using 555 mode so not much has to be done here if you don't want to
        }
    }
}