﻿using System.ComponentModel.DataAnnotations;

namespace HakatonApi.Models.CourseDtos;

public class CreateCourseDto
{
    public string? CourseName { get; set; }
}