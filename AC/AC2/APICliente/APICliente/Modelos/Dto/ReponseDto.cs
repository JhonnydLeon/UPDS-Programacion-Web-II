﻿namespace APICliente.Modelos.Dto
{
    public class ReponseDto
    {
        public bool IsSuccess { get; set; }
        public object? Result { get; set; }
        public string? DisplayMessage { get; set; }
        public List<string>? ErrorMessages { get; set; }
    }
}
