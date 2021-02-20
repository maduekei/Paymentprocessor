using NUnit.Framework;
using EPayDomain.Interfaces.Manager;
using System.Threading.Tasks;
using EPayDomain.Model;
using EPayDomain.Manager;
using System;
using Moq;
using AutoMapper;
using EPayDomain.Interfaces.Services;
using EPayDomain.Interfaces.Repository;
using EPayDomain.Utilities;
using EPayDomain.Services;

namespace PaymentServiceTest
{

    public class PaymentManagerServiceTest
    {
         


        private IPaymentManager _payment;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {

            Assert.Pass();
        }

        [Test]
        public async Task RequestPayment_InsufficientBalance_ShouldFail()
        {
            //Arrange 
           
            var mockMapper = new Mock<IMapper>();
            var mockRoutePaymentGateway = new Mock<IRoutePaymentGateway>();
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var mockPaymentTransaction = new Mock<IPaymentTransactionRepository>();


            var fakeDate = new DateTime(2021, 12, 25);
            var fakepaymentRequest = new PaymentRequest
            {
                CreditCardNumber = "5399 4120 5220 4002",
                CardHolder = "James Brown",
                ExpirationDate = fakeDate,             //"2024-02-19T22:08:39.026Z",
                SecurityCode = "430",
                Amount = 4
            };

            mockRoutePaymentGateway.Setup(x=>x.GetPaymentServiceAsync(It.IsAny<decimal>())).Returns(Task.FromResult<IPaymentService>(new CheapPaymentGateway()));
            
            //Act
            var sut = new PaymentManager(mockRoutePaymentGateway.Object, mockPaymentRepository.Object, mockPaymentTransaction.Object, mockMapper.Object);
            var response = await sut.ProcessPaymentAsyc(fakepaymentRequest);
            //Asset
            Assert.IsNotNull(response);
            Assert.IsNotInstanceOf(typeof(PaymentResponse), response);
            //Set future date time - dumm
            Assert.IsFalse(response.Status == 1);
            Assert.IsTrue(response.Status == 2);
            Assert.IsTrue(response.Message.Contains("Failed"));
        }
    }
}

