using System;


namespace Hackaton.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Não encontrado")
        {

        }

    }
}