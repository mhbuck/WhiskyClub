//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhiskyClub.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    
    internal partial class Whisky
    {
    	public Whisky()
    	{
    		this.EventWhiskies = new HashSet<EventWhisky>();
    		this.TastingNotes = new HashSet<TastingNote>();
    	}
    
    	public int WhiskyId { get; set; }
    	public string Name { get; set; }
    	public string Brand { get; set; }
    	public int Age { get; set; }
    	public string Country { get; set; }
    	public string Region { get; set; }
    	public string Description { get; set; }
    	public byte[] Image { get; set; }
    	public Nullable<decimal> Price { get; set; }
    	public Nullable<int> Volume { get; set; }
    	public byte[] Version { get; set; }
    	public System.DateTime InsertedDate { get; set; }
    	public System.DateTime UpdatedDate { get; set; }
    
    	public virtual ICollection<EventWhisky> EventWhiskies { get; set; }
    	public virtual ICollection<TastingNote> TastingNotes { get; set; }
    }
}
