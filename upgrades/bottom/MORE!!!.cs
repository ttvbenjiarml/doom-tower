using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Doom.Displays.Projectiles;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace Doom.upgrades.bottom
{
    public class FASTER : ModUpgrade<Doom>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 450;

        public override string Description => "faster bombs";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.Rate *= .666666f;
                tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 20, null, false, false);
                {
                    weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    weaponModel.projectile.ApplyDisplay<DoomDisplay>();
                }
            }
        }
    }
}