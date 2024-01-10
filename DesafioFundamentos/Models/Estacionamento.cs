using System.Numerics;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private string[,] veiculos;


        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            Console.WriteLine("Digite a quantidade de blocos do estacionamento:");
            int blocos = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade de vagas por bloco:");
            int vagas = int.Parse(Console.ReadLine());

            Console.Clear();

            veiculos = new string[blocos, vagas];

            for (int i = 0; i < blocos; i++) {
                for(int j = 0; j < vagas; j++) {
                    veiculos[i,j] = "Livre";
                }
            }

            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            Console.WriteLine("Digite o bloco em que o veículo estacionará:");
            int bloco = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Digite a vaga em que o veículo estacionará:");
            int vaga = int.Parse(Console.ReadLine()) - 1;

            if(veiculos[bloco,vaga] == "Livre") {
                veiculos[bloco, vaga] = placa;
                Console.WriteLine("O veículo com a placa " + placa + " foi estacionado na vaga " + (bloco + 1) + "-" + (vaga + 1));
                Console.ReadLine();
            } else {
                Console.WriteLine("A vaga " + (bloco + 1) + "-" + (vaga + 1) + " não está livre! Tente estacionar em outra.");
                Console.ReadLine();
            }
            Console.Clear();

        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite o bloco em que o veículo está estacionado:");
            int bloco = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Digite a vaga em que o veículo está estacionado:");
            int vaga = int.Parse(Console.ReadLine()) - 1;

            Console.Clear();
            if(veiculos[bloco,vaga] == "Livre") {
                Console.WriteLine("Não tem nenhum veículo nesta vaga!");
            } else {
                string placa = veiculos[bloco,vaga];
                veiculos[bloco,vaga] = "Livre";

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = (horas*precoPorHora) + precoInicial;

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            for(int i = 0; i < veiculos.GetLength(0); i++) {
                Console.WriteLine("--------------------");
                for(int j = 0; j < veiculos.GetLength(1); j++) {
                    Console.WriteLine((i + 1) + "-" + (j + 1) + " -> " + veiculos[i,j]);
                }
            }
        }
    }
}
