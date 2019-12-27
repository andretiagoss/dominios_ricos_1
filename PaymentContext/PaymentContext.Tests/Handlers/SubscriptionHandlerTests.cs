using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailRepository());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName="Bruce";
            command.LastName="Wayne";
            command.Document="99999999999";
            command.Email="andretiagoss@gmail.com";
            command.BarCode="123456789";
            command.BoletoNumber= "123456789";
            command.PaymentNumber= "123121";
            command.PaidDate=DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total=60;
            command.TotalPaid=60;
            command.Payer="WAYNE CORP";
            command.PayerDocument="12345678911";
            command.PayerDocumentType=EDocumentType.CPF;
            command.PayerEmail="andretiagoss@gmail.com";
            command.Street="Rua 1";
            command.Number="1234";
            command.Neighborhood="Bairro legal";
            command.City="Jundiaí";
            command.State="SP";
            command.Country="BR";
            command.ZipCode = "12345678";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);

    }
}
}
