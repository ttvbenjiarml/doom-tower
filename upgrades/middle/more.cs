using System.Linq;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Doom.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace Doom.Upgrades.middle
{
    public class More : ModUpgrade<Doom>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 1500;

        public override string DisplayName => "go wild";

        public override string Description =>
            "Powerful Bombs do more damage, further increased against Ceramic and Fortified Bloons.";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var projectile in tower.GetWeapons().Select(weaponModel => weaponModel.projectile))
            {
                projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                    1, 3, false, false));
                projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified",
                    1, 3, false, false));
                projectile.ApplyDisplay<DoomDisplay>();
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.projectile.ApplyDisplay<DoomDisplay>();
                    weaponModel.projectile.GetDamageModel().damage += 1000;
                }
            }
        }
    }
}