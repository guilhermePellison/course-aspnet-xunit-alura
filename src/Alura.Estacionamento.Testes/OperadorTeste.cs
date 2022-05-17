using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes;

public class OperadorTeste
{
    private Veiculo veiculo;
    private Patio estacionamento;
    private Operador operador;

    public OperadorTeste()
    {
        veiculo = new Veiculo();
        estacionamento = new Patio();
        operador = new Operador();
        operador.Nome = "Zapdos Raivoso";
        operador.Matricula = "PE554";
    }

    [Fact]
    public void ValidaAlteracaoNomeOperador()
    {
        operador.Nome = "Novo Operador";
        var fichaOperador = operador.ToString();

        Assert.Contains("Novo Operador", fichaOperador);

    }
}
