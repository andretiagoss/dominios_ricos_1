using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        //Métodologia para teste:
        //1 - RED: Faz o teste pra dar erro
        //2 - GREEN: Faz o teste pra dar certo
        //3 - REFACTOR: Refatora do código
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);

            //Garanta que o teste é verdadeiro quando o CNPJ for inválido.
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsValid()
        {
            var doc = new Document("34110468000150", EDocumentType.CNPJ);
            
            //Garanta que o teste é verdadeiro quando o CNPJ for válido.
            Assert.IsTrue(doc.Valid);   
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);

            //Garanta que o teste é verdadeiro quando o CPF for inválido.
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("34225545806")]
        [DataRow("54139739347")]
        [DataRow("01077284608")]
        public void ShouldReturnErrorWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);

            //Garanta que o teste é verdadeiro quando o CPF for válido.
            Assert.IsTrue(doc.Valid);
        }
    }
}
