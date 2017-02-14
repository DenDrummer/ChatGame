namespace Domain
{
    public class Character
    {
        #region Location
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        #endregion

        #region Stats
        public double Armor { get; set; }
        public double AttackSpeed { get; set; }
        public double Defense { get; set; }
        public double Health { get; set; }
        public double Level { get; set; }
        public double Speed { get; set; }
        public double Strength { get; set; }
        #endregion
    }
}