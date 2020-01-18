namespace AccountSystemApp.Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using AccountSystemApp.BLL.Interface.Interfaces;
    using AccountSystemApp.DAL.Interface.Interfaces;
    using AccountSystemApp.DAL.Interface.DTO;
    using AccountSystemApp.BLL.ServiceImplementation;
    using AccountSystemApp.BLL.Interface.Entities;    
    using NUnit.Framework;

    [TestFixture]
    public class BLLTests
    {
        Mock<IRepository<AccountDTO>> mockAccountRepository;
        Mock<IBonusLogic> mockBonusLogic;
        AccountService systemUnderTest;
        
        [TestCase(5)]
        public void TestCloseAccount(int accountNumber)
        {
            int saveArgument = 0;
            mockAccountRepository = new Mock<IRepository<AccountDTO>>(MockBehavior.Strict);
            mockBonusLogic = new Mock<IBonusLogic>(MockBehavior.Strict);
            mockAccountRepository.Setup(a => a.Delete(It.IsAny<int>())).Callback<int>(i => saveArgument = i);
            systemUnderTest = new AccountService(mockAccountRepository.Object, mockBonusLogic.Object);

            systemUnderTest.CloseAccount(accountNumber);

            mockAccountRepository.Verify(a => a.Delete(It.IsAny<int>()), Times.Once);

            Assert.That(saveArgument, Is.EqualTo(accountNumber));
        }

        [TestCase(1, 1000)]
        public void TestDepositAccount(int accountNumber, Decimal sum)
        {
            AccountDTO accountDTO = new AccountDTO() { AccountOwner = "test"};
            int saveGetArgument = 0;             
            mockAccountRepository = new Mock<IRepository<AccountDTO>>(MockBehavior.Strict);
            mockBonusLogic = new Mock<IBonusLogic>(MockBehavior.Strict);            

            mockAccountRepository.Setup(a => a.Get(It.IsAny<int>())).Callback<int>(i => saveGetArgument = i).Returns(accountDTO);            
            mockBonusLogic.Setup(a => a.PutBonus(It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<int>())).Returns(10);
            mockAccountRepository.Setup(a => a.Update(It.IsAny<AccountDTO>()));
            systemUnderTest = new AccountService(mockAccountRepository.Object, mockBonusLogic.Object);

            systemUnderTest.DepositAccount(accountNumber, sum);

            mockAccountRepository.Verify(a => a.Get(It.IsAny<int>()), Times.Once);            
            mockAccountRepository.Verify(a => a.Update(It.IsAny<AccountDTO>()), Times.Once);

            Assert.That(saveGetArgument, Is.EqualTo(accountNumber));            
        }

        [Test]
        public void TestGetAllAccounts ()
        {
            List<Account> expectedResult = new List<Account>()
            {
                new BaseAccount("test1", 0, 0),
                new GoldAccount("test2", 0, 0),
                new PlatinumAccount("test3", 0, 0),
            };

            List<AccountDTO> getAllAccountsResult = new List<AccountDTO>()
            {
                new AccountDTO() { AccountOwner = "test1"},
                new AccountDTO() { AccountOwner = "test2"},
                new AccountDTO() { AccountOwner = "test3"},
            };

            mockAccountRepository = new Mock<IRepository<AccountDTO>>(MockBehavior.Strict);
            mockBonusLogic = new Mock<IBonusLogic>(MockBehavior.Strict);
            mockAccountRepository.Setup(a => a.GetAll()).Returns(getAllAccountsResult);

            systemUnderTest = new AccountService(mockAccountRepository.Object, mockBonusLogic.Object);
                        
            List<Account> result  = systemUnderTest.GetAllAccounts();

            mockAccountRepository.Verify(a => a.GetAll(), Times.Once);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
