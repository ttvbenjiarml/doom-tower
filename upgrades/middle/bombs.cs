using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Doom.Displays.Projectiles;
using Il2Cpp;

namespace Doom.Upgrades.MiddlePath
{
    public class Bombs : ModUpgrade<Doom>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 1000;

        public override string Description => "nothing";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.ApplyDisplay<DoomDisplay>();
                weaponModel.projectile.GetDamageModel().damage += 100;
            }
        }
    }
}