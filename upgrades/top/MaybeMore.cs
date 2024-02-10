using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace Doom.Upgrades.TopPath
{
    public class Maybe_More : ModUpgrade<Doom>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 1000;

        public override string DisplayName => "Four of a Kind";
        public override string Description => "Throws four Bombs at a time";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 4, 0, 20, null, false, false);
        }
    }
}