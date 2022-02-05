namespace InterviewTest.Models;

using System;

public record StudentDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}