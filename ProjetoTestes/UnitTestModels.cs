using NUnit.Framework;
using SistemaVendas.Models;
using System.Collections.Generic;

namespace ProjetoTestes
{
    public class UnitTestModels
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLogin()
        {
            LoginModel objLogin = new LoginModel();
            objLogin.Email = "filipenhimi@gmail.com";
            objLogin.Senha = "123456";
            bool result = objLogin.ValidarLogin();
            Assert.True(result);
        }

        [Test]
        public void TestLoginFail()
        {
            LoginModel objLogin = new LoginModel();
            objLogin.Email = "filipenhimi@gmail.com";
            objLogin.Senha = "teste";
            bool result = objLogin.ValidarLogin();
            Assert.True(result);
        }

        [Test]

        public void CheckListProdutos()
        {
            ProdutoModel objProduto = new ProdutoModel();
            var lista = objProduto.ListarTodosProdutos();
            Assert.IsInstanceOf<List<ProdutoModel>>(lista);
        }
    }
}