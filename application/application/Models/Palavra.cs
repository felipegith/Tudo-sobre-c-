﻿using System;

namespace application.Models
{
    public class Palavra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public bool Ativo { get; set; }
        public DateTime? Atualizado { get; set; }
        public DateTime Criado { get; set; }
    }
}
