namespace ChatGame.BL.Domain
{
    public abstract class Character
    {
        public ushort Id { get; set; }

        #region Location
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        #endregion

        #region Stats
        //the ammount of damage halved after substracting blocked damage
        public double Armor { get; set; }
        //the speed of attacking
        public double AttackSpeed { get; set; }
        //the ammount of damage blocked
        public double Defense { get; set; }
        //the ammount of current health
        public double Health { get; set; }
        public double Level { get; set; }
        //the maximum ammount of health
        public double MaxHealth { get; set; }
        //the speed an enemy or streamer can travel
        public double Speed { get; set; }
        //how much melee damage the enemy or streamer can deal
        //also perhaps how much they can carry
        public double Strength { get; set; }
        #endregion

        #region other
        //how much enemies drop or the streamer has to buy upgrades
        public uint Money { get; set; }
        #endregion
    }
}