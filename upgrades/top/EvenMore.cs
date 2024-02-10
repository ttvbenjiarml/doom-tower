using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace Doom.Upgrades.TopPath
{
    public class Even_More : ModUpgrade<Doom>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 5000;

        public override string DisplayName => "Eight of a Kind";
        public override string Description => "Throws eight Bombs at a time";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 8, 0, 20, null, false, false);
        }
    }
}