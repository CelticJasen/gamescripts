using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Assignment
{
	public int ID{ get; set; }
	public string Name{ get; set; }
	public DateTime Date{ get; set; }
	public bool Repeat{ get;set; }
	public int Red{ get; set; }
	public int Green{ get; set; }
	public int Blue{ get; set; }
	public string Notes{ get; set; }
	public DateTime AlarmTime{ get; set; }

	public Assignment(int id, string name, DateTime date, bool repeat, int red, int green, int blue, string notes, DateTime alarmTime)
	{
		this.ID = id;
		this.Name = name;
		this.Date = date;
		this.Repeat = repeat;
		this.Red = red;
		this.Green = green;
		this.Blue = blue;
		this.Notes = notes;
		this.AlarmTime = alarmTime;
	}
}