using System.Text.RegularExpressions;

namespace PetShop.Manager.Domain.ValueObjects
{
    public class Cpf
    {
        public string Value { get; private set; }

        public string MaskedValue { get; private set; }

        public Cpf(string cpf)
        {
            if (cpf is null || cpf.Length != 11)
            {
                throw new InvalidOperationException($"Invalid CPF: {cpf ?? "(nulo)"}");
            }

            Value = cpf;
            MaskedValue = Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
        }
    }
}
