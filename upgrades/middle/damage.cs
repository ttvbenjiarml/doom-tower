using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Doom.Displays.Projectiles;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace Doom.Upgrades.midlle
{
    public class Damage : ModUpgrade<Doom>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 100000;

        public override string DisplayName => "Bombs";

        public override string Description =>
            "Ability: Throws a super powerful Bomb that seeks Bloons along the track.";

        public override string Portrait => "Doom-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            var abilityModel = new AbilityModel("AbilityModel_AceInTheHole", "Bombs",
                "Ability: Throws a super powerful Bomb that seeks Bloons along the track.", 1, 0,
                GetSpriteReference(Icon), 44f, null, false, false, null,
                0, 0, 9999999, false, false);
            tower.AddBehavior(abilityModel);

            var activateAttackModel = new ActivateAttackModel("ActivateAttackModel_AceInTheHole", 0, true,
                new Il2CppReferenceArray<AttackModel>(1), true, false, false, false, false);
            abilityModel.AddBehavior(activateAttackModel);

            var attackModel = activateAttackModel.attacks[0] =
                Game.instance.model.GetTower(TowerType.BoomerangMonkey, 4).GetAttackModel().Duplicate();
            activateAttackModel.AddChildDependant(attackModel);

            attackModel.behaviors = attackModel.behaviors
                .RemoveItemOfType<Model, RotateToTargetModel>()
                .RemoveItemOfType<Model, TargetStrongModel>()
                .RemoveItemOfType<Model, TargetLastModel>()
                .RemoveItemOfType<Model, TargetCloseModel>();

            var targetFirstModel = attackModel.GetBehavior<TargetFirstModel>();
            targetFirstModel.isSelectable = false;
            attackModel.targetProvider = targetFirstModel;

            attackModel.range = 20000;
            attackModel.attackThroughWalls = true;


            var weapon = attackModel.weapons[0];
            weapon.emission.AddBehavior(
                new EmissionRotationOffBloonDirectionModel("EmissionRotationOffBloonDirectionModel", false, false));

            var projectileModel = weapon.projectile;

            projectileModel.ApplyDisplay<DoomDisplay>();
            projectileModel.pierce = 10000;
            projectileModel.RemoveBehavior<RotateModel>();
            projectileModel.GetBehavior<RetargetOnContactModel>().distance = 2000;
            projectileModel.GetDamageModel().damage = 20000000000;
            projectileModel.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 300, false, false));
            projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified",
                1, 300, false, false));
            projectileModel.GetBehavior<TravelStraitModel>().Speed = 500f;
            projectileModel.GetBehavior<TravelStraitModel>().Lifespan = 5.0f;

            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.ApplyDisplay<DoomDisplay>();
                weaponModel.projectile.GetDamageModel().damage += 100000;
            }
        }
    }
}