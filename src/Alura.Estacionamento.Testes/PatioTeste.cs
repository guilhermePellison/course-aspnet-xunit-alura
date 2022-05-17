using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using FizzWare.NBuilder;
using Xunit;

namespace Alura.Estacionamento.Testes;
public class PatioTeste
{
    private Veiculo veiculo;
    private Patio estacionamento;
    private Operador operador;

    public PatioTeste()
    {
        veiculo = new Veiculo();
        estacionamento = new Patio();
        operador = new Operador();
        operador.Nome = "Zapdos Raivoso";
    }

    [Fact]
    public void ValidaFaturamentoDoEstacionamentoComUmAutomovel()
    {
        //Arrange
        //var estacionamento = new Patio();
        //var veiculo = new Veiculo();
        estacionamento.OperadorPatio = operador;
        veiculo.Proprietario = "Pikachu da Silva";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);
    }

    [Fact]
    public void ValidaFaturamentoDoEstacionamentoComUmaMotocicleta()
    {
        //Arrange
        //var estacionamento = new Patio();
        //var veiculo = new Veiculo();
        estacionamento.OperadorPatio = operador;
        veiculo.Proprietario = "Pikachu da Silva";
        veiculo.Tipo = TipoVeiculo.Motocicleta;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(1, faturamento);
    }

    [Theory]
    [InlineData("Gabriel Medeiros", "ASD-8544", "Preto", "Gol")]
    [InlineData("Lucas Manoel", "DDF-4528", "Roxo", "Camaro")]
    [InlineData("Jurema Creides", "GFD-6457", "Amarelo", "Fusca")]
    [InlineData("Creides Fherchman", "JSG-8512", "Azul", "Ix35")]
    public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario,
                                                    string placa,
                                                    string cor,
                                                    string modelo)
    {
        //Arrange
        Patio estacionamento = new Patio();
        //var veiculo = new Veiculo();
        estacionamento.OperadorPatio = operador;
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;
        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Ac
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);
    }

    [Theory]
    [InlineData("Gabriel Medeiros", "ASD-8544", "Preto", "Gol")]
    public void LocalizaVeiculoNoPatioComBaseNoIdDoTicket(string proprietario,
                                        string placa,
                                        string cor,
                                        string modelo)
    {
        //Arrange
        Patio estacionamento = new Patio();
        //var veiculo = new Veiculo();
        estacionamento.OperadorPatio = operador;
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        //Ac
        var consultado = estacionamento.PesquisaVeiculo(veiculo.Idticket);

        //Assert
        Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
    }

    [Fact]
    public void AlterarDadosDoProprioVeiculo()
    {
        //Arrange
        //var estacionamento = new Patio();
        //var veiculo = new Veiculo();
        estacionamento.OperadorPatio = operador;
        veiculo.Proprietario = "Pikachu da Silva";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        var veiculoAlterado = new Veiculo();
        veiculoAlterado.Proprietario = "Pikachu da Silva";
        veiculoAlterado.Tipo = TipoVeiculo.Automovel;
        veiculoAlterado.Cor = "Rosa"; //Alterado
        veiculoAlterado.Modelo = "Fusca";
        veiculoAlterado.Placa = "asd-9999";


        //Act
        Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

        //Assert
        Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
    }

    [Fact]
    public void ValidaTotalFaturadoDoEstacionamento()
    {
        //Arrange
        estacionamento.OperadorPatio = operador;
        veiculo.Proprietario = "Pikachu da Silva";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        string faturamento = estacionamento.MostrarFaturamento();

        //Assert
        Assert.Contains("Total faturado até o momento", faturamento);
    }

    [Fact]
    public void ValidaMensagemDeExcecaoRegistrarSaidaVeiculoPlacaNaoEncontrada()
    {
        estacionamento.OperadorPatio = operador;
        veiculo.Proprietario = "Pikachu da Silva";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";
        string placa = "";

        estacionamento.RegistrarEntradaVeiculo(veiculo);

        Assert.Equal("Não encontrado veículo com a placa informada.", estacionamento.RegistrarSaidaVeiculo(placa));
    }
}