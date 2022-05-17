using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes;

public class VeiculoTeste
{
    private Veiculo veiculo;

    public VeiculoTeste()
    {
        veiculo = new Veiculo();
    }

    [Fact]
    public void TestaVeiculoAcelerarComParametro10()
    {
        //var veiculo = new Veiculo();
        veiculo.Acelerar(10);
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrearComParametro10()
    {
        //var veiculo = new Veiculo();
        veiculo.Frear(10);
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void FihaDeInformacaoDoVeiculo()
    {
        //var veiculo = new Veiculo();
        veiculo.Proprietario = "Jose Medeiros";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Placa = "EZB-2459";
        veiculo.Cor = "Prata";
        veiculo.Modelo = "IX35";

        string dados = veiculo.ToString();

        Assert.Contains("Ficha do Veículo:", dados);
    }

    [Fact]
    public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
    {
        string nomeProprietario = "Ab";
        Assert.Throws<System.FormatException>(
            () => new Veiculo(nomeProprietario)
        );
    }

    [Fact]
    public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
    {
        string placa = "ASDF8888";

        var mensagem = Assert.Throws<System.FormatException>(
            () => new Veiculo().Placa = placa
        );
        Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
    }

    [Fact]
    public void TestaMensagemDeExcecaoDaQuantidadeDeCaracteresDaPlaca()
    {
        string placa = "ASDF12345";

        var mensagem = Assert.Throws<System.FormatException>(
            () => new Veiculo().Placa = placa
        );
        Assert.Equal("A placa deve possuir 8 caracteres", mensagem.Message);
    }

    [Fact]
    public void TestaMensagemDeExcecaoDos3PrimeirosCaracteresLetrasDaPlaca()
    {
        string placa = "AS5-1234";

        var mensagem = Assert.Throws<System.FormatException>(
            () => new Veiculo().Placa = placa
        );
        Assert.Equal("Os 3 primeiros caracteres devem ser letras!", mensagem.Message);
    }

    [Fact]
    public void TestaMensagemDeExcecaoDo4CaracteresHifenDaPlaca()
    {
        string placa = "ASGG1234";

        var mensagem = Assert.Throws<System.FormatException>(
            () => new Veiculo().Placa = placa
        );
        Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
    }

    [Fact]
    public void TestaMensagemDeExcecaoDo5A8CaracteresNumerosDaPlaca()
    {
        string placa = "ASG-12G4";

        var mensagem = Assert.Throws<System.FormatException>(
            () => new Veiculo().Placa = placa
        );
        Assert.Equal("Do 5º ao 8º caractere deve-se ter um número!", mensagem.Message);
    }

}