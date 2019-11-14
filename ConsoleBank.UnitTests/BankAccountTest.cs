using System;
using ConsoleBank.Core;
using ConsoleBank.Core.Models;
using Xunit;

namespace ConsoleBank.UnitTests
{
    public class BankAccountTest
    {
        /// <summary>
        /// If the debit amount is valid, the method subtracts the debit amount
        /// from the account balance.
        /// </summary>
        [Fact]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = beginningBalance - debitAmount; //7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The method throws an ArgumentOutOfRangeException if the debit amount is less than zero.
        /// </summary>
        [Fact]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        /// <summary>
        /// The method throws an ArgumentOutOfRangeException if the debit amount
        /// is greater than the balance.
        /// </summary>
        [Fact]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
    }
}
