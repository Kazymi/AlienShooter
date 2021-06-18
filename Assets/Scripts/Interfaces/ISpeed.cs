    using System.Collections.Generic;

    public interface ISpeed
    {
        Dictionary<TypeBuff, float> ActiveBuffs { get; set; }
        public void AddBuff(TypeBuff buff, float valueSpeed);
        public void DeactivateBuff(TypeBuff buff);
    }
