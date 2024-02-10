using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace Doom.Upgrades.TopPath
{
    public class MORE_POWER : ModUpgrade<Doom>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 100000;

        public override string DisplayName => "NO";
        public override string Description => "Just why even read when you can spend";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 75, 0, 20, null, false, false);
        }
    }
}