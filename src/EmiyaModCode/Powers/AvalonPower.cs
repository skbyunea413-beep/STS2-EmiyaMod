namespace EmiyaMod;

public sealed class AvalonPower : EmiyaPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Single;

    private bool _isHealing;

    public override decimal ModifyBlockMultiplicative(
        Creature target, decimal block, ValueProp props, CardModel? cardSource, CardPlay? cardPlay)
    {
        if (target != base.Owner) return 1m;
        return 2m;
    }

    public override async Task AfterCurrentHpChanged(Creature creature, decimal delta)
    {
        if (creature != base.Owner) return;
        if (delta <= 0) return;
        if (_isHealing) return;

        _isHealing = true;
        Flash();
        await CreatureCmd.Heal(base.Owner, delta);
        _isHealing = false;
    }
}
