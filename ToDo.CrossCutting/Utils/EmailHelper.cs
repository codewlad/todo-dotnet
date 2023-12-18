using System.Text.RegularExpressions;

namespace ToDo.CrossCutting.Utils
{
    public class EmailHelper
    {
        public bool IsEmailValid(string email)
        {
            // Define a expressão regular para verificar o formato do e-mail.
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            // Cria um objeto Regex com o padrão.
            Regex regex = new Regex(pattern);

            // Usa o método Match para verificar se o e-mail corresponde ao padrão.
            Match match = regex.Match(email);

            // Retorna true se houver correspondência, indicando que o e-mail é válido.
            return match.Success;
        }
    }
}
