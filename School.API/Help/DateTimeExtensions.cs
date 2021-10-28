using System;

namespace School.API.Help
{
    public static class DateTimeExtensions
    {
        // colocando o this como param você indica quem você quer extender
        public static int GetIdadeAtual(this DateTime dateTime)
        {
            var dataAtual = DateTime.UtcNow;
            var idade = dataAtual.Year - dateTime.Year;

            if (dataAtual < dateTime.AddYears(idade))
                idade--;

            return idade;
        }
    }
}