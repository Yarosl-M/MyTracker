﻿namespace MyTracker_App.Models.Domain
{
	public enum IssueStatus
	{
		Pending,
		Declined,
		Open,
		Fixed,
		Duplicate,
		WontFix,
		WorksAsIntended,
		Invalid,
	}

	public enum UserRole // ?????
	{
		RegularUser,
		Operator,
		Admin,
	}
}