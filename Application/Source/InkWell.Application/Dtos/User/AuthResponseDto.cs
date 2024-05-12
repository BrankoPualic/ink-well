﻿namespace InkWell.Application.Dtos.User;

public class AuthResponseDto
{
	public string DisplayName { get; set; } = string.Empty;
	public string? ProfilePictureUrl { get; set; }
	public DateOnly DateOfBirth { get; set; }
	public string Token { get; set; } = string.Empty;
}