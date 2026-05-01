namespace EmiyaMod;

public sealed class NineLives : EmiyaCard
{
    public NineLives() : base(2, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies) { }

    public override int CanonicalStarCost => 3;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(2m, DamageProps.card)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        for (int i = 0; i < 9; i++)
        {
            await CreatureCmd.Damage(ctx, base.CombatState!.HittableEnemies,
                base.DynamicVars.Damage.BaseValue, DamageProps.card, base.Owner.Creature, this);
        }

        for (int i = 0; i < 3; i++)
        {
            var erosion = base.Owner.Creature.CombatState!.CreateCard(ModelDb.Card<Erosion>(), base.Owner);
            await CardPileCmd.AddGeneratedCardToCombat(erosion, PileType.Discard, base.Owner);
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(1m);
    }
}
