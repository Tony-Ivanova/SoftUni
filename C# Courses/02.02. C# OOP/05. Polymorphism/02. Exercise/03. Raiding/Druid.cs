namespace _03._Raiding
{
    public class Druid : BaseHero
    {
        private const int power = 80;

        public Druid(string name):
            base(name, power)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(GetType)} – { Name} healed for { Power}";
        }
    }
}
