using System.Linq;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Doom.Displays.Projectiles;
using Doom.Upgrades.midlle;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace Doom.Upgrades.MiddlePath
{
    public class AceOfSpades : ModUpgrade<Doom>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 44440;
        public override int Priority => -3;


        public override string DisplayName => "more damage";
        public override string Description => "Bombs are even more deadly, dealing extreme damage to MOAB class bloons.";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.range += 10;
            tower.GetAttackModel().range += 10; 

            foreach (var projectile in tower.GetWeapons().Select(weaponModel => weaponModel.projectile))
            {
                foreach (var damageModifierForTagModel in projectile.GetBehaviors<DamageModifierForTagModel>())
                {
                    damageModifierForTagModel.damageAddative += 42;
                }

                projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                    1, 45, false, false));

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