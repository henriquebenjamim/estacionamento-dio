namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo() {
            // Solicita placa no padrão desejado, caso não esteja correto iremos tentar até o usuário colocar no formato correto.
            Console.WriteLine("Digite a placa do veículo para estacionar (XXX-0000):");
            string placa = Console.ReadLine();

            if (ValidarPlaca(placa)) {
                veiculos.Add(placa.ToUpper()); // Adiciona a placa formatada em maiúsculas à lista
                Console.WriteLine("Veículo adicionado com sucesso!");
            }
            else {
                Console.WriteLine("Placa inválida. Certifique-se de que está no formato correto (XXX-0000).");
                AdicionarVeiculo(); // Tentamos novamente
            }
        }

        public bool ValidarPlaca(string placa) {
        // Iremos verificar se a placa está no formato correto, 3 letras iniciais juntamente ao - e posterior a isso 4 numeros.
        return placa.Length == 8 &&
               char.IsLetter(placa[0]) && char.IsLetter(placa[1]) && char.IsLetter(placa[2]) &&
               placa[3] == '-' &&
               char.IsDigit(placa[4]) && char.IsDigit(placa[5]) && char.IsDigit(placa[6]) && char.IsDigit(placa[7]);
        }

        public void RemoverVeiculo()
        {   
            // lê o veículo a ser removido e, se existente, pega as informações de hora que passou para gerar o pagamento...
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0) {
                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    decimal valorTotal = precoInicial + (precoPorHora * horas); 

                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    veiculos.Remove(veiculos.Find(v => v.ToUpper() == placa.ToUpper()));

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else {
                    Console.WriteLine("Valor de horas inválido. Apenas números inteiros e positivos são válidos.");
                }
                
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string v in veiculos) {
                    Console.WriteLine(v);
                }
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
