﻿namespace EFCoreDemo
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = null!;
        public string SignKey { get; set; } = null!;
        public string[] ValidateIPs { get; set; } = new string[] { };
    }
}
