using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace Doom.Upgrades.bottom
{
    public class even_faster : ModUpgrade<Doom>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 1000;

        public override string Description => "even fatser bombs";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {

            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.Rate *= .4f;
            }
        }
    }
}