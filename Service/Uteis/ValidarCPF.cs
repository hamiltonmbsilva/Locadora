namespace Service.Uteis
{
    public class ValidarCPF
	{
		public static bool IsCpf(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;

			//Removendo os espações antes e depois da string
			cpf = cpf.Trim();

			//Esta subistituindo o ('.') por espaço e o ('-') tambem por espaço
			cpf = cpf.Replace(".", "").Replace("-", "");

			//Valida um numero de caracteres
			if (cpf.Length != 11)
				return false;

			//Pega os 9 primeiros numeros do cpf para calcular o digito verificador
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			//Calcula os primeiros 9 numeros da direita para esquerda  por numeros crecente que seria do multiplicador1[i]
			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			//Aqui pega o primeiro digito verificador
			digito = resto.ToString();

			//Pega o primeiro resultado do digito verificador, para calcular o segundo Digito verificado
			tempCpf = tempCpf + digito;
			soma = 0;

			//Calcula os primeiros 9 numeros da direita para esquerda  por numeros crecente que seria do multiplicador2[i]
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;

			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			//Aqui pega o segundo digito verificador
			digito = digito + resto.ToString();

			//Retorna True e False , pegando os ultimos digitos
			return cpf.EndsWith(digito);
		}
	}
}
