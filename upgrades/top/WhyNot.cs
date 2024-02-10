using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace Doom.Upgrades.TopPath
{
    public class Why_Not : ModUpgrade<Doom>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 10000;

        public override string DisplayName => "no of a Kind";
        public override string Description => "Throws Bombs at a time";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 16, 0, 20, null, false, false);
        }
    }
}