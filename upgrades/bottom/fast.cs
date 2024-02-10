using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace Doom.Upgrades.bottom
{
    public class fast : ModUpgrade<Doom>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 501;

        public override string Description => "Attacks extra fast permanently and with bigger range";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.range += 25;
            tower.GetAttackModel().range += 25;
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.Rate *= .5f;
            }
        }
    }
}