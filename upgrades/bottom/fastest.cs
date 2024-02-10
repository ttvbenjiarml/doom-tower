using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace Doom.Upgrades.bottom
{
    public class fastest : ModUpgrade<Doom>
    {
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 2500;

        public override string DisplayName => "the fastest bomb on earth or is it???";
        public override string Description => "Can attack Camo Bloons";

        public override string Portrait => "Doom-Portrait";

        /// <summary>
        /// Default priority is 0, so this lower priority makes this Upgrade always apply last so that it will catch
        /// every single FilterInvisibleModel that might've been added.
        /// </summary>
        public override int Priority => -1;

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.Rate *= .3f;
            }
        }
    }
}