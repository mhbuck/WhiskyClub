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
    
    internal partial class Member
    {
    	public Member()
    	{
    		this.Events = new HashSet<Event>();
    		this.Notes = new HashSet<Note>();
    	}
    
    	public int MemberId { get; set; }
    	public string Name { get; set; }
    	public byte[] Version { get; set; }
    	public System.DateTime InsertedDate { get; set; }
    	public System.DateTime UpdatedDate { get; set; }
    
    	public virtual ICollection<Event> Events { get; set; }
    	public virtual ICollection<Note> Notes { get; set; }
    }
}
