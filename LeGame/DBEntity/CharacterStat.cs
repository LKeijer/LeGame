//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeGame.DBEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CharacterStat
    {
        public int PlayerID { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Strenght { get; set; }
        public int Improvisation { get; set; }
        public int Speed { get; set; }
        public int Intelligence { get; set; }
    
        public virtual Player Player { get; set; }
    }
}
