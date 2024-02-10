using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.Utils.ElasticSearch;
using Doom.Displays.Projectiles;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace Doom.Upgrades.middle
{
    public class Why : ModUpgrade<Doom>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 400;

        public override string DisplayName => "Cut the Bombs";
        public override string Description => "more pierce";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)

        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.ApplyDisplay<DoomDisplay>();
                weaponModel.projectile.GetDamageModel().damage += 10;
                {
                    weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    weaponModel.projectile.ApplyDisplay<DoomDisplay>();
                }
            }
            }
        }
    }