using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Doom.Displays.Projectiles;

namespace Doom.Upgrades.TopPath
{
    public class HowMany : ModUpgrade<Doom>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 551;

        public override string DisplayName => "Two of a Kind";
        public override string Description => "Throws Two Bombs at a time";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 20, null, false, false);
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                weaponModel.projectile.ApplyDisplay<DoomDisplay>();
            }
        }
    }
}