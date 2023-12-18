﻿namespace FT.Travelako.Services.Authentication.Base.Models
{
    public class GenericAPIResponse
    {

        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
