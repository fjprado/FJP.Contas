using System;

namespace FJP.Contas
{
    class Program
    {
        static ContaRepositorio repositorio = new ContaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            try
            {
				while (opcaoUsuario.ToUpper() != "X")
				{
					switch (opcaoUsuario)
					{
						case "1":
							ListaContas();
							break;
						case "2":
							InserirConta();
							break;
						case "3":
							PagarConta();
							break;
						case "4":
							RemoverConta();
							break;
						case "5":
							VisualizarConta();
							break;
						case "C":
							Console.Clear();
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}

					opcaoUsuario = ObterOpcaoUsuario();
				}
			}
			catch(Exception ex)
            {
				Console.WriteLine("Impossível prosseguir com esta opção!");
			}
			

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void RemoverConta()
		{
			Console.Write("Digite o id da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceConta);
		}

        private static void VisualizarConta()
		{
			Console.Write("Digite o id da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			var conta = repositorio.RetornaPorId(indiceConta);

			Console.WriteLine(conta);
		}

        private static void PagarConta()
		{
			Console.Write("Digite o id da conta: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Console.Write("Digite a data de pagamento da conta (DD-MM-AAAA): ");
			DateTime.TryParse(Console.ReadLine(), out DateTime entradaDataPagamento);
			
			Console.Write("Digite o valor pago: ");
			decimal.TryParse(Console.ReadLine(), out decimal entradaValorPagamento);

			repositorio.Paga(indiceSerie, entradaDataPagamento, entradaValorPagamento);
		}

        private static void ListaContas()
		{
			Console.WriteLine("Listar Contas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			foreach (var conta in lista)
			{                
				Console.WriteLine("#ID {0}: {1} / {2} - {3} -- **{4}**", conta.retornaId(), conta.retornaTipoConta(), conta.retornaTitulo(), conta.retornaValor(), conta.retornaStatus());
			}
		}

        private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(TipoContaEnum)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoContaEnum), i));
			}

			Console.Write("Digite o tipo de conta entre as opções acima: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o título da conta: ");
			string entradaTitulo = Console.ReadLine();
			
			Console.Write("Digite o valor da conta: ");
			decimal.TryParse(Console.ReadLine(), out decimal entradaValorConta);

			Console.Write("Digite a data de vencimento da conta (DD-MM-AAAA): ");
			DateTime.TryParse(Console.ReadLine(), out DateTime entradaDataVencimento);

			Console.Write("Digite a data de pagamento da conta (se já tiver pago ou estiver programado) ou apenas dê enter (DD-MM-AAAA): ");
			DateTime.TryParse(Console.ReadLine(), out DateTime entradaDataPagamento);

			Conta novaConta = new Conta(id: repositorio.ProximoId(),
										tipoConta: (TipoContaEnum)entradaTipoConta,
										titulo: entradaTitulo,
										valor: entradaValorConta,
										dataVencimento: entradaDataVencimento,
										dataPagamento: entradaDataVencimento);

			repositorio.Insere(novaConta);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("FJP Contas a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Pagar conta");
			Console.WriteLine("4- Excluir conta");
			Console.WriteLine("5- Visualizar conta");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
